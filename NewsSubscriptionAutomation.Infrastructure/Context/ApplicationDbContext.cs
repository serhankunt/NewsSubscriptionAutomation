using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsSubscriptionAutomation.Domain.Models;

namespace NewsSubscriptionAutomation.Infrastructure.Context;

public sealed class ApplicationDbContext : IdentityDbContext<AppUser,AppRole,Guid>
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<AppRole> AppRoles { get; set; }
    public DbSet<NewsPaper> NewsPapers { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<AppUserNewsPaper> AppUserNewsPapers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Ignore<IdentityUserLogin<Guid>>();
        builder.Ignore<IdentityRoleClaim<Guid>>();
        builder.Ignore<IdentityUserClaim<Guid>>();
        builder.Ignore<IdentityUserToken<Guid>>();
        builder.Ignore<IdentityUserRole<Guid>>();

        builder.Entity<AppUser>()
            .HasMany(u => u.Subscriptions)
            .WithOne(s => s.User)
            .HasForeignKey(s => s.AppUserId);

        builder.Entity<AppUserNewsPaper>()
           .HasKey(un => new { un.AppUserId, un.NewsPaperId });

        builder.Entity<AppUserNewsPaper>()
            .HasOne(un => un.AppUser)
            .WithMany(u => u.UserNewsPapers)
            .HasForeignKey(un => un.AppUserId);

        builder.Entity<AppUserNewsPaper>()
            .HasOne(un => un.NewsPaper)
            .WithMany(np => np.UserNewsPapers)
            .HasForeignKey(un => un.NewsPaperId);

    }

}

