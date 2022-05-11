using WPR.Core.Domains.Links.Models;
using WPR.Core.Domains.Projects.Models;

namespace WPR.Core.Domains.Projects.Interfaces;

public interface IProjectManager
{
    Project GetById(Guid id);
    Project[] GetByUserId(Guid id, int startIndex = 0, int quantity = -1);
    Guid Create(Project project, Link[]? links);
    void Update(Project project, Link[] links);
    void DeleteById(Guid id);
}