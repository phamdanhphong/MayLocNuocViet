using System;
using System.Collections.Generic;
using System.Text;
using   Fsoft.SKU.CoreApp.Data.EF.Repositories;
using   Fsoft.SKU.CoreApp.Data.Entities;

namespace  Fsoft.SKU.CoreApp.Data.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
