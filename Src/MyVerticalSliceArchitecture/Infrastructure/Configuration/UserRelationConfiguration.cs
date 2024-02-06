using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyVerticalSliceArchitecture.Entities;

namespace MyVerticalSliceArchitecture.Infrastructure.Configuration
{
    public class UserRelationConfiguration : IEntityTypeConfiguration<UserRelations>, IEntityConfiguration
    {
        public void Configure(EntityTypeBuilder<UserRelations> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(p => p.User).WithMany(c => c.UserRelations).HasForeignKey(p => p.UserId);
            builder.HasOne(p => p.User).WithMany(c => c.UserRelations).HasForeignKey(p => p.FollowUserId);
            builder.HasIndex(p => new { p.UserId, p.FollowUserId }).IsUnique();
        }
    }
}
