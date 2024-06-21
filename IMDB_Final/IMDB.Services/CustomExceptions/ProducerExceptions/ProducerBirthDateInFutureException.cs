using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Services.CustomExceptions.ProducerExceptions
{
    public class ProducerBirthDateInFutureException : Exception
    {
        public ProducerBirthDateInFutureException(): base("Birth date of producer cannot be in future")
        {
            
        }
    }
}
