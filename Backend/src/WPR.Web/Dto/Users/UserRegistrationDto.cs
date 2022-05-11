namespace WPR.Web.Dto.Users;

public record UserRegistrationDto
(
    string Login,
    string Email,
    string Password,
    string Tag
);