using Microsoft.EntityFrameworkCore;
using MyVerticalSliceArchitecture.Entities;
using MyVerticalSliceArchitecture.Infrastructure;

namespace MyVerticalSliceArchitecture.Data;

public class AppDbContext: DbContext
{




    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    #region DbSet Section
    public DbSet<User> Users => Set<User>();
    public DbSet<UserRelations> UserRelations => Set<UserRelations>();
    #endregion
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        ///Assembly All Entity Configuration///
        builder.ApplyConfigurationsFromAssembly(typeof(IEntityConfiguration).Assembly);

    }

}
