using WPR.Core.Domains.Comments.Models;

namespace WPR.Core.Domains.Comments.Interfaces;

public interface ICommentRepository
{
    Comment GetById(Guid id);
    IList<Comment> GetByAuthorId(Guid id);
    IList<Comment> GetByProjectId(Guid id);
    Guid Create(Comment comment);
    void Update(Comment comment);
    void DeleteById(Guid id);
}