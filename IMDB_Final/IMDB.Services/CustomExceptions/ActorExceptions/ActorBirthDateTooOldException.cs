using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Services.CustomExceptions.ActorExceptions
{
    public class ActorBirthDateTooOldException : Exception
    {
        public ActorBirthDateTooOldException() : base("Actor birth year cannot be less than 1800")
        {
            
        }
    }
}
