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
        return model.ToBusinessModel();
    }

    public Comment[] GetByAuthorId(Guid id, int startIndex, int quantity)
    {
        var models = _context.Comments
            .AsNoTracking()
            .Where(model => model.AuthorId == id)
            .Skip(startIndex);
        return quantity < 0
            ? models.Select(model => model.ToBusinessModel()).ToArray()
            : models.Take(quantity).Select(model => model.ToBusinessModel()).ToArray();
    }

    public Comment[] GetByParentId(Guid id, int startIndex, int quantity)
    {
        var models = _context.Comments
            .AsNoTracking()
            .Where(model => model.ParentId == id)
            .Skip(startIndex);
        return quantity < 0
            ? models.Select(model => model.ToBusinessModel()).ToArray()
            : models.Take(quantity).Select(model => model.ToBusinessModel()).ToArray();
    }

    public Guid Create(Comment comment)
    {
        var model = CommentDbModel.FromBusinessModel(comment);
        _context.Add(model);
        return model.Id;
    }

    public void Update(Comment comment)
    {
        var model = GetModelById(comment.Id, true);
        model.Content = comment.Content;
        model.AuthorId = comment.AuthorId;
        model.CreatingDateTime = comment.CreatingDateTime;
        model.ProjectId = comment.ProjectId;
        model.ParentId = comment.ParentId;
    }

    public void DeleteById(Guid id)
    {
        var model = GetModelById(id);
        _context.Comments.Remove(model);
    }

    public Comment[] GetByProjectId(Guid id, int startIndex, int quantity)
    {
        var models = _context.Comments
            .AsNoTracking()
            .Where(model => model.ProjectId == id && model.ParentId == default)
            .Skip(startIndex);
        return quantity < 0
            ? models.Select(model => model.ToBusinessModel()).ToArray()
            : models.Take(quantity).Select(model => model.ToBusinessModel()).ToArray();
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