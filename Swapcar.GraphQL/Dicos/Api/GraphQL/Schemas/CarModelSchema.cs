using GraphQL;
using GraphQL.Types;
using Swapcar.GraphQL.Dicos.Api.GraphQL.Queries;

namespace Swapcar.GraphQL.Dicos.Api.GraphQL.Schemas
{
    public class CarModelSchema : Schema
    {
        public CarModelSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<CarModelQuery>();
            Mutation = resolver.Resolve<CarModelMutation>();
        }
    }
}
