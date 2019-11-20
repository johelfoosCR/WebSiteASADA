using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.Data;
using WebAsada.Models;

namespace WebAsada.Repository
{
    public class ContractTypeRepository : GeneralEntityCommonRepositoryActions<ContractType>
    {
        public ContractTypeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }  

        public override async Task Update(int id, ContractType contractType)
        { 
            MarkAsUpdated(ContractType.SincronizeObject(currentObject: await GetById(id), contractType));
            await SaveChanges();
        }
    }
}