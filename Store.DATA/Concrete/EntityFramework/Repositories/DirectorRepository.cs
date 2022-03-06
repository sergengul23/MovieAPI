using Microsoft.EntityFrameworkCore;
using Store.CORE.Repositories.EntityFramework;
using Store.DATA.Abstract.Repositories;
using Store.MODELS.Entities;

namespace Store.DATA.Concrete.EntityFramework.Repositories
{
    public class DirectorRepository : EntityRepository<Director>, IDirectorRepository
    {
        public DirectorRepository(DbContext context) : base(context)
        {
        }
    }
}
