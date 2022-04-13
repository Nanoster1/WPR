using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WPR.Data.Domains.Projects.DbModels;
using WPR.Data.Domains.Users.DbModels;

namespace WPR.Data.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<ProjectDbModel>
{
    public void Configure(EntityTypeBuilder<ProjectDbModel> builder)
    {
        builder.ToTable("project");
        builder.HasKey(model => model.Id);

        builder.Property(model => model.AuthorId).IsRequired();
        builder.Property(model => model.Name).IsRequired();
        builder.Property(model => model.Rating).IsRequired();

        builder.HasOne<UserDbModel>()
            .WithMany()
            .HasForeignKey(model => model.AuthorId);
    }
}