using Microsoft.EntityFrameworkCore;
using student_management_be_dotnet.Models;

namespace student_management_be_dotnet.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Student> Students => Set<Student>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Student>()
            .HasIndex(s => s.Email)
            .IsUnique();
    }
}
