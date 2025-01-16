using LegalexAccount.DAL.Models.CaseAggregate;
using LegalexAccount.DAL.Models.OrderAggregate;
using LegalexAccount.DAL.Models.UserAggregate;
using Microsoft.EntityFrameworkCore;


namespace LegalexAccount.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Specialist> Specialists { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Person> Individuals { get; set; }
        public DbSet<Legal> LegalEntities { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Case> Cases { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Указываем, что Client и Specialist наследуют от User, но не создаем таблицу для User
            //modelBuilder.Entity<Client>().HasBaseType<User>();
            //modelBuilder.Entity<Specialist>().HasBaseType<User>();

            // Таблица Clients для базового класса Client
            modelBuilder.Entity<Client>().ToTable("Clients");

            //// Наследники Client
            modelBuilder.Entity<Person>()
                .ToTable("Individuals")
                .HasBaseType<Client>(); // Связь с таблицей Clients

            modelBuilder.Entity<Legal>()
                .ToTable("LegalEntities")
                .HasBaseType<Client>(); // Связь с таблицей Clients

            //// Таблица для специалистов
            //modelBuilder.Entity<Specialist>().ToTable("Specialists");

            // Связи для Case
            modelBuilder.Entity<Case>()
                .HasOne(x => x.Customer) // Связь с клиентом
                .WithMany(x => x.Cases) // Клиент может иметь несколько дел
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict); // Поведение при удалении, зависит от требований


            modelBuilder.Entity<Case>()
                .HasOne(x => x.Assignee) // Связь с исполнителем
                .WithMany(x => x.Cases)
                .HasForeignKey(x => x.AssigneeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
