using Microsoft.EntityFrameworkCore;
using WPR.Core.Domains.Comments.Interfaces;
using WPR.Core.Domains.Comments.Models;
using WPR.Data.Domains.Comments.DbModels;

namespace WPR.Data.Domains.Comments.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly WprDbContext _context;

    public CommentRepository(WprDbContext context)
    {
        _context = context;
    }

    public Comment GetById(Guid id)
    {
        var model = GetModelById(id);
        return new Comment
        {
            Id = model.Id,
            Content = model.Content,
            AuthorId = model.AuthorId,
            CreatingDate = model.CreatingDate,
            ProjectId = model.ProjectId
        };
    }

    public IList<Comment> GetByAuthorId(Guid id)
    {
        return _context.Comments
            .AsNoTracking()
            .Where(model => model.AuthorId == id)
            .Select(model => new Comment
            {
                Id = model.Id,
                Content = model.Content,
                AuthorId = model.AuthorId,
                CreatingDate = model.CreatingDate,
                ProjectId = model.ProjectId
            })
            .ToList();
    }

    public IList<Comment> GetByProjectId(Guid id)
    {
        return _context.Comments
            .AsNoTracking()
            .Where(model => model.ProjectId == id)
            .Select(model => new Comment
            {
                Id = model.Id,
                Content = model.Content,
                AuthorId = model.AuthorId,
                CreatingDate = model.CreatingDate,
                ProjectId = model.ProjectId
            })
            .ToList();
    }

    public Guid Create(Comment comment)
    {
        var model = new CommentDbModel
        {
            Content = comment.Content,
            AuthorId = comment.AuthorId,
            CreatingDate = comment.CreatingDate,
            ProjectId = comment.ProjectId
        };
        _context.Add(model);
        return model.Id;
    }

    public void Update(Comment comment)
    {
        var model = GetModelById(comment.Id, true);
        model.Content = comment.Content;
        model.AuthorId = comment.AuthorId;
        model.CreatingDate = comment.CreatingDate;
        model.ProjectId = comment.ProjectId;
    }

    public void DeleteById(Guid id)
    {
        var model = GetModelById(id);
        _context.Comments.Remove(model);
    }

    private CommentDbModel GetModelById(Guid id, bool isTracking = false)
    {
        var model = isTracking
            ? _context.Comments.FirstOrDefault(dbModel => dbModel.Id == id)
            : _context.Comments.AsNoTracking().FirstOrDefault(dbModel => dbModel.Id == id);

        if (model == null)
            throw new NullReferenceException();

        return model;
    }
}