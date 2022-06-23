namespace WPR.Core.Domains.Links.Models;

public class Link
{
    public Link(Guid id, string title, Uri url, Guid projectId, LinkType type)
    {
        Id = id;
        Title = title;
        Url = url;
        ProjectId = projectId;
        Type = type;
    }

    public Guid Id { get; set; }
    public LinkType Type { get; set; }
    public Guid ProjectId { get; set; }
    public string Title { get; set; }
    public Uri Url { get; set; }
}