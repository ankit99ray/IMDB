using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB_Final.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Plot { get; set; }
        public int Year { get; set; }
        public List<Actor> Actors { get; set; }
        public Producer Producer { get; set; }

        public Movie(string name, string plot, int year, List<Actor> actors, Producer producer)
        {
            this.Name = name;   
            this.Plot = plot;
            this.Year = year;
            this.Actors = actors;
            this.Producer = producer;
        }
        public Movie()
        {
            Actors = new List<Actor>();
        }


    }
}
