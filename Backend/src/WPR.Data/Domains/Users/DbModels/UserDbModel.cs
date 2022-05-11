using WPR.Core.Domains.Users.Models;

namespace WPR.Data.Domains.Users.DbModels;

public class UserDbModel : IDbModel<UserDbModel, User>
{
    public Guid Id { get; set; }
    public string Tag { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public byte[] Salt { get; set; }

    public static UserDbModel FromBusinessModel(User businessModel)
    {
        return new UserDbModel
        {
            Email = businessModel.Email,
            Login = businessModel.Login,
            Tag = businessModel.Tag
        };
    }

    public User ToBusinessModel()
    {
        return new User(Id, Email, Login, Tag);
    }
}