using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Services.CustomExceptions.ProducerExceptions
{
    public class ProducerBirthDateEmptyException : Exception
    {
        public ProducerBirthDateEmptyException() : base("Producer birth date cannot be null or empty")
        {
            
        }
    }
}
