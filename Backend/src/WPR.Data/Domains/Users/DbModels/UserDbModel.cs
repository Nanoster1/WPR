namespace WPR.Data.Domains.Users.DbModels;

public class UserDbModel
{
    public Guid Id { get; set; }
    public string Tag { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public byte[] Salt { get; set; }
}