using WPR.Core.Domains.Projects.Models;

namespace WPR.Core.Domains.Projects.Interfaces;

public interface IProjectRepository
{
    Project GetById(Guid id);
    Project[] GetByUserId(Guid id, int startIndex, int quantity);
    Guid Create(Project project);
    void Update(Project project);
    void DeleteById(Guid id);
}