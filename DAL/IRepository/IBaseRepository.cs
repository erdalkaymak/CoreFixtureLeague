using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model.IRepository
{
   public  interface IBaseRepository <T> where T : Base
    {
         void Insert(T entity);
         void Delete(T entity);
         void Update(T entity);
         T Find(int id);
         List<T> GetAll();
    }
}
