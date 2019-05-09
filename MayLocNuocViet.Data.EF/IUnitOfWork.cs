using   Fsoft.SKU.CoreApp.Data.EF.Repositories;
using   Fsoft.SKU.CoreApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace  Fsoft.SKU.CoreApp.Data.EF
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Call save change from db context
        /// </summary>
        void Commit();
    }
}
