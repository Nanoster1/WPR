namespace WPR.Core.Domains.Projects.Models;

public class Project
{
    public Project(Guid id, string name, int rating, Guid authorId, string longDesc, string shortDesc)
    {
        Id = id;
        Name = name;
        Rating = rating;
        AuthorId = authorId;
        LongDesc = longDesc;
        ShortDesc = shortDesc;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ShortDesc { get; set; }
    public string LongDesc { get; set; }
    public int Rating { get; set; }
    public int ScoresCount { get; set; }
    public int NormalizeRating() => Rating / ScoresCount;
    public Guid AuthorId { get; set; }
}