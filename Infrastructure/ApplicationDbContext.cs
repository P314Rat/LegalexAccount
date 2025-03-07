using Domain.Core.AccountAggregate;
using Domain.Core.CaseAggregate;
using Domain.Core.OrderAggregate;
using Domain.Core.UserAggregate;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Specialist> Specialists { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Person> Individuals { get; set; }
        public DbSet<Legal> LegalEntities { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Clients");

            modelBuilder.Entity<Person>()
                .ToTable("Individuals")
                .HasBaseType<Client>();

            modelBuilder.Entity<Legal>()
                .ToTable("LegalEntities")
                .HasBaseType<Client>();

            //modelBuilder.Entity<Case>()
            //    .HasOne(x => x.Customer)
            //    .WithMany(x => x.Cases)
            //    .HasForeignKey(x => x.CustomerId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Case>()
            //    .HasMany(x => x.Assignees)
            //    .WithOne(x => x.Cases)
            //    .HasForeignKey(x => x.AssigneeId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
