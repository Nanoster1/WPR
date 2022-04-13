namespace WPR.Core.Domains.Links.Models;

public class Link
{
    public Guid Id { get; set; }
    public LinkType Type { get; set; }
    public Guid ProjectId { get; set; }
    public string Title { get; set; }
    public Uri Url { get; set; }
}