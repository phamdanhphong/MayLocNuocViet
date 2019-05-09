using Fsoft.SKU.CoreApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Fsoft.SKU.CoreApp.Data.EF.Repositories
{
    public class CatalogRepository : DatabaseUtility.EntityFramework.Repositories.Repository<Catalog>, ICatalogRepository
    {
     
      
    }
}
