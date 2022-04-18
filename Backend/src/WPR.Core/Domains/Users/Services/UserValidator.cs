using System.Text.RegularExpressions;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using WPR.Core.Domains.Users.Models;

namespace WPR.Core.Domains.Users.Services;

public class UserValidator : AbstractValidator<User>
{
    private readonly string _loginPattern;
    private readonly string _tagPattern;
    
    public UserValidator(IConfiguration configuration)
    {
        var patterns = configuration.GetSection("Patterns");
        _loginPattern = patterns.GetValue<string>("Login");
        _tagPattern = patterns.GetValue<string>("Tag");
        SetRules();
    }

    private void SetRules()
    {
        RuleFor(user => user.Email)
            .NotEmpty()
            .EmailAddress();
        
        RuleFor(user => user.Login)
            .NotEmpty()
            .Must(login => Regex.IsMatch(login, _loginPattern));

        RuleFor(user => user.Tag)
            .NotEmpty()
            .Must(tag => Regex.IsMatch(tag, _tagPattern));
    }
}