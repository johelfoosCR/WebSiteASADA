using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.Data;
using WebAsada.Models;

namespace WebAsada.Repository
{
    public class IdentificationTypeRepository : GeneralEntityCommonRepositoryActions<IdentificationType>, IUpdatebleEntity<IdentificationType>
    { 
        public IdentificationTypeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        { 
        }
         
        public override async Task Update(int id, IdentificationType identificationType)
        {
            MarkAsUpdated(IdentificationType.SincronizeObject(currentIdentificationType: await GetById(id), newIdentificationType: identificationType));
            await SaveChanges();
        }
    }
}
