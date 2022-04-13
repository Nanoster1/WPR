using Microsoft.EntityFrameworkCore;
using WPR.Core.Domains.Users.Interfaces;
using WPR.Core.Domains.Users.Models;
using WPR.Data.Domains.Users.DbModels;

namespace WPR.Data.Domains.Users.Repositories;

public class UserRepository : IUserRepository
{
    private readonly WprDbContext _context;

    public UserRepository(WprDbContext context)
    {
        _context = context;
    }

    public User GetById(Guid id)
    {
        var model = GetModelById(id);
        return new User
        {
            Id = model.Id,
            Email = model.Email,
            Login = model.Login,
            Tag = model.Tag
        };
    }

    public User GetByTag(string tag)
    {
        var model = _context.Users.AsNoTracking().FirstOrDefault(model => model.Tag == tag);

        if (model == null)
            throw new NullReferenceException();

        return new User
        {
            Id = model.Id,
            Email = model.Email,
            Login = model.Login,
            Tag = model.Tag
        };
    }

    public void Update(User user)
    {
        var model = GetModelById(user.Id, true);
        model.Login = user.Login;
        model.Email = user.Email;
        model.Tag = user.Tag;
    }

    public void DeleteById(Guid id)
    {
        var model = GetModelById(id);
        _context.Users.Remove(model);
    }

    public Guid Create(User user)
    {
        var model = new UserDbModel
        {
            Login = user.Login,
            Email = user.Email,
            Tag = user.Tag
        };
        _context.Users.Add(model);
        return model.Id;
    }

    private UserDbModel GetModelById(Guid id, bool isTracking = false)
    {
        var model = isTracking
            ? _context.Users.FirstOrDefault(dbModel => dbModel.Id == id)
            : _context.Users.AsNoTracking().FirstOrDefault(dbModel => dbModel.Id == id);

        if (model == null)
            throw new NullReferenceException();

        return model;
    }
}