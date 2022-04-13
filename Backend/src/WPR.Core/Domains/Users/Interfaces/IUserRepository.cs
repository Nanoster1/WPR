using WPR.Core.Domains.Users.Models;

namespace WPR.Core.Domains.Users.Interfaces;

public interface IUserRepository
{
    User GetById(Guid id);
    User GetByTag(string tag);
    Guid Create(User user);
    void Update(User user);
    void DeleteById(Guid id);
}