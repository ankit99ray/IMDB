using System;

namespace IMDB.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {

        }
    }
}
