using Microsoft.AspNetCore.Mvc;
using WPR.Core.Domains.Links.Interfaces;
using WPR.Core.Domains.Links.Models;
using WPR.Core.Domains.Projects.Interfaces;
using WPR.Core.Domains.Users.Interfaces;
using WPR.Web.Dto.Links;
using WPR.Web.Dto.Projects;

namespace WPR.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly ILinkManager _linkManager;
    private readonly IProjectManager _projectManager;
    private readonly IUserManager _userManager;

    public ProjectController(IProjectManager projectManager, ILinkManager linkManager, IUserManager userManager)
    {
        _projectManager = projectManager;
        _linkManager = linkManager;
        _userManager = userManager;
    }

    /// <summary>
    ///     Возвращает полный объект проекта (За исключением комментариев) по Id
    /// </summary>
    /// <param name="id">Id проекта</param>
    /// <returns>Полный объект проекта (За исключением комментариев)</returns>
    [HttpGet("{id:guid}")]
    public ProjectDto GetById(Guid id)
    {
        var model = _projectManager.GetById(id);
        var links = _linkManager.GetByProjectId(id);
        var user = _userManager.GetById(model.AuthorId);

        var screenshots = links.Where(link => link.Type is LinkType.Screenshot)
            .Select(link => new PrLinkDto(link.Id, link.Title, link.Url)).ToArray();

        var standardLinks = links.Where(link => link.Type is LinkType.Standard)
            .Select(link => new PrLinkDto(link.Id, link.Title, link.Url)).ToArray();

        var downloadLinks = links.Where(link => link.Type is LinkType.Download)
            .Select(link => new PrLinkDto(link.Id, link.Title, link.Url)).ToArray();

        return new ProjectDto(
            model.Id,
            model.Name,
            model.Rating,
            standardLinks,
            screenshots,
            downloadLinks,
            model.AuthorId,
            user.Login,
            model.ShortDesc,
            model.LongDesc);
    }

    /// <summary>
    ///     Создаёт проект
    /// </summary>
    /// <param name="project">Данные для создания проекта</param>
    /// <returns>Id созданного проекта</returns>
    [HttpPost]
    public Guid Create(ProjectCreatingDto project)
    {
        return _projectManager.Create(project.Project, project.Links);
    }

    /// <summary>
    ///     Обновляет проект
    /// </summary>
    /// <param name="project">Данные для обновления проекта</param>
    [HttpPut]
    public void Update(ProjectCreatingDto project)
    {
        _projectManager.Update(project.Project, project.Links ?? Array.Empty<Link>());
    }

    /// <summary>
    ///     Удаляет проект по Id
    /// </summary>
    /// <param name="id">Id проекта</param>
    [HttpDelete("{id:guid}")]
    public void DeleteById(Guid id)
    {
        _projectManager.DeleteById(id);
    }
}