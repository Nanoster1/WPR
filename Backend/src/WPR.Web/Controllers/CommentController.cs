using Microsoft.AspNetCore.Mvc;
using WPR.Core.Domains.Comments.Interfaces;
using WPR.Core.Domains.Comments.Models;
using WPR.Core.Domains.Users.Interfaces;
using WPR.Web.Dto.Comments;

namespace WPR.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentManager _commentManager;
    private readonly IUserManager _userManager;

    public CommentController(ICommentManager commentManager, IUserManager userManager)
    {
        _commentManager = commentManager;
        _userManager = userManager;
    }

    /// <summary>
    ///     Возвращает комментарии по Id проекта
    /// </summary>
    /// <param name="id">Id проекта</param>
    /// <param name="startIndex">Начальный индекс выдачи комментариев</param>
    /// <param name="quantity">Кол-во комментариев</param>
    /// <returns>Массив моделей комментария</returns>
    [HttpGet("proj/{id:guid}:{startIndex:int}:{quantity:int}")]
    public CommentDto[] GetByProjectId(Guid id, int startIndex, int quantity)
    {
        var models = _commentManager.GetByProjectId(id);
        var users = _userManager.GetManyById(
            models.Select(comment => comment.AuthorId).ToArray(),
            startIndex, quantity);
        var i = 0;
        return models
            .Select(comment => new CommentDto(
                comment.Id,
                comment.AuthorId,
                users[i++].Login,
                comment.Content,
                comment.CreatingDateTime,
                comment.ParentId))
            .ToArray();
    }

    /// <summary>
    ///     Возвращает комментарий по Id
    /// </summary>
    /// <param name="id">Id комментария</param>
    /// <returns>Модель комментария</returns>
    [HttpGet("{id:guid}")]
    public CommentDto GetById(Guid id)
    {
        var model = _commentManager.GetById(id);
        var user = _userManager.GetById(model.AuthorId);
        return new CommentDto(
            model.Id,
            model.AuthorId,
            user.Login,
            model.Content,
            model.CreatingDateTime);
    }

    /// <summary>
    ///     Возвращает комментарии по Id автора
    /// </summary>
    /// <param name="id">Id автора</param>
    /// <returns>Массив моделей комментария</returns>
    [HttpGet("usr/{id:guid}:{startIndex:int}:{quantity:int}")]
    public CommentDto[] GetByAuthorId(Guid id, int startIndex, int quantity)
    {
        var models = _commentManager.GetByAuthorId(id);
        var users = _userManager.GetManyById(models.Select(comment => comment.AuthorId).ToArray());
        var i = 0;
        return models.Select(comment => new CommentDto(
                comment.Id,
                comment.AuthorId,
                users[i++].Login,
                comment.Content,
                comment.CreatingDateTime))
            .ToArray();
    }

    /// <summary>
    ///     Возвращает массив комментариев для родительского комментария
    /// </summary>
    /// <param name="id">Id родительского комментария</param>
    /// <param name="startIndex">Начальный индекс</param>
    /// <param name="quantity">Кол-во комментариев</param>
    /// <returns></returns>
    [HttpGet("parent/{id:guid}:{startIndex:int}:{quantity:int}")]
    public CommentDto[] GetByParentId(Guid id, int startIndex, int quantity)
    {
        var models = _commentManager.GetByParentId(id);
        var users = _userManager.GetManyById(models.Select(comment => comment.AuthorId).ToArray());
        var i = 0;
        return models.Select(comment => new CommentDto(
                comment.Id,
                comment.AuthorId,
                users[i++].Login,
                comment.Content,
                comment.CreatingDateTime))
            .ToArray();
    }

    /// <summary>
    ///     Создаёт новый комментарий
    /// </summary>
    /// <param name="comment">Модель комментария</param>
    /// <returns>Id созданного комментария</returns>
    [HttpPost]
    public Guid Create(Comment comment)
    {
        return _commentManager.Create(comment);
    }

    /// <summary>
    ///     Изменить контент комментария
    /// </summary>
    /// <param name="id">Id комментария</param>
    /// <param name="content">Новый контент комментария</param>
    [HttpPatch("{id:guid}")]
    public void UpdateContentById(Guid id, string content)
    {
        _commentManager.UpdateContentById(id, content);
    }

    /// <summary>
    ///     Удаляет комментарий
    /// </summary>
    /// <param name="id">Id комментария</param>
    [HttpDelete]
    public void DeleteById(Guid id)
    {
        _commentManager.DeleteById(id);
    }
}