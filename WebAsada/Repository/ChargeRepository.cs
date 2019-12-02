using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.Data;
using WebAsada.Models;

namespace WebAsada.Repository
{
    public class ChargeRepository : GeneralEntityCommonRepositoryActions<Charge>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ChargeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public override async Task Update(int id, Charge newCharge)
        {
            MarkAsUpdated(Charge.SincronizeObject(currentCharge: await GetById(id), newCharge));
            await SaveChanges();
        }

        public async Task<IEnumerable<Charge>> GetValidChargeActive()
        {
            return await _applicationDbContext.Charge.Include(m => m.ChargeType)
                                                      .Where(x => x.IsActive)
                                                      .ToListAsync();
        }
    }
}