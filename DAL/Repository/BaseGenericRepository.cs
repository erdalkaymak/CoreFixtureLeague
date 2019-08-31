using DAL.Model;
using DAL.Model.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositorys
{
    public class BaseGenericRepository<T> : IBaseRepository<T> where T : Base
    {
        protected FixtureDemoContext _db = new FixtureDemoContext();

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            _db.SaveChanges();
        }

        public T Find(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
           return _db.Set<T>().ToList();
        }

        public virtual void Insert(T entity)
        {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
        }

        public void Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
