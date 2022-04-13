using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WPR.Data.Domains.Users.DbModels;

namespace WPR.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserDbModel>
{
    public void Configure(EntityTypeBuilder<UserDbModel> builder)
    {
        builder.ToTable("user");
        builder.HasKey(model => model.Id);
        builder.HasAlternateKey(model => model.Tag);
        
        builder.Property(model => model.Tag).IsRequired();
        builder.Property(model => model.Email).IsRequired();
    }
}