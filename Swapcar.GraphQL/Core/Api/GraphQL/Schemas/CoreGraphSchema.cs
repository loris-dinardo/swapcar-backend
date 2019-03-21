using GraphQL;
using GraphQL.Types;
using Swapcar.GraphQL.Core.Api.GraphQL.Queries;

namespace Swapcar.GraphQL.Core.Api.GraphQL.Schemas
{
    public class CoreGraphSchema : Schema
    {
        public CoreGraphSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<CoreGraphQueryIncluder>();
            Mutation = resolver.Resolve<CoreGraphMutationIncluder>();
        }
    }
}
