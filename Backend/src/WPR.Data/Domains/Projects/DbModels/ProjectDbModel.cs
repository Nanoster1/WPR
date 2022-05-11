using WPR.Core.Domains.Projects.Models;

namespace WPR.Data.Domains.Projects.DbModels;

public class ProjectDbModel : IDbModel<ProjectDbModel, Project>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ShortDesc { get; set; }
    public string LongDesc { get; set; }
    public int Rating { get; set; }
    public Guid AuthorId { get; set; }

    public static ProjectDbModel FromBusinessModel(Project businessModel)
    {
        return new ProjectDbModel
        {
            Name = businessModel.Name,
            Rating = businessModel.Rating,
            AuthorId = businessModel.AuthorId,
            LongDesc = businessModel.LongDesc,
            ShortDesc = businessModel.ShortDesc
        };
    }

    public Project ToBusinessModel()
    {
        return new Project(Id, Name, Rating, AuthorId, LongDesc, ShortDesc);
    }
}