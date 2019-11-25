using System.Collections.Generic;
using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.Data;
using WebAsada.Models;

namespace WebAsada.Repository
{
    public class ChargeTypeRepository : GeneralEntityCommonRepositoryActions<ChargeType>
    {
        public ChargeTypeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }  

        public override async Task Update(int id, ChargeType newCharge)
        { 
            MarkAsUpdated(ChargeType.SincronizeObject(currentObject: await GetById(id), newCharge));
            await SaveChanges();
        }
    }
}