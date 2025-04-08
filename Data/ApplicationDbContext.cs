using Security_with_Password_Hashing.Models;
using System.Text;

namespace Security_with_Password_Hashing.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<ApiLog> ApiLogs { get; set; }
        public object DeleteBehavior { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // Insertar usuarios iniciales
    modelBuilder.Entity<User>().HasData(
        new User { UserId = 1, Username = "admin", PasswordHash = Convert.ToBase64String(new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes("AdminPassword123"))), Role = "Admin" },
        new User { UserId = 2, Username = "user", PasswordHash = Convert.ToBase64String(new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes("UserPassword123"))), Role = "User" }
    );

    // Insertar eventos iniciales
    modelBuilder.Entity<Event>().HasData(
        new Event { EventId = 1, Name = "Evento 1", Description = "Descripción del Evento 1", EventDate = DateTime.Now, UserId = 2 },
        new Event { EventId = 2, Name = "Evento 2", Description = "Descripción del Evento 2", EventDate = DateTime.Now, UserId = 2 }
    );
}
}
