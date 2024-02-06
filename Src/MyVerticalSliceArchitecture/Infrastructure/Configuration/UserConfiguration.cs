using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyVerticalSliceArchitecture.Entities;

namespace MyVerticalSliceArchitecture.Infrastructure.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>, IEntityConfiguration
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        //builder.HasOne(p => p.Customer).WithMany(c => c.Order).HasForeignKey(p => p.CustomerId);
    }
}
