using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User.Domain.Entities;

namespace User.Infrastructure.Data.Configurations
{
    public class UserProfileConfiguration:IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            // 表名
            builder.ToTable("UserProfiles");

            // 主键
            builder.HasKey(p => p.Id);
        }
    }
}
