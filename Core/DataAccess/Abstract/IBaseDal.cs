using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.Abstract
{
    public interface IBaseDal<T>
    {
        bool Add(T entity);
        bool Add(List<T> entities);
        bool Delete(T entity);
        bool Delete(int id);
       
        bool Update(T entity);
        T Get(Expression<Func<T, bool>> expression);
        T GetByID(int id);
        List<T> GetAll(Expression<Func<T, bool>> expression = null);
        bool Any(Expression<Func<T, bool>> expression);
        int Save();
    }
}
