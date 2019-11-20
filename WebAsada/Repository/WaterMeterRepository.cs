using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.Data;
using WebAsada.Models;

namespace WebAsada.Repository
{
    public class WaterMeterRepository : CommonRepositoryActions<WaterMeter>
    {
        private readonly ApplicationDbContext _dbContext; 

        public WaterMeterRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbContext = applicationDbContext; 
        }

        public async override Task<IEnumerable<WaterMeter>> GetAll()
        {
            return await _dbContext.WaterMeter.Include(m => m.Supplier)
                                              .ToListAsync();
        }

        public async Task<IEnumerable<WaterMeter>> GetValidWaterMeterToView()
        {
            return await _dbContext.WaterMeter.Where(x => x.IsActive.Equals(true)) 
                                             .ToListAsync();
        }
          
        public override async Task Update(int id, WaterMeter entity)
        {
            WaterMeter.SincronizeObject(currentObject: await GetById(id), newObject: entity);
            await SaveChanges();
        }
    }

}
