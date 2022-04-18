using WPR.Core.Domains.Comments.Models;

namespace WPR.Data.Domains.Comments.DbModels;

public class CommentDbModel : IDbModel<CommentDbModel, Comment>
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    public Guid? ParentId { get; set; }
    public string Content { get; set; }
    public Guid ProjectId { get; set; }
    public DateTime CreatingDateTime { get; set; }

    public static CommentDbModel FromBusinessModel(Comment businessModel)
    {
        return new CommentDbModel
        {
            Id = businessModel.Id,
            Content = businessModel.Content,
            AuthorId = businessModel.AuthorId,
            ParentId = businessModel.ParentId,
            ProjectId = businessModel.ProjectId,
            CreatingDateTime = businessModel.CreatingDateTime
        };
    }

    public Comment ToBusinessModel()
    {
        return new Comment(Id, Content, AuthorId, CreatingDateTime, ProjectId, ParentId);
    }
}