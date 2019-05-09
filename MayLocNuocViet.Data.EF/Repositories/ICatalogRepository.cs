using Fsoft.SKU.CoreApp.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Fsoft.SKU.CoreApp.Data.EF.Repositories
{
    public interface ICatalogRepository : DatabaseUtility.EntityFramework.Repositories.IRepository<Catalog>
    {
        IQueryable<Catalog> GetChildren(int id);
    }
}
