using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WPR.Core.Domains.Comments.Interfaces;
using WPR.Core.Domains.Links.Interfaces;
using WPR.Core.Domains.Projects.Interfaces;
using WPR.Core.Domains.Users.Interfaces;
using WPR.Core.UnitsOfWork;
using WPR.Data.Domains.Comments.Repositories;
using WPR.Data.Domains.Links.Repositories;
using WPR.Data.Domains.Projects.Repositories;
using WPR.Data.Domains.Users.Repositories;
using WPR.Data.UnitsOfWork;

namespace WPR.Data;

public static class Bootstrap
{
    public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<WprDbContext>(builder => builder
            .UseNpgsql(configuration.GetConnectionString("Database"))
            .UseSnakeCaseNamingConvention());
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<ILinkRepository, LinkRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}