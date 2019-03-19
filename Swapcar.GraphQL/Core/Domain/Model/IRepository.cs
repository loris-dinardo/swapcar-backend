using System.Collections.Generic;

namespace Swapcar.GraphQL.Core.Domain.Model
{
    public interface IRepository<KeyType, Entity>
    {
        Entity Add(Entity e);

        void Remove(KeyType id);

        Entity FindById(KeyType id);

        List<Entity> FindAll();

        Entity Update(Entity e);
    }
}
