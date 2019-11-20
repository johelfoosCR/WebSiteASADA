using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.Data;
using WebAsada.Models;

namespace WebAsada.Repository
{
    public class EntityRepository : CommonRepositoryActions<Entity>
    {
        public EntityRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public override async Task Update(int id, Entity newEntity)
        {
            MarkAsUpdated(Entity.SincronizeObject(currentEntity: await GetById(id), newEntity));
            await SaveChanges();
        }
    }
}