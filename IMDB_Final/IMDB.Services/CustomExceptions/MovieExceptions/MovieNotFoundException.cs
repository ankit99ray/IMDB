using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Services.CustomExceptions.MovieExceptions
{
    public class MovieNotFoundException : Exception
    {
        public MovieNotFoundException() : base("Movie does not exist")
        {
            
        }
    }
}
