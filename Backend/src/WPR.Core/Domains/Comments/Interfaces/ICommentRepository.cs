using WPR.Core.Domains.Comments.Models;

namespace WPR.Core.Domains.Comments.Interfaces;

public interface ICommentRepository
{
    Comment GetById(Guid id);
    Comment[] GetByAuthorId(Guid id, int startIndex = 0, int quantity = -1);
    Comment[] GetByProjectId(Guid id, int startIndex = 0, int quantity = -1);
    Comment[] GetByParentId(Guid id, int startIndex, int quantity);
    Guid Create(Comment comment);
    void Update(Comment comment);
    void DeleteById(Guid id);
}