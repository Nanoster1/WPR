using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WPR.Data.Domains.Comments.DbModels;
using WPR.Data.Domains.Projects.DbModels;
using WPR.Data.Domains.Users.DbModels;

namespace WPR.Data.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<CommentDbModel>
{
    public void Configure(EntityTypeBuilder<CommentDbModel> builder)
    {
        builder.ToTable("comment");
        builder.HasKey(model => model.Id);

        builder.Property(model => model.Content).IsRequired();
        builder.Property(model => model.AuthorId).IsRequired();
        builder.Property(model => model.CreatingDate).IsRequired();
        builder.Property(model => model.ProjectId).IsRequired();

        builder.HasOne<UserDbModel>()
            .WithMany()
            .HasForeignKey(model => model.AuthorId);
        
        builder.HasOne<ProjectDbModel>()
            .WithMany()
            .HasForeignKey(model => model.ProjectId);
    }
}