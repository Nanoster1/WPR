using WPR.Core.Domains.Users.Models;

namespace WPR.Core.Domains.Users.Interfaces;

public interface IPasswordHashProvider
{
    public string GetHash(string password, byte[] salt);
    public HashedPassword CreateHash(string password);
}