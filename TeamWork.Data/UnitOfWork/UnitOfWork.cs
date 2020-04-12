using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWork.Data.Context;
using TeamWork.Data.Repository;

namespace TeamWork.Data.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        readonly TeamWorkEntities _context;

        public UnitOfWork()
        {
            _context = new TeamWorkEntities();
        }

        public void Dispose()
        {

        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_context);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
