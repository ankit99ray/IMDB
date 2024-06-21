using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Services.CustomExceptions.ActorExceptions
{
    public class ActorBirthDateInFutureException : Exception
    {
        public ActorBirthDateInFutureException() : base("Birth date of actor cannot be in future")
        {
            
        }
    }
}
