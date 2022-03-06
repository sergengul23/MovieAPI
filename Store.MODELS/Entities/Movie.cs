using Store.MODELS.Base;

namespace Store.MODELS.Entities
{
    public class Movie : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public int ReleasedYear { get; set; }
        public decimal ImdbRating { get; set; }
        public bool HasAnOscar { get; set; }
        public double Price { get; set; }
    }
}
