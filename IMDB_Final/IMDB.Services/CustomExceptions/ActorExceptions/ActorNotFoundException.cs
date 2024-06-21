using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Services.CustomExceptions.ActorExceptions
{
    public class ActorNotFoundException : Exception
    {
        public ActorNotFoundException() : base("Actor does not exist") { }
        
    }

}
