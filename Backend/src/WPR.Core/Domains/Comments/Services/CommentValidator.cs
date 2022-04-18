using FluentValidation;
using WPR.Core.Domains.Comments.Models;

namespace WPR.Core.Domains.Comments.Services;

public class CommentValidator : AbstractValidator<Comment>
{
    public CommentValidator()
    {
        SetRules();
    }

    private void SetRules()
    {
        RuleFor(comment => comment.Content)
            .NotEmpty();

        RuleFor(comment => comment.AuthorId)
            .NotEmpty();

        RuleFor(comment => comment.CreatingDate)
            .NotEmpty();

        RuleFor(comment => comment.ProjectId)
            .NotEmpty();
    }
}