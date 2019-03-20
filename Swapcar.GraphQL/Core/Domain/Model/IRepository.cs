using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Swapcar.GraphQL.Core.Domain.Model
{
    public interface IRepository<KeyType, Entity>
    {
        Task<Entity> Add(Entity e);

        void Remove(KeyType id);

        Task<Entity> FindById(KeyType id);

        Task<List<Entity>> FindAll();

        Task<Entity> Update(Entity e);

        IQueryable<Entity> FindAllByPredicate(params Expression<Func<Entity, object>>[] includes);

        Task<Entity> FindBy(Expression<Func<Entity, bool>> predicate, params Expression<Func<Entity, object>>[] includes);
    }
}
