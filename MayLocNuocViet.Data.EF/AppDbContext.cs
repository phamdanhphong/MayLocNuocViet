using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using MLT.MayLocNuocViet.Infrastructure;
using MLT.MayLocNuocViet.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;

namespace Fsoft.SKU.CoreApp.Data.EF
{
    public class AppDbContext : DbContext, IEFDbContext
    {
        private string _currentUser;
        private readonly IHttpContextAccessor _context;

        public AppDbContext() : base()
        {
        }

        public AppDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _context = httpContextAccessor;
        }
       
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Position> Position { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<EmployeeRole> EmployeeRole { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Identity Config

            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims").HasKey(x => x.Id);

            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims")
                .HasKey(x => x.Id);

            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins").HasKey(x => x.UserId);

            builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles")
                .HasKey(x => new { x.RoleId, x.UserId });

            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens")
               .HasKey(x => new { x.UserId });

            #endregion Identity Config

            base.OnModelCreating(builder);
        }
      
    }


}
