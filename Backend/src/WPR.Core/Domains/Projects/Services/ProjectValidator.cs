using FluentValidation;
using WPR.Core.Domains.Projects.Models;

namespace WPR.Core.Domains.Projects.Services;

public class ProjectValidator : AbstractValidator<Project>
{
    public ProjectValidator()
    {
        SetRules();
    }

    private void SetRules()
    {
        RuleFor(project => project.Name)
            .NotEmpty();

        RuleFor(project => project.Rating)
            .InclusiveBetween(0, 100);

        RuleFor(project => project.AuthorId)
            .NotEmpty();

        RuleFor(project => project.LongDesc)
            .NotEmpty();

        RuleFor(project => project.ShortDesc)
            .NotEmpty();
    }
}