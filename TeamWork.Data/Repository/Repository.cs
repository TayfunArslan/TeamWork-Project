using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamWork.Data.Context;

namespace TeamWork.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> GetAll();
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        readonly TeamWorkEntities _context;
        readonly IDbSet<T> _dbSet;

        public Repository(TeamWorkEntities context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
