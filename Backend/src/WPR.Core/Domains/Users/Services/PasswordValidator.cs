using System.Text.RegularExpressions;
using FluentValidation;
using Microsoft.Extensions.Configuration;

namespace WPR.Core.Domains.Users.Services;

public class PasswordValidator : AbstractValidator<string>
{
    private readonly string _passwordPattern;
    
    public PasswordValidator(IConfiguration configuration)
    {
        var patterns = configuration.GetSection("Patterns");
        _passwordPattern = patterns.GetValue<string>("Password");
        SetRules();
    }
    
    private void SetRules()
    {
        RuleFor(password => password)
            .NotEmpty()
            .Must(password => Regex.IsMatch(password, _passwordPattern))
            .WithName("Password");
    }
}