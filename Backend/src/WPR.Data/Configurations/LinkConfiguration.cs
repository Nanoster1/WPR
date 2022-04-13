using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WPR.Data.Domains.Links.DbModels;
using WPR.Data.Domains.Projects.DbModels;

namespace WPR.Data.Configurations;

public class LinkConfiguration : IEntityTypeConfiguration<LinkDbModel>
{
    public void Configure(EntityTypeBuilder<LinkDbModel> builder)
    {
        builder.ToTable("link");
        builder.HasKey(model => model.Id);

        builder.Property(model => model.Type).IsRequired();
        builder.Property(model => model.Url).IsRequired();
        builder.Property(model => model.ProjectId).IsRequired();

        builder.HasOne<ProjectDbModel>()
            .WithMany()
            .HasForeignKey(model => model.ProjectId);
    }
}