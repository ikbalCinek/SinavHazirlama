using Core.DataAccess.Abstract;
using DataAccess.Concrete.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Transactions;

namespace DataAccess.Concrete
{
    public abstract class BaseDal<T> : IBaseDal<T> where T : class
    {
        private readonly ExamContext _context;

        public BaseDal(ExamContext context)
        {
            _context = context;
        }

        public virtual bool Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return Save() > 0;
        }

        public bool Add(List<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            return Save() > 0;
        }

        public bool Any(Expression<Func<T, bool>> expression) => _context.Set<T>().Any(expression);


        public virtual bool Delete(T entity)  //TODO:CHECK
        {
            _context.Set<T>().Remove(entity);
            return Save() > 0;
        }

        public bool Delete(int id)
        {
            using (TransactionScope ts=new TransactionScope())
            {
                T deleted = GetByID(id);
                _context.Set<T>().Remove(deleted);
                return Save() > 0;
            }
        }

       

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).FirstOrDefault();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? _context.Set<T>().ToList() : _context.Set<T>().Where(expression).ToList();
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public bool Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return Save() > 0;
        }
    }

   
}

