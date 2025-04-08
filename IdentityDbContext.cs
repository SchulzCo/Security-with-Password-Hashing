
using Security_with_Password_Hashing.Models;

internal class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    // Add DbSets for additional entities if required
    public DbSet<Event> Events { get; set; }
    public object Users { get; internal set; }

    internal void SaveChanges()
    {
        throw new NotImplementedException();
    }
}
