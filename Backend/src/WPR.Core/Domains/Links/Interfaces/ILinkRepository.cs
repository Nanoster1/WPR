using WPR.Core.Domains.Links.Models;

namespace WPR.Core.Domains.Links.Interfaces;

public interface ILinkRepository
{
    Link GetById(Guid id);
    Link[] GetByProjectId(Guid id);
    Guid Create(Link link);
    Guid[] Create(Link[] links);
    void Update(Link link);
    void Update(Link[] links);
    void DeleteById(Guid id);
    void DeleteManyById(Guid[] ids);
}