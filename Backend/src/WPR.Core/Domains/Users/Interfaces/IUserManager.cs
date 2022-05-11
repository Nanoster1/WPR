using WPR.Core.Domains.Users.Models;

namespace WPR.Core.Domains.Users.Interfaces;

public interface IUserManager
{
    User GetById(Guid id);
    User GetByTag(string tag);
    User[] GetManyById(Guid[] ids, int startIndex = 0, int quantity = -1);
    Guid Create(User user, string password);
    void Update(User user);
    void DeleteById(Guid id);
}