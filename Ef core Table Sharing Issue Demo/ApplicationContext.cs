using Ef_core_Table_Sharing_Issue_Demo.Model;

using Microsoft.EntityFrameworkCore;

namespace Ef_core_Table_Sharing_Issue_Demo;

public class ApplicationContext : DbContext
{
    public DbSet<ExactUser> ExactUsers { get; set; }

    public DbSet<SharedUser> SharedUsers { get; set; }

    public ApplicationContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite("Data Source=test.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
}
