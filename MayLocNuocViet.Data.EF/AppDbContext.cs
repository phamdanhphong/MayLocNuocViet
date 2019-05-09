using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using MLT.MayLocNuocViet.Infrastructure;
using MLT.MayLocNuocViet.Data.Entities;

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

       
        public DbSet<EmailAccount> EmailAccount { get; set; }

        public DbSet<Catalog> Catalog { set; get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EmailAccount>().ToTable("Core_EmailAccount");
            base.OnModelCreating(builder);
        }
      
    }


}
