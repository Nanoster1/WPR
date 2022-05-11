using FluentValidation;
using WPR.Core.Domains.Links.Interfaces;
using WPR.Core.Domains.Links.Models;
using WPR.Core.Domains.Projects.Interfaces;
using WPR.Core.Domains.Projects.Models;
using WPR.Core.Extensions;
using WPR.Core.UnitsOfWork;

namespace WPR.Core.Domains.Projects.Services;

public class ProjectManager : IProjectManager
{
    private readonly ILinkManager _linkManager;
    private readonly IProjectRepository _projectRepository;
    private readonly ProjectValidator _projectValidator;
    private readonly IUnitOfWork _unitOfWork;

    public ProjectManager(IUnitOfWork unitOfWork, IProjectRepository projectRepository, ILinkManager linkManager,
        ProjectValidator projectValidator)
    {
        _unitOfWork = unitOfWork;
        _projectRepository = projectRepository;
        _linkManager = linkManager;
        _projectValidator = projectValidator;
    }

    public Project GetById(Guid id)
    {
        return _projectRepository.GetById(id);
    }

    public Project[] GetByUserId(Guid id, int startIndex = 0, int quantity = -1)
    {
        return _projectRepository.GetByUserId(id, startIndex, quantity);
    }

    public Guid Create(Project project, Link[]? links)
    {
        _projectValidator.ValidateAndThrow(project);
        var id = _projectRepository.Create(project);
        links?.ForEach(link => link.ProjectId = id);
        if (links != null) _linkManager.Create(links);
        _unitOfWork.SaveChanges();
        return id;
    }

    public void Update(Project project, Link[] links)
    {
        _projectValidator.ValidateAndThrow(project);
        var oldLinksIds = _linkManager.GetByProjectId(project.Id)
            .Select(link => link.Id)
            .ToArray();
        _linkManager.DeleteManyById(oldLinksIds);
        links.ForEach(link => link.ProjectId = project.Id);
        _linkManager.Create(links);
        _projectRepository.Update(project);
        _unitOfWork.SaveChanges();
    }

    public void DeleteById(Guid id)
    {
        _projectRepository.DeleteById(id);
        _unitOfWork.SaveChanges();
    }
}