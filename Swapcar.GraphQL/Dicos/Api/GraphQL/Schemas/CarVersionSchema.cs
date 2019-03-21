using GraphQL;
using GraphQL.Types;
using Swapcar.GraphQL.Dicos.Api.GraphQL.Queries;

namespace Swapcar.GraphQL.Dicos.Api.GraphQL.Schemas
{
    public class CarVersionSchema : Schema
    {
        public CarVersionSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<CarVersionQuery>();
            Mutation = resolver.Resolve<CarVersionMutation>();
        }
    }
}
