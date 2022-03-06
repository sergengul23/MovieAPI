using Store.MODELS.Base;

namespace Store.MODELS.Entities
{
    public class Genre : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
