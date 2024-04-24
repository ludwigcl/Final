using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=YourDatabaseName.db");
    }
}