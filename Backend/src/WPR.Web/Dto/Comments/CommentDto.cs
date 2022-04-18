namespace WPR.Web.Dto.Comments;

public record CommentDto
(
    Guid Id,
    Guid AuthorId,
    string AuthorName,
    string Content,
    DateTime CreatingDateTime,
    Guid? ParentId = null
);