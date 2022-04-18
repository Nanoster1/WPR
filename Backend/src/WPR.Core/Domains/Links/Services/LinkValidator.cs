using System.Text.RegularExpressions;
using FluentValidation;
using WPR.Core.Domains.Links.Models;

namespace WPR.Core.Domains.Links.Services;

public class LinkValidator : AbstractValidator<Link>
{
    public LinkValidator()
    {
        SetRules();
    }
    
    private void SetRules()
    {
        RuleFor(link => link.Title)
            .NotEmpty();

        RuleFor(link => link.Type)
            .IsInEnum();

        RuleFor(link => link.Url)
            .NotNull();

        RuleFor(link => link.ProjectId)
            .NotEmpty();
    }
}