using WPR.Core.Domains.Links.Models;

namespace WPR.Core.Domains.Links.Interfaces;

public interface ILinkManager
{
    Link GetById(Guid id);
    Link[] GetByProjectId(Guid id, int startIndex = 0, int quantity = -1);
    Guid[] Create(Link[] links);
    void Update(Link[] links);
    void DeleteById(Guid id);
    void DeleteManyById(Guid[] ids);
}