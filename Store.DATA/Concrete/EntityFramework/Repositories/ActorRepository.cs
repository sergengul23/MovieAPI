using Microsoft.EntityFrameworkCore;
using Store.CORE.Repositories.EntityFramework;
using Store.DATA.Abstract.Repositories;
using Store.MODELS.Entities;

namespace Store.DATA.Concrete.EntityFramework.Repositories
{
    public class ActorRepository : EntityRepository<Actor>, IActorRepository
    {
        public ActorRepository(DbContext context) : base(context)
        {
        }
    }
}
