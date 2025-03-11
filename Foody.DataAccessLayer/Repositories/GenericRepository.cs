using Foody.DataAccessLayer.Abstract;
using Foody.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly FoodyContext _context;

        public GenericRepository(FoodyContext context)
        {
            _context = context;
        }

        void IGenericDal<T>.Delete(int id)
        {
            var value = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(value);
            _context.SaveChanges();
        }

        List<T> IGenericDal<T>.GetAll()
        {
            return _context.Set<T>().ToList();
        }

        T IGenericDal<T>.GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        void IGenericDal<T>.Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        void IGenericDal<T>.Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
