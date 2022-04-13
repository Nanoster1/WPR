using WPR.Core.Domains.Links.Interfaces;
using WPR.Core.Domains.Links.Models;
using WPR.Core.UnitsOfWork;

namespace WPR.Core.Domains.Links.Services;

public class LinkManager : ILinkManager
{
    private readonly ILinkRepository _linkRepository;
    private readonly IUnitOfWork _unitOfWork;

    public LinkManager(ILinkRepository linkRepository, IUnitOfWork unitOfWork)
    {
        _linkRepository = linkRepository;
        _unitOfWork = unitOfWork;
    }

    public Link GetById(Guid id)
    {
        return _linkRepository.GetById(id);
    }

    public IList<Link> GetByProjectId(Guid id)
    {
        return _linkRepository.GetByProjectId(id);
    }

    public Guid Create(Link link)
    {
        var id = _linkRepository.Create(link);
        _unitOfWork.SaveChanges();
        return id;
    }

    public IList<Guid> Create(IEnumerable<Link> links)
    {
        var ids = _linkRepository.Create(links);
        _unitOfWork.SaveChanges();
        return ids;
    }

    public void Update(Link link)
    {
        _linkRepository.Update(link);
        _unitOfWork.SaveChanges();
    }

    public void Update(IEnumerable<Link> links)
    {
        _linkRepository.Update(links);
        _unitOfWork.SaveChanges();
    }

    public void DeleteById(Guid id)
    {
        _linkRepository.DeleteById(id);
        _unitOfWork.SaveChanges();
    }
}