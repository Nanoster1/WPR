using Microsoft.EntityFrameworkCore;
using WPR.Data.Domains.Comments.DbModels;
using WPR.Data.Domains.Links.DbModels;
using WPR.Data.Domains.Projects.DbModels;
using WPR.Data.Domains.Users.DbModels;

namespace WPR.Data;

public class WprDbContext : DbContext
{
    public WprDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<UserDbModel> Users { get; set; }
    public DbSet<ProjectDbModel> Projects { get; set; }
    public DbSet<LinkDbModel> Links { get; set; }
    public DbSet<CommentDbModel> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WprDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}