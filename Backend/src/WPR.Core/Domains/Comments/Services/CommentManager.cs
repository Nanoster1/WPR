using FluentValidation;
using WPR.Core.Domains.Comments.Interfaces;
using WPR.Core.Domains.Comments.Models;
using WPR.Core.UnitsOfWork;

namespace WPR.Core.Domains.Comments.Services;

public class CommentManager : ICommentManager
{
    private readonly ICommentRepository _commentRepository;
    private readonly CommentValidator _commentValidator;
    private readonly IUnitOfWork _unitOfWork;

    public CommentManager(ICommentRepository commentRepository, IUnitOfWork unitOfWork,
        CommentValidator commentValidator)
    {
        _commentRepository = commentRepository;
        _unitOfWork = unitOfWork;
        _commentValidator = commentValidator;
    }

    public Comment GetById(Guid id)
    {
        return _commentRepository.GetById(id);
    }

    public Comment[] GetByAuthorId(Guid id, int startIndex = 0, int quantity = -1)
    {
        return _commentRepository.GetByAuthorId(id, startIndex, quantity);
    }

    public Comment[] GetByProjectId(Guid id, int startIndex = 0, int quantity = -1)
    {
        return _commentRepository.GetByProjectId(id, startIndex, quantity);
    }

    public Comment[] GetByParentId(Guid id, int startIndex = 0, int quantity = -1)
    {
        return _commentRepository.GetByParentId(id, startIndex, quantity);
    }

    public Guid Create(Comment comment)
    {
        _commentValidator.Validate(comment);
        var id = _commentRepository.Create(comment);
        _unitOfWork.SaveChanges();
        return id;
    }

    public void Update(Comment comment)
    {
        _commentValidator.ValidateAndThrow(comment);
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
        var comment = _commentRepository.GetById(id);
        comment.Content = content;
        _commentValidator.ValidateAndThrow(comment);
        _commentRepository.Update(comment);
        _unitOfWork.SaveChanges();
    }
}