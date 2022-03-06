namespace Store.BUSINESS.DTOs.ResponseDTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public List<string> Genres { get; set; }
        public List<string> Actors { get; set; }
        public int ReleasedYear { get; set; }
        public decimal ImdbRating { get; set; }
        public bool HasAnOscar { get; set; }
        public double Price { get; set; }
    }
}
