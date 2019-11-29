using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.Data;
using WebAsada.Models;

namespace WebAsada.Repository
{
    public class ContractTypeRepository : GeneralEntityCommonRepositoryActions<ContractType>, IUpdatebleEntity<ContractType>
    {
        public ContractTypeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }  
          
        public async Task Update(int id, ContractType contractType) 
        { 
            MarkAsUpdated(ContractType.SincronizeObject(currentObject: await GetById(id), contractType));
            await SaveChanges();
        }
    }
}