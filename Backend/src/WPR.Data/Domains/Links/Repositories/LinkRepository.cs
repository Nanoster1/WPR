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
        return model.ToBusinessModel();
    }

    public Link[] GetByProjectId(Guid id, int startIndex, int quantity)
    {
        return _context.Links
            .AsNoTracking()
            .Where(model => model.ProjectId == id)
            .Skip(startIndex)
            .Take(quantity)
            .Select(model => model.ToBusinessModel())
            .ToArray();
    }

    public Guid Create(Link link)
    {
        var model = LinkDbModel.FromBusinessModel(link);
        _context.Links.Add(model);
        return model.Id;
    }

    public Guid[] Create(Link[] links)
    {
        var models = links.Select(LinkDbModel.FromBusinessModel).ToArray();
        _context.Links.AddRange(models);
        return models.Select(model => model.Id).ToArray();
    }

    public void Update(Link link)
    {
        var model = GetModelById(link.Id, true);
        model.Title = link.Title;
        model.Url = link.Url;
        model.ProjectId = link.ProjectId;
    }

    public void Update(Link[] links)
    {
        foreach (var link in links)
        {
            var model = GetModelById(link.Id, true);
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

    public void DeleteManyById(Guid[] ids)
    {
        var models = GetModelsById(ids);
        _context.Links.RemoveRange(models);
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

    private LinkDbModel[] GetModelsById(Guid[] ids, bool isTracking = false)
    {
        var model = isTracking
            ? _context.Links.Where(dbModel => ids.Contains(dbModel.Id)).ToArray()
            : _context.Links.AsNoTracking().Where(dbModel => ids.Contains(dbModel.Id)).ToArray();

        if (model == null)
            throw new NullReferenceException();

        return model;
    }
}