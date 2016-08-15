using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.StringSplitOptions;

namespace BDAvance.DAL
{
        public class GenericRepository<TEntity>
        where TEntity : class
        {
            internal ProjectContext Context;
            internal DbSet<TEntity> DbSet;

            public GenericRepository(ProjectContext context)
            {
                Context = context;
                DbSet = context.Set<TEntity>();
            }

            //filter = lambda for filtring request
            public virtual IEnumerable<TEntity> Get(
                Expression<Func<TEntity, bool>> filter = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                string includeProperties = "")
            {
                IQueryable<TEntity> query = DbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                query = includeProperties.Split(new[] { ',' }, RemoveEmptyEntries)
                    .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

                return orderBy?.Invoke(query).ToList() ?? query.ToList();
            }

            public virtual TEntity GetById(object id)
            {
                return DbSet.Find(id);
            }


            public virtual void Insert(TEntity entity)
            {
                DbSet.Add(entity);
            }
            public virtual void Delete(object id)
            {
                TEntity entityToDelete = DbSet.Find(id);
                Delete(entityToDelete);
            }

            public virtual void Delete(TEntity entityToDelete)
            {
                if (Context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    DbSet.Attach(entityToDelete);
                }
                DbSet.Remove(entityToDelete);
            }

            public virtual void Update(TEntity entityToUpdate)
            {
                DbSet.Attach(entityToUpdate);
                Context.Entry(entityToUpdate).State = EntityState.Modified;
            }

            //**********************************************************************************************************************************************
            //Async function 
            //**********************************************************************************************************************************************
            public virtual Task<TEntity> GetByIdAsync(object id)
            {
                return DbSet.FindAsync(id);
            }

            public virtual async Task<IEnumerable<TEntity>> GetAsync(
                Expression<Func<TEntity, bool>> filter = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                string includeProperties = "")
            {
                IQueryable<TEntity> query = DbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                query = includeProperties.Split(new[] { ',' }, RemoveEmptyEntries)
                    .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

                if (orderBy != null)
                {
                    return await orderBy(query).ToListAsync();
                }
                else
                {
                    return await query.ToListAsync();
                }
            }
            public virtual async Task InsertAsync(TEntity entity)
            {
                await Task.Factory.StartNew(() =>
                {
                    DbSet.Add(entity);
                });
            }
            public virtual async Task DeleteAsync(object id)
            {
                TEntity entityToDelete = await DbSet.FindAsync(id);
                await DeleteAsync(entityToDelete);
            }

            public virtual async Task DeleteAsync(TEntity entityToDelete)
            {
                await Task.Factory.StartNew(() =>
                {
                    if (Context.Entry(entityToDelete).State == EntityState.Detached)
                    {
                        DbSet.Attach(entityToDelete);
                    }
                    DbSet.Remove(entityToDelete);
                });
            }

        }
    }
