using GraphQL.Types;
using System.Collections.Generic;

namespace Swapcar.GraphQL.Core.Api.GraphQL.Queries
{
    public class CoreGraphQueryIncluder : ObjectGraphType<object>
    {
        public CoreGraphQueryIncluder(IEnumerable<ICoreGraphQueryIncluder> graphQueriesToInclude)
        {
            Name = "CoreGraphQueryIncluder";
            foreach (var marker in graphQueriesToInclude)
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
