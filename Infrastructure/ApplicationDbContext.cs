using Domain.Core.AccountAggregate;
using Domain.Core.CaseAggregate;
using Domain.Core.ChatAggregate;
using Domain.Core.OrderAggregate;
using Domain.Core.UserAggregate;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Specialist> Specialists { get; set; }
        public DbSet<Legal> LegalEntities { get; set; }
        public DbSet<Person> Individuals { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<SpecialistRole> SpecialistRoles { get; set; }
        public DbSet<ClientRole> ClientRoles { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ================== Наследование ==================
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Client>().ToTable("Clients").HasBaseType<User>();
            modelBuilder.Entity<Specialist>().ToTable("Specialists").HasBaseType<User>();
            modelBuilder.Entity<Person>().ToTable("Individuals").HasBaseType<Client>();
            modelBuilder.Entity<Legal>().ToTable("LegalEntities").HasBaseType<Client>();

            // ================== Связь с  Roles ==================
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey("UserRoleId");

            // ================== Заполнение Roles ==================
            modelBuilder.Entity<UserRole>().HasData(
                Enum.GetValues(typeof(Utilities.Types.UserRole))
                    .Cast<Utilities.Types.UserRole>()
                    .Select(x => new UserRole
                    {
                        UserRoleId = x,
                        Name = x.ToString()
                    })
                );
            modelBuilder.Entity<SpecialistRole>().HasData(
                Enum.GetValues(typeof(Utilities.Types.SpecialistRole))
                    .Cast<Utilities.Types.SpecialistRole>()
                    .Select(x => new SpecialistRole
                    {
                        SpecialistRoleId = x,
                        Name = x.ToString()
                    })
                );
            modelBuilder.Entity<ClientRole>().HasData(
                Enum.GetValues(typeof(Utilities.Types.ClientRole))
                    .Cast<Utilities.Types.ClientRole>()
                    .Select(x => new ClientRole
                    {
                        ClientRoleId = x,
                        Name = x.ToString()
                    })
                );

            // ================== Ограничение удаления Client и Specialist ==================
            modelBuilder.Entity<Case>()
                .HasOne(c => c.Customer)
                .WithMany(c => c.Cases)
                .OnDelete(DeleteBehavior.Restrict); // Нельзя удалить клиента, если есть дела
            modelBuilder.Entity<Case>()
                .HasMany(c => c.Assignees)
                .WithMany(s => s.Cases)
                .UsingEntity<Dictionary<string, object>>(
                    "CaseSpecialist",
                    j => j.HasOne<Specialist>()
                        .WithMany()
                        .HasForeignKey("AssigneeId")
                        .OnDelete(DeleteBehavior.Restrict), // Нельзя удалить специалиста, если есть дела
                    j => j.HasOne<Case>()
                        .WithMany()
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade) // Если удаляем дело — удаляем связь
                );

            // ================== Связь User - Chat ==================
            modelBuilder.Entity<Chat>()
                .HasMany(c => c.Members)
                .WithMany(u => u.Chats)
                .UsingEntity<Dictionary<string, object>>(
                    "UserChat",
                    j => j.HasOne<User>()
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<Chat>()
                        .WithMany()
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                );

            // ================== Связь Chat - Message ==================
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Chat)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
