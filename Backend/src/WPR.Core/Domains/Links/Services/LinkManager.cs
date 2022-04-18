using FluentValidation;
using WPR.Core.Domains.Links.Interfaces;
using WPR.Core.Domains.Links.Models;
using WPR.Core.UnitsOfWork;

namespace WPR.Core.Domains.Links.Services;

public class LinkManager : ILinkManager
{
    private readonly ILinkRepository _linkRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly LinkValidator _linkValidator;

    public LinkManager(ILinkRepository linkRepository, IUnitOfWork unitOfWork, LinkValidator linkValidator)
    {
        _linkRepository = linkRepository;
        _unitOfWork = unitOfWork;
        _linkValidator = linkValidator;
    }

    public Link GetById(Guid id)
    {
        return _linkRepository.GetById(id);
    }

    public Link[] GetByProjectId(Guid id)
    {
        return _linkRepository.GetByProjectId(id);
    }

    public IList<Guid> Create(Link[] links)
    {
        foreach (var link in links) _linkValidator.ValidateAndThrow(link);  
        var ids = _linkRepository.Create(links);
        _unitOfWork.SaveChanges();
        return ids;
    }

    public void Update(Link[] links)
    {
        foreach (var link in links) _linkValidator.ValidateAndThrow(link);
        _linkRepository.Update(links);
        _unitOfWork.SaveChanges();
    }

    public void DeleteById(Guid id)
    {
        _linkRepository.DeleteById(id);
        _unitOfWork.SaveChanges();
    }

    public void DeleteManyById(Guid[] ids)
    {
        _linkRepository.DeleteManyById(ids);
        _unitOfWork.SaveChanges();
    }
}