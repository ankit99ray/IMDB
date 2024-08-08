namespace IMDB.Models.Request
{
    public class ReviewRequest
    {
        public int Id { get; set; }
        public string ReviewMessage { get; set; }
        public int MovieId { get; set; }
    }
}
