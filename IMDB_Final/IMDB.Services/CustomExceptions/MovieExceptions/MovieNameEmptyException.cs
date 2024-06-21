using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Services.CustomExceptions.MovieExceptions
{
    internal class MovieNameEmptyException :Exception
    {
        public MovieNameEmptyException() : base("Movie name cannot be null or empty")
        {
            
        }
    }
}
