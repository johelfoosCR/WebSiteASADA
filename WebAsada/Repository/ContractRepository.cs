using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.Data;
using WebAsada.Models;

namespace WebAsada.Repository
{
    public class ContractRepository : CommonRepositoryActions<Contract>
    {
        private readonly ApplicationDbContext _dbContext; 

        public ContractRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbContext = applicationDbContext; 
        }

        public async override Task<IEnumerable<Contract>> GetAll()
        {
            return await _dbContext.Contract.Include(x => x.PersonsByEstate) 
                                            .ToListAsync();
        }

        public async Task<IEnumerable<WaterMeter>> GetValidWaterMeterToView()
        {
            return await _dbContext.WaterMeter.Where(x => x.IsActive.Equals(true)) 
                                             .ToListAsync();
        }
          
        public override async Task Update(int id, Contract entity)
        {
            Contract.SincronizeObject(currentObject: await GetById(id), newObject: entity);
            await SaveChanges();
        }
         
    }

}
