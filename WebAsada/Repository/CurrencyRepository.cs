using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.Data;
using WebAsada.Models;

namespace WebAsada.Repository
{
    public class CurrencyRepository : GeneralEntityCommonRepositoryActions<Currency>
    {
        public CurrencyRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }  

        public override async Task Update(int id, Currency newCharge)
        { 
            MarkAsUpdated(Currency.SincronizeObject(currentObject: await GetById(id), newCharge));
            await SaveChanges();
        }
    }
}