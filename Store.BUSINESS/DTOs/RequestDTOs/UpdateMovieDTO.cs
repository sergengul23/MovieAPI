namespace Store.BUSINESS.DTOs.RequestDTOs
{
    public class UpdateMovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DirectorId { get; set; }
        public int ReleasedYear { get; set; }
        public decimal ImdbRating { get; set; }
        public bool HasAnOscar { get; set; }
        public double Price { get; set; }
    }
}
