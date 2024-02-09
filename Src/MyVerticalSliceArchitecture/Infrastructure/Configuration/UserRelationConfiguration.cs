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
            builder.HasOne(p => p.User).WithMany(c => c.UserRelations).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.User2).WithMany(c => c.UserRelations2).HasForeignKey(p => p.FollowUserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasIndex(p => new { p.UserId, p.FollowUserId }).IsUnique();
        }
    }
}
