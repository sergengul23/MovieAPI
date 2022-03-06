using Store.MODELS.Base;

namespace Store.MODELS.Entities
{
    public class Director : BaseEntity, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Movie> Movies { get; set; }
        public bool HasAnOscar { get; set; }
    }
}
