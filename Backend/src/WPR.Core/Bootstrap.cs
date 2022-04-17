using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WPR.Core.Domains.Comments.Interfaces;
using WPR.Core.Domains.Comments.Services;
using WPR.Core.Domains.Links.Interfaces;
using WPR.Core.Domains.Links.Services;
using WPR.Core.Domains.Projects.Interfaces;
using WPR.Core.Domains.Projects.Services;
using WPR.Core.Domains.Users.Interfaces;
using WPR.Core.Domains.Users.Services;

namespace WPR.Core;

public static class Bootstrap
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddScoped<IUserManager, UserManager>();
        services.AddScoped<IProjectManager, ProjectManager>();
        services.AddScoped<ILinkManager, LinkManager>();
        services.AddScoped<ICommentManager, CommentManager>();
        services.AddScoped<IPasswordHashProvider, PasswordHashProvider>();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}