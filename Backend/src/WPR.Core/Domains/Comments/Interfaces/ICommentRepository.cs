using WPR.Core.Domains.Comments.Models;

namespace WPR.Core.Domains.Comments.Interfaces;

public interface ICommentRepository
{
    Comment GetById(Guid id);
    Comment[] GetByAuthorId(Guid id);
    Comment[] GetByProjectId(Guid id);
    Guid Create(Comment comment);
    void Update(Comment comment);
    void DeleteById(Guid id);
}