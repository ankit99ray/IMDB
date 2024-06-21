using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Services.CustomExceptions.ActorExceptions
{
    public class ActorNameEmptyException : Exception
    {
        public ActorNameEmptyException() : base("Actor name cannot be null or empty")
        {

        }
    }
}
