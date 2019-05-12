using Fsoft.SKU.CoreApp.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MLT.MayLocNuocViet.Utilities.Configurations;

namespace MLT.MayLocNuocViet.Data.EF
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = AppSettings.ConnectString;
            builder.UseSqlServer(connectionString);
            return new AppDbContext(builder.Options);
        }
    }
}
