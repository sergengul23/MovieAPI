using Microsoft.EntityFrameworkCore;
using Store.CORE.Repositories.EntityFramework;
using Store.DATA.Abstract.Repositories;
using Store.MODELS.Entities;

namespace Store.DATA.Concrete.EntityFramework.Repositories
{
    public class GenreRepository : EntityRepository<Genre>, IGenreRepository
    {
        public GenreRepository(DbContext context) : base(context)
        {
        }
    }
}
