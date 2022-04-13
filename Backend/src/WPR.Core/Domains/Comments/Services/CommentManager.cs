using WPR.Core.Domains.Comments.Interfaces;
using WPR.Core.Domains.Comments.Models;
using WPR.Core.UnitsOfWork;

namespace WPR.Core.Domains.Comments.Services;

public class CommentManager : ICommentManager
{
    private readonly ICommentRepository _commentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CommentManager(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
    {
        _commentRepository = commentRepository;
        _unitOfWork = unitOfWork;
    }

    public Comment GetById(Guid id)
    {
        return _commentRepository.GetById(id);
    }

    public IList<Comment> GetByAuthorId(Guid id)
    {
        return _commentRepository.GetByAuthorId(id);
    }

    public IList<Comment> GetByProjectId(Guid id)
    {
        return _commentRepository.GetByProjectId(id);
    }

    public Guid Create(Comment comment)
    {
        var id = _commentRepository.Create(comment);
        _unitOfWork.SaveChanges();
        return id;
    }

    public void Update(Comment comment)
    {
        _commentRepository.Update(comment);
        _unitOfWork.SaveChanges();
    }

    public void DeleteById(Guid id)
    {
        _commentRepository.DeleteById(id);
        _unitOfWork.SaveChanges();
    }

    public void UpdateContentById(Guid id, string content)
    {
        var model = _commentRepository.GetById(id);
        model.Content = content;
        _commentRepository.Update(model);
        _unitOfWork.SaveChanges();
    }
}