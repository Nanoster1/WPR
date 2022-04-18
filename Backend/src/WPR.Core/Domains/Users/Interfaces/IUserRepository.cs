using WPR.Core.Domains.Users.Models;

namespace WPR.Core.Domains.Users.Interfaces;

public interface IUserRepository
{
    User GetById(Guid id);
    User GetByTag(string tag);
    User[] GetByIds(Guid[] ids);
    Guid Create(User user, string password);
    void Update(User user);
    void DeleteById(Guid id);
}