using Bbk.Data.EntityConfiguration;
using Bbk.Data.EntityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bbk.Data.EntityFramework
{
    public class BBKDbContext : IdentityDbContext<AppUsers, AppRoles, Guid>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new AppRolesConfiguration());
            modelBuilder.ApplyConfiguration(new AppUsersConfiguration());
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasNoKey();
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasNoKey();
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasNoKey();
        }

        public BBKDbContext(DbContextOptions<BBKDbContext> options)
       : base(options)
        {

        }


        public DbSet<Product> Products { get; set; }
    }
}
