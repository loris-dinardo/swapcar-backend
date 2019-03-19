using GraphQL;
using GraphQL.Types;
using Swapcar.GraphQL.Dicos.Api.GraphQL.Queries;

namespace Swapcar.GraphQL.Dicos.Api.GraphQL.Schemas
{
    public class CarSchema : Schema
    {
        public CarSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<CarQuery>();
        }
    }
}
