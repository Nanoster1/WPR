using Microsoft.AspNetCore.Mvc;
using WPR.Core.Domains.Comments.Interfaces;
using WPR.Core.Domains.Comments.Models;
using WPR.Web.Dto.Comments;

namespace WPR.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentManager _commentManager;

    public CommentController(ICommentManager commentManager)
    {
        _commentManager = commentManager;
    }

    /// <summary>
    ///     Возвращает комментарии по Id проекта
    /// </summary>
    /// <param name="id">Id проекта</param>
    /// <returns>Массив моделей комментария</returns>
    [HttpGet("proj/{id:guid}")]
    public CommentDto[] GetByProjectId(Guid id)
    {
        var models = _commentManager.GetByProjectId(id);
        return models.Select(comment =>
        {
            return new CommentDto(
                comment.Id,
                comment.AuthorId,
                string.Empty,
                comment.Content,
                comment.CreatingDate);
        }).ToArray();
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
        return new CommentDto(
            model.Id,
            model.AuthorId,
            string.Empty,
            model.Content,
            model.CreatingDate);
    }

    /// <summary>
    ///     Возвращает комментарии по Id автора
    /// </summary>
    /// <param name="id">Id автора</param>
    /// <returns>Массив моделей комментария</returns>
    [HttpGet("usr/{id:guid}")]
    public CommentDto[] GetByAuthorId(Guid id)
    {
        var models = _commentManager.GetByAuthorId(id);
        return models.Select(comment => new CommentDto(
                comment.Id,
                comment.AuthorId,
                string.Empty,
                comment.Content,
                comment.CreatingDate))
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