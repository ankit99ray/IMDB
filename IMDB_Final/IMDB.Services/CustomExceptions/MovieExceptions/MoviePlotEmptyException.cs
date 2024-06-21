using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Services.CustomExceptions.MovieExceptions
{
    public class MoviePlotEmptyException : Exception
    {
        public MoviePlotEmptyException() : base("Plot cannot be null or empty")
        {
            
        }
    }
}
