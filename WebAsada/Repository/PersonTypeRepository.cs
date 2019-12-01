using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.Data;
using WebAsada.Models;

namespace WebAsada.Repository
{
    public class PersonTypeRepository : GeneralEntityCommonRepositoryActions<PersonType>, IUpdatebleEntity<PersonType>
    {
        public PersonTypeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        { 
        }   
         
        public override async Task Update(int id, PersonType newCustomerType)
        {
            MarkAsUpdated(PersonType.SincronizeObject(currentCustomerType: await GetById(id), newCustomerType));
            await SaveChanges();
        }
    }
}