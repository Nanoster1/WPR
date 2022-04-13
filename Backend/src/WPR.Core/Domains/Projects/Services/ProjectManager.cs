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

    public ProjectManager(IUnitOfWork unitOfWork, IProjectRepository projectRepository)
    {
        _unitOfWork = unitOfWork;
        _projectRepository = projectRepository;
    }

    public Project GetById(Guid id)
    {
        return _projectRepository.GetById(id);
    }

    public IList<Project> GetByUserId(Guid id)
    {
        return _projectRepository.GetByUserId(id);
    }

    public void Update(Project project, IEnumerable<Link>? links)
    {
        _projectRepository.Update(project);
        _linkManager.Update(links);
        _unitOfWork.SaveChanges();
    }

    public void DeleteById(Guid id)
    {
        _projectRepository.DeleteById(id);
        _unitOfWork.SaveChanges();
    }

    public Guid Create(Project project, IEnumerable<Link>? links)
    {
        var id = _projectRepository.Create(project);
        if (links != null) _linkManager.Create(links);
        _unitOfWork.SaveChanges();
        return id;
    }
}