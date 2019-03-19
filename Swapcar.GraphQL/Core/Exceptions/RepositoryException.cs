using System;

namespace Swapcar.GraphQL.Core.Exceptions
{
    public class RepositoryException : Exception
    {
        public RepositoryException(Exception ex) :base()
        {
        }
    }
}
