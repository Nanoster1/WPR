namespace WPR.Core.Domains.Comments.Models;

public class Comment
{
    public Comment(Guid id, string content, Guid authorId, DateTime creatingDateTime, Guid projectId,
        Guid? parentId)
    {
        Id = id;
        Content = content;
        AuthorId = authorId;
        CreatingDateTime = creatingDateTime;
        ProjectId = projectId;
        ParentId = parentId;
    }

    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    public Guid? ParentId { get; set; }
    public string Content { get; set; }
    public Guid ProjectId { get; set; }
    public DateTime CreatingDateTime { get; set; }
}