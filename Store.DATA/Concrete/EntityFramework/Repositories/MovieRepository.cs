using Microsoft.EntityFrameworkCore;
using Store.CORE.Repositories.EntityFramework;
using Store.DATA.Abstract.Repositories;
using Store.MODELS.Entities;

namespace Store.DATA.Concrete.EntityFramework.Repositories
{
    public class MovieRepository : EntityRepository<Movie>, IMovieRepository
    {
        public MovieRepository(DbContext context) : base(context)
        {
        }
    }
}
