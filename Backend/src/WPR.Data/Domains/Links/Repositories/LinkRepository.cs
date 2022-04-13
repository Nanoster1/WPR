using Microsoft.EntityFrameworkCore;
using WPR.Core.Domains.Links.Interfaces;
using WPR.Core.Domains.Links.Models;
using WPR.Data.Domains.Links.DbModels;

namespace WPR.Data.Domains.Links.Repositories;

public class LinkRepository : ILinkRepository
{
    private readonly WprDbContext _context;

    public LinkRepository(WprDbContext context)
    {
        _context = context;
    }

    public Link GetById(Guid id)
    {
        var model = GetModelById(id);
        return new Link
        {
            Id = model.Id,
            Title = model.Title,
            Url = model.Url,
            ProjectId = model.ProjectId,
            Type = model.Type
        };
    }

    public IList<Link> GetByProjectId(Guid id)
    {
        return _context.Links
            .AsNoTracking()
            .Where(model => model.ProjectId == id)
            .Select(model => new Link
            {
                Id = model.Id,
                Title = model.Title,
                Url = model.Url,
                ProjectId = model.ProjectId,
                Type = model.Type
            })
            .ToList();
    }

    public Guid Create(Link link)
    {
        var model = new LinkDbModel
        {
            Id = link.Id,
            Title = link.Title,
            Url = link.Url,
            ProjectId = link.ProjectId,
            Type = link.Type
        };
        _context.Links.Add(model);
        return model.Id;
    }

    public IList<Guid> Create(IEnumerable<Link> links)
    {
        var models = links.Select(link => new LinkDbModel
        {
            Title = link.Title,
            Type = link.Type,
            Url = link.Url,
            ProjectId = link.ProjectId
        }).ToList();
        _context.Links.AddRange(models);
        return models.Select(model => model.Id).ToList();
    }

    public void Update(Link link)
    {
        var model = GetModelById(link.Id, true);
        model.Title = link.Title;
        model.Url = link.Url;
        model.ProjectId = link.ProjectId;
    }

    public void Update(IEnumerable<Link> links)
    {
        foreach (var link in links)
        {
            var model = GetModelById(link.Id);
            model.Title = link.Title;
            model.Type = link.Type;
            model.Url = link.Url;
        }
    }

    public void DeleteById(Guid id)
    {
        var model = GetModelById(id);
        _context.Remove(model);
    }

    private LinkDbModel GetModelById(Guid id, bool isTracking = false)
    {
        var model = isTracking
            ? _context.Links.FirstOrDefault(dbModel => dbModel.Id == id)
            : _context.Links.AsNoTracking().FirstOrDefault(dbModel => dbModel.Id == id);

        if (model == null)
            throw new NullReferenceException();

        return model;
    }
}