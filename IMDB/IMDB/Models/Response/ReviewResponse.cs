namespace IMDB.Models.Response
{
    public class ReviewResponse
    {
        public int Id { get; set; }
        public string ReviewMessage { get; set; }
        public int MovieId { get; set; }
    }
}
