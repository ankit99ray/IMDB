using System.Collections.Generic;

namespace IMDB.Models.Request
{
    public class MovieRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public string Plot { get; set; }
        public string PosterURL { get; set; }
        public int ProducerId { get; set; }
        public List<int> ActorIds { get; set; }
        public List<int> GenreIds { get; set; }
    }
}
