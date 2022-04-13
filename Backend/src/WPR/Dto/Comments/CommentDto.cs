namespace WPR.Dto.Comments;

public record CommentDto
(
    Guid Id,
    Guid AuthorId,
    string AuthorName,
    string Content,
    DateOnly CreatingDate
);