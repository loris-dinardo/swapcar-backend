using System;

namespace Swapcar.GraphQL.Core.Exceptions
{
    public class RepositoryException : Exception
    {
        public RepositoryException(String message, Exception inner) :base(message, inner)
        {
        }
    }
}
