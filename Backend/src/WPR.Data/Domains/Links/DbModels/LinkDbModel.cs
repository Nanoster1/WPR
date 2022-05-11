using System.Runtime.Versioning;
using WPR.Core.Domains.Links.Models;

namespace WPR.Data.Domains.Links.DbModels;

[RequiresPreviewFeatures]
public class LinkDbModel : IDbModel<LinkDbModel, Link>
{
    public Guid Id { get; set; }
    public LinkType Type { get; set; }
    public Guid ProjectId { get; set; }
    public string Title { get; set; }
    public Uri Url { get; set; }

    public static LinkDbModel FromBusinessModel(Link businessModel)
    {
        return new LinkDbModel
        {
            Title = businessModel.Title,
            Type = businessModel.Type,
            Url = businessModel.Url,
            ProjectId = businessModel.ProjectId
        };
    }

    public Link ToBusinessModel()
    {
        return new Link(Id, Title, Url, ProjectId, Type);
    }
}