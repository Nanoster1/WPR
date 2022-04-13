namespace WPR.Core.Domains.Projects.Models;

public class Project
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ShortDesc { get; set; }
    public string LongDesc { get; set; }
    public int Rating { get; set; }
    public Guid AuthorId { get; set; }
}