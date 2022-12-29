namespace DigitalOfficeHomework.EntityFramework.DbConfig;

public class DbReader
{
    // public const string TABLE_NAME = "Readers";
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int LibraryCard { get; set; }
    public Guid LibraryId { get; set; }
    public DbLibrary Library { get; set; }
    
}