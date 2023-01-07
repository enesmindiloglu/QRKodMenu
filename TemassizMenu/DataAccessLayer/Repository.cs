using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        Context context = new Context();
        DbSet<T> _object;

        public Repository()
        {
            _object = context.Set<T>();
        }

        public int Delete(T entity)
        {
            _object.Remove(entity);
            return context.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _object.FirstOrDefault(where);
        }

        public List<T> FindAll(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public T GetById(int id)
        {
            return _object.Find(id);
        }

        public int Insert(T entity)
        {
            _object.Add(entity);
            return context.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public int Update(T entity)
        {
            return context.SaveChanges();
        }
    }
}
