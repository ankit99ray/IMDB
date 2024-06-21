using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Services.CustomExceptions.ActorExceptions
{
    public class ActorBirthDateEmptyException : Exception
    {
        public ActorBirthDateEmptyException() : base("Actor birth date cannot be null or empty")
        {
            
        }
    }
}
