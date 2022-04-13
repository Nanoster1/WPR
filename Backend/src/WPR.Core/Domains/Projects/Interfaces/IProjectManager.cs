using WPR.Core.Domains.Links.Models;
using WPR.Core.Domains.Projects.Models;

namespace WPR.Core.Domains.Projects.Interfaces;

public interface IProjectManager
{
    Project GetById(Guid id);
    IList<Project> GetByUserId(Guid id);
    Guid Create(Project project, IEnumerable<Link>? links);
    void Update(Project project, IEnumerable<Link>? links);
    void DeleteById(Guid id);
}