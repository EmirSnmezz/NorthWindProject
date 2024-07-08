using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete
{
    public class EfEntityRepository<T, TContext> : IEntityRepository<T> 
        where T : class, IEntity, new()
        where TContext : DbContext, new()
    {
        TContext _dbContext;
        public EfEntityRepository(TContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        public void Add(T entity)
        {
            var addedEntity = _dbContext.Entry(entity);
            addedEntity.State = EntityState.Added;
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            var deletedEntity = _dbContext.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null 
                ? _dbContext.Set<T>().ToList()
                : _dbContext.Set<T>().Where(filter).ToList();
        }

        public T GetById(int id)
        {
            var result = _dbContext.Set<T>().Find(id);
            return result;
        }

        //public List<T> GetByName(string name)
        //{
        //    var result = _dbContext.Set<T>().Where( t => t == name);
        //}

        public void Update(T entity)
        {
            var updatedEntity = _dbContext.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        //public List<T> GetById(int id)
        //{

        //}

        //public List<T> GetByName(string name)
        //{

        //}

    }
}

