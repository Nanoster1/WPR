namespace WPR.Core.Domains.Users.Models;

public class User
{
    public Guid Id { get; set; }
    public string Tag { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
}