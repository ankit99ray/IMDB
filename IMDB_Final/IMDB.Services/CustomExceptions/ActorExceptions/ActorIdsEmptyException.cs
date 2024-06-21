using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Services.CustomExceptions.ActorExceptions
{
    public class ActorIdsEmptyException : Exception
    {
        public ActorIdsEmptyException() : base("Actor Ids cannot be null or empty")
        {
            
        }
    }
}
