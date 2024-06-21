using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Services.CustomExceptions.ProducerExceptions
{
    public class ProducerNameEmptyException : Exception
    {
        public ProducerNameEmptyException() : base("Producer name cannot be null or empty"){ }
    }
}
