using GraphQL.Types;
using System.Collections.Generic;

namespace Swapcar.GraphQL.Core.Api.GraphQL.Queries
{
    public class CoreGraphMutationIncluder : ObjectGraphType<object>
    {
        public CoreGraphMutationIncluder(IEnumerable<ICoreGraphMutationIncluder> graphMutationsToInclude)
        {
            Name = "CoreGraphMutationIncluder";
            foreach (var marker in graphMutationsToInclude)
            {
                var q = marker as ObjectGraphType<object>;
                foreach (var f in q.Fields)
                {
                    AddField(f);
                }
            }
        }
    }
}
