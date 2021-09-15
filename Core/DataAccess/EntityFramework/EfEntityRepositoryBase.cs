using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity:class,IEntity,new()
        where TContext:DbContext,new() 
    {
        //TContext _context;
        //DbSet<TEntity> _dbSet;

        //public EfEntityRepositoryBase(TContext context)
        //{
        //    _context = context;
        //    _dbSet = _context.Set<TEntity>();
        //}

        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //TContext context = new TContext();
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                //_dbSet.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
               // _dbSet.Remove(entity);
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //TContext context = new TContext();
                return filter == null ?
                    context.Set<TEntity>().ToList() :
                    context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                //_dbSet.Update(entity);
                context.SaveChanges();
            }
        }
    }
}
