using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.Data;
using WebAsada.Models;

namespace WebAsada.Repository
{
    public class EntityRepository : CommonRepositoryActions<Entity>, IUpdatebleEntity<Entity>
    {
        public EntityRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public async Task Update(int id, Entity newEntity)
        {
            MarkAsUpdated(Entity.SincronizeObject(currentEntity: await GetById(id), newEntity));
            await SaveChanges();
        }
    }
}