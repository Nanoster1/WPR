using Microsoft.EntityFrameworkCore;
using WPR.Core.Domains.Projects.Interfaces;
using WPR.Core.Domains.Projects.Models;
using WPR.Data.Domains.Projects.DbModels;

namespace WPR.Data.Domains.Projects.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly WprDbContext _context;

    public ProjectRepository(WprDbContext context)
    {
        _context = context;
    }

    public Project GetById(Guid id)
    {
        var model = GetModelById(id);
        return model.ToBusinessModel();
    }

    public Project[] GetByUserId(Guid id)
    {
        return _context.Projects
            .AsNoTracking()
            .Where(model => model.AuthorId == id)
            .Select(model => model.ToBusinessModel())
            .ToArray();
    }

    public Guid Create(Project project)
    {
        var model = ProjectDbModel.FromBusinessModel(project);
        _context.Projects.Add(model);
        return model.Id;
    }

    public void Update(Project project)
    {
        var model = GetModelById(project.Id, true);
        model.Name = project.Name;
        model.Rating = project.Rating;
        model.AuthorId = project.AuthorId;
        model.LongDesc = project.LongDesc;
        model.ShortDesc = project.ShortDesc;
    }

    public void DeleteById(Guid id)
    {
        var model = GetModelById(id);
        _context.Projects.Remove(model);
    }

    private ProjectDbModel GetModelById(Guid id, bool isTracking = false)
    {
        var model = isTracking
            ? _context.Projects.FirstOrDefault(dbModel => dbModel.Id == id)
            : _context.Projects.AsNoTracking().FirstOrDefault(dbModel => dbModel.Id == id);

        if (model == null)
            throw new NullReferenceException();

        return model;
    }
}