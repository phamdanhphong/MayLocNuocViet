using Microsoft.EntityFrameworkCore;

namespace MLT.MayLocNuocViet.Infrastructure
{
    public interface IEFDbContext
    {
        DbSet<T> Set<T>() where T : class;

        int SaveChanges();

        void Dispose();
    }
}
