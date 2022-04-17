namespace WPR.Web.Dto.Users;

public record UserDto
(
    Guid Id,
    string Tag,
    string Login,
    string Email
);