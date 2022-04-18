using FluentValidation;
using WPR.Core.Domains.Links.Interfaces;
using WPR.Core.Domains.Links.Models;
using WPR.Core.Domains.Projects.Interfaces;
using WPR.Core.Domains.Projects.Models;
using WPR.Core.UnitsOfWork;

namespace WPR.Core.Domains.Projects.Services;

public class ProjectManager : IProjectManager
{
    private readonly ILinkManager _linkManager;
    private readonly IProjectRepository _projectRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ProjectValidator _projectValidator;
    
    public ProjectManager(IUnitOfWork unitOfWork, IProjectRepository projectRepository, ILinkManager linkManager, ProjectValidator projectValidator)
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

    public Project[] GetByUserId(Guid id)
    {
        return _projectRepository.GetByUserId(id);
    }
    
    public Guid Create(Project project, Link[] links)
    {
        _projectValidator.ValidateAndThrow(project);
        _linkManager.Create(links);
        var id = _projectRepository.Create(project);
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