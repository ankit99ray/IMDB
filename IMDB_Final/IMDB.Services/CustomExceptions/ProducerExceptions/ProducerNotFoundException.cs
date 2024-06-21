using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Services.CustomExceptions.ProducerExceptions
{
    public class ProducerNotFoundException : Exception
    {
        public ProducerNotFoundException() : base("Producer does not exist") { }
    }
}
