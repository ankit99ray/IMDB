using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Services.CustomExceptions.ProducerExceptions
{
    public class ProducerBirthDateTooOldException : Exception
    {
        public ProducerBirthDateTooOldException() : base("Producer birth year cannot be less than 1800")
        {   
            
        }
    }
}
