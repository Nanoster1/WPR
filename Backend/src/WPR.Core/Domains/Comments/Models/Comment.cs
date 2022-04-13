namespace WPR.Core.Domains.Comments.Models;

public class Comment
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    public string Content { get; set; }
    public Guid ProjectId { get; set; }
    public DateOnly CreatingDate { get; set; }
}