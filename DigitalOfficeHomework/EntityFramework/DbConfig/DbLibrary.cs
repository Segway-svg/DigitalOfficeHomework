using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalOfficeHomework.EntityFramework.DbConfig;

public class DbLibrary
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public DateTime FoundationDate { get; set; }
    public ICollection<DbReader> Readers { get; set; } = new List<DbReader>();

    // public DbLibrary()
    // {
    //     Readers = new HashSet<DbReader>();
    // }
}

public class DbLibraryConfiguration : IEntityTypeConfiguration<DbLibrary>
{
    public void Configure(EntityTypeBuilder<DbLibrary> builder)
    {
        builder
            .ToTable("Libraries");
        builder
            .HasKey(l => l.Id);
        builder
            .HasMany(l => l.Readers)
            .WithOne(r => r.Library);
    }
}