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
            modelBuilder.Entity<Specialist>().ToTable("Specialists");
            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Person>().ToTable("Individuals");
            modelBuilder.Entity<Legal>().ToTable("LegalEntities");

            // Связь с заказчиком: Заказчик обязательно должен быть, нельзя удалить заказчика, пока он привязан к делу
            modelBuilder.Entity<Case>()
                .HasOne(c => c.Customer)
                .WithMany()
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Restrict); // Не разрешаем удалять заказчика, если он связан с делом

            // Связь с исполнителем: Исполнитель также обязательно должен быть, но может быть изменён или удалён
            modelBuilder.Entity<Case>()
                .HasOne(c => c.Assignee)
                .WithMany()
                .HasForeignKey(c => c.AssigneeId)
                .OnDelete(DeleteBehavior.Restrict); // Не разрешаем удалять исполнителя, если он связан с делом
        }
    }
}
