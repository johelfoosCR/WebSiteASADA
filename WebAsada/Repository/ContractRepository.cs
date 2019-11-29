using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.Data;
using WebAsada.Models;
using WebAsada.ViewModels;

namespace WebAsada.Repository
{
    public class ContractRepository : CommonRepositoryActions<Contract>, IUpdatebleEntity<Contract>
    {
        private readonly ApplicationDbContext _dbContext; 

        public ContractRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbContext = applicationDbContext; 
        }

        public async override Task<IEnumerable<Contract>> GetAll()
        {
            return await _dbContext.Contract.Include(x => x.PersonsByEstate)
                                             .ThenInclude(x => x.Estate)
                                             .Include(x => x.PersonsByEstate)
                                             .ThenInclude(x => x.Person)
                                             .Include(x => x.Meter) 
                                             .ToListAsync(); 
        }

        public List<SelectItemVM<int>> GetValidData()
        {
            return _dbContext.Contract.Include(x => x.PersonsByEstate)
                                                .ThenInclude(x => x.Estate)
                                            .Include(x => x.PersonsByEstate)
                                                .ThenInclude(x => x.Person)
                                            .Include(x => x.Meter)
                                            .Where(x => x.IsActive.Equals(true))
                                            .Select(x => SelectItemVM<int>.Create(x.Id, $"{x.PersonsByEstate.Person.FullName} / {x.PersonsByEstate.Estate.Alias} / {x.Meter.SerialNumber}" ))
                                            .ToList();
        }

        public async Task<IEnumerable<WaterMeter>> GetValidWaterMeterToView()
        {
            return await _dbContext.WaterMeter.Where(x => x.IsActive.Equals(true)) 
                                             .ToListAsync();
        }
           
        public async Task Update(int id, Contract entity)
        { 
            MarkAsUpdated(Contract.SincronizeObject(currentObject: await GetById(id), newObject: entity));
            await SaveChanges(); 
        }
         
    } 
}
