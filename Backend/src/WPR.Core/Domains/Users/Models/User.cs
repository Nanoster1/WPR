namespace WPR.Core.Domains.Users.Models;

public class User
{
    public User(Guid id, string email, string login, string tag)
    {
        Id = id;
        Email = email;
        Login = login;
        Tag = tag;
    }

    public Guid Id { get; set; }
    public string Tag { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
}