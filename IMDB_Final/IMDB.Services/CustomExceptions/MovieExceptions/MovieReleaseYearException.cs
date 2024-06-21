using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Services.CustomExceptions.MovieExceptions
{
    public class MovieReleaseYearException : Exception
    {
        public MovieReleaseYearException() : base("Invalid year of release of the movie")
        {
            
        }
    }
}
