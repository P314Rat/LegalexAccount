using LegalexAccount.DAL.Models.CaseAggregate;
using LegalexAccount.DAL.Models.OrderAggregate;
using LegalexAccount.DAL.Models.UserAggregate;
using Microsoft.EntityFrameworkCore;


namespace LegalexAccount.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Specialist> Specialists { get; set; }
        public DbSet<Person> Individuals { get; set; }
        public DbSet<Legal> LegalEntities { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Case> Cases { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Ignore<User>();
            //modelBuilder.Ignore<Client>();

            //modelBuilder.Entity<Client>()
            //    .HasDiscriminator<string>("Discriminator")
            //    .HasValue<Client>("Client")
            //    .HasValue<Person>("Person")
            //    .HasValue<Legal>("Legal");

            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Person>().ToTable("Individuals");
            modelBuilder.Entity<Legal>().ToTable("LegalEntities");
        }
    }
}
