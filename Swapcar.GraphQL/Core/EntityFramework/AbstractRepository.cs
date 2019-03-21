using Microsoft.EntityFrameworkCore;
using Swapcar.GraphQL.Core.Domain.Model;
using Swapcar.GraphQL.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Swapcar.GraphQL.Core.EntityFramework
{
    public abstract class AbstractRepository<KeyType, Entity> : IRepository<KeyType, Entity> where Entity : class
    {
        protected AppDbContext _ctx { get; } 
        protected DbSet<Entity> _dbSet { get; }

        public AbstractRepository(AppDbContext context)
        {
            _ctx = context;
            _dbSet = _ctx.Set<Entity>();
        }

        public abstract KeyType GetId(Entity e);

        public async Task<Entity> Add(Entity e)
        {
            try
            {
                var addedEntity = await _dbSet.AddAsync(e);
                await _ctx.SaveChangesAsync();

                return addedEntity.Entity;

            } catch (InvalidOperationException ex)
            {
                throw new RepositoryException($"Error attempting to add a new element : {e.ToString()}", ex);
            }
        }

        public async Task<List<Entity>> FindAll()
        {
            try
            {
                return await _dbSet.AsNoTracking().ToListAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new RepositoryException("Error attempting to find all elements", ex);
            }
        }

        public async Task<Entity> FindById(KeyType id)
        {
            try
            {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => GetId(x).Equals(id));
            }
            catch (InvalidOperationException ex)
            {
                throw new RepositoryException($"Error attempting to find element at index {id}", ex);
            }
        }

        public async Task Remove(KeyType id)
        {
            try
            {
                var entityToRemove = await _dbSet.FirstOrDefaultAsync(x => GetId(x).Equals(id));
                _dbSet.Remove(entityToRemove);

                await _ctx.SaveChangesAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new RepositoryException($"Error attempting to remove element at index {id}", ex);
            }
        }

        public async Task<Entity> Update(Entity e)
        {
            try
            {
                var modifiedEntity = _dbSet.Update(e);
                await _ctx.SaveChangesAsync();
               
                return modifiedEntity.Entity;
            }
            catch (InvalidOperationException ex)
            {
                throw new RepositoryException($"Error attempting to add a new element : {e.ToString()}", ex);
            }
        }

        public IQueryable<Entity> FindAllByPredicate(params Expression<Func<Entity, object>>[] includes)
        {
            try
            {
                IQueryable<Entity> set = _dbSet.AsNoTracking();

                foreach (var include in includes)
                {
                    set = set.Include(include);
                }

                return set.AsQueryable<Entity>();
            }
            catch (InvalidOperationException ex)
            {
                throw new RepositoryException("Error attempting to find all elements by predicate", ex);
            }
        }

        public async Task<Entity> FindBy(Expression<Func<Entity, bool>> predicate, params Expression<Func<Entity, object>>[] includes)
        {
            try
            {
                var result = FindAllByPredicate(includes);
                return await result.FirstOrDefaultAsync(predicate);
            }
            catch (InvalidOperationException ex)
            {
                throw new RepositoryException("Error attempting to find elements by predicate", ex);
            }
        }
    }
}
