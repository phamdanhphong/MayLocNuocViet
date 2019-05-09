using MLT.MayLocNuocViet.Infrastructure.Interfaces;
using System;
using System.Collections;

namespace MLT.MayLocNuocViet.Infrastructure.Implementation
{
    public class EFUnitOfWork : IEFUnitOfWork
    {
        private readonly IEFDbContext _context;
        private bool _disposed;
        private Hashtable _repositories;

        public EFUnitOfWork(IEFDbContext context)
        {
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();

            _disposed = true;
        }

        public IEFRepository<TEntity> EFRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (_repositories.ContainsKey(type)) return (IEFRepository<TEntity>)_repositories[type];

            var repositoryType = typeof(EFRepository<>);

            var repositoryInstance =
                Activator.CreateInstance(repositoryType
                    .MakeGenericType(typeof(TEntity)), _context);

            _repositories.Add(type, repositoryInstance);

            return (IEFRepository<TEntity>)_repositories[type];
        }

    }
}
