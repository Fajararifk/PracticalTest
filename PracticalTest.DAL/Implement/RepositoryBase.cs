using Microsoft.EntityFrameworkCore;
using PracticalTest.BusinessObjects;
using PracticalTest.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.DAL
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected PracticalTest_DBContext _dbContext;

        protected RepositoryBase(PracticalTest_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }
        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public IQueryable<T> FindAll() =>
            _dbContext.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition) =>
            _dbContext.Set<T>().Where(condition).AsNoTracking();

    }
}
