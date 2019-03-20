using GraphQL;
using GraphQL.Types;
using Swapcar.GraphQL.Dicos.Api.GraphQL.Queries;

namespace Swapcar.GraphQL.Dicos.Api.GraphQL.Schemas
{
    public class CarBrandSchema : Schema
    {
        public CarBrandSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<CarBrandQuery>();
            Mutation = resolver.Resolve<CarBrandMutation>();
        }
    }
}
