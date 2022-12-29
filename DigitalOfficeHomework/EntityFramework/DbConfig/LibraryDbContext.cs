using Microsoft.EntityFrameworkCore;

namespace DigitalOfficeHomework.EntityFramework.DbConfig;

public class LibraryDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost\sqlexpress;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True");
    }
  
    public DbSet<DbLibrary> Libraries { get; set; }
    public DbSet<DbReader> Readers { get; set; }
}