namespace IMDB.Models.Db
{
    public class Review
    {
        public int Id { get; set; }
        public string ReviewMessage { get; set; }
        public int MovieId { get; set; }
    }
}
