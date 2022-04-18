using Microsoft.AspNetCore.Mvc;
using WPR.Core.Domains.Users.Interfaces;
using WPR.Core.Domains.Users.Models;
using WPR.Web.Dto.Users;

namespace WPR.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserManager _userManager;

    public UserController(IUserManager userManager)
    {
        _userManager = userManager;
    }

    /// <summary>
    ///     Получает пользователя по Id
    /// </summary>
    /// <param name="id">Id пользователя</param>
    /// <returns>Пользователь с указанным Id</returns>
    [HttpGet("{id:guid}")]
    public UserDto GetById(Guid id)
    {
        var dbModel = _userManager.GetById(id);
        return new UserDto(dbModel.Id, dbModel.Tag, dbModel.Login, dbModel.Email);
    }

    /// <summary>
    ///     Создаёт пользователя
    /// </summary>
    /// <param name="model">Модель с регистрационными данными</param>
    /// <returns>Id созднанного пользователя</returns>
    [HttpPost]
    public Guid Create(UserRegistrationDto model)
    {
        var user = new User(Guid.Empty, model.Email, model.Login, model.Tag);
        return _userManager.Create(user, model.Password);
    }

    /// <summary>
    ///     Обновляет данные у пользователя с указанным Id
    /// </summary>
    /// <param name="id">Id пользователя</param>
    /// <param name="user">Данные для обновления</param>
    [HttpPut("{id:guid}")]
    public void Update(Guid id, User user)
    {
        _userManager.Update(user);
    }

    /// <summary>
    ///     Удаляет пользователя по Id
    /// </summary>
    /// <param name="id">Id пользователя</param>
    [HttpDelete("{id:guid}")]
    public void DeleteById(Guid id)
    {
        _userManager.DeleteById(id);
    }
}