using WPR.Core.Domains.Links.Models;

namespace WPR.Data.Domains.Links.DbModels;

public class LinkDbModel
{
    public Guid Id { get; set; }
    public LinkType Type { get; set; }
    public Guid ProjectId { get; set; }
    public string Title { get; set; }
    public Uri Url { get; set; }
}