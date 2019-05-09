using System;

namespace MLT.MayLocNuocViet.Infrastructure.Interfaces
{
    public interface IEFUnitOfWork : IDisposable
    {
        /// <summary>
        /// Call save change from db context
        /// </summary>
        void Commit();
    }
}
