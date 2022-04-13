namespace WPR.Data.Domains.Comments.DbModels;

public class CommentDbModel
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    public string Content { get; set; }
    public Guid ProjectId { get; set; }
    public DateOnly CreatingDate { get; set; }
}