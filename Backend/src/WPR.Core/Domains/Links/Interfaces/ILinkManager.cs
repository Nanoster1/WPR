using WPR.Core.Domains.Links.Models;

namespace WPR.Core.Domains.Links.Interfaces;

public interface ILinkManager
{
    Link GetById(Guid id);
    IList<Link> GetByProjectId(Guid id);
    Guid Create(Link link);
    IList<Guid> Create(IEnumerable<Link> links);
    void Update(Link link);
    void Update(IEnumerable<Link> links);
    void DeleteById(Guid id);
}