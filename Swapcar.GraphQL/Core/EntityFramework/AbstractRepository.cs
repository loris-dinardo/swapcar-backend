using Swapcar.GraphQL.Core.Domain.Model;
using Swapcar.GraphQL.Core.Exceptions;
using System;
using System.Collections.Generic;

namespace Swapcar.GraphQL.Core.EntityFramework
{
    public abstract class AbstractRepository<KeyType, Entity> : IRepository<KeyType, Entity>
    {
        protected DbContext _ctx { get; } 

        public AbstractRepository(DbContext context)
        {
            _ctx = context;
        }

        public abstract KeyType GetId(Entity e);

        public Entity Add(Entity e)
        {
            try
            {
                /*
                KeyType k = GetId(e);
                _ctx.DbSet(typeof(Entity)).Add(e);

                return _ctx.DbSet(e).FirstOrDefault(x => x.GetId().Equals(k));
                */
                return default(Entity);

            } catch (ArgumentException ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public List<Entity> FindAll()
        {
            try
            {
                return _ctx.DbSet(typeof(Entity)) as List<Entity>;

            }
            catch (ArgumentException ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public Entity FindById(KeyType id)
        {
            try
            {
                return default(Entity);//_ctx.DbSet(typeof(Entity)).FirstOrDefault(x => x.GetId().Equals(id));
            }
            catch (ArgumentException ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public void Remove(KeyType id)
        {
            try
            {
                //Entity e = _ctx.DbSet(typeof(Entity)).FirstOrDefault(x => x.GetId().Equals(id));
                //_ctx.DbSet(typeof(Entity)).Remove(e);

            }
            catch (ArgumentException ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public Entity Update(Entity e)
        {
            try
            {
                /*
                KeyType k = GetId(e);
                var index = _ctx.DbSet(typeof(Entity)).FindIndex(x => GetId(x).Equals(k));

                if (index >= 0)
                {
                    _ctx.DbSet(typeof(Entity))[index] = e;
                }

                return e;
                */
                return default(Entity);
            }
            catch (ArgumentException ex)
            {
                throw new RepositoryException(ex);
            }
        }
    }
}
