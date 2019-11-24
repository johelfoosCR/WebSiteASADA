using Microsoft.AspNetCore.Identity;
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
    public class ReceiptRepository : CommonRepositoryActions<Receipt>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<IdentityUser> users; 

        public ReceiptRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbContext = applicationDbContext;
            users = _dbContext.Users; 
        }
         
        public async override Task<Receipt> GetById(int id)
        {
            return await _dbContext.Receipt.Include(m => m.Contract)
                                            .Include(m => m.RegisterUser) 
                                            .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<ReceiptItemVM>> GetByMeasurement(Measurement measurement)
        { 
                return await _dbContext.Receipt.Include(m => m.Contract).ThenInclude(m => m.Meter)
                                           .Include(m => m.Contract).ThenInclude(m => m.PersonsByEstate).ThenInclude(m => m.Person)
                                           .Include(m => m.Measurement).ThenInclude(m => m.Month)
                                           .Where(m => m.Measurement.Id == measurement.Id)
                                           .Select(m => new ReceiptItemVM()
                                           {
                                               ReceiptId = m.Id,
                                               NewRead = m.NewRead,
                                               CurrentRead = m.Contract.Meter.CurrentRead,
                                               FullName = m.Contract.PersonsByEstate.Person.FullName, 
                                               MeterSerialNumber = m.Contract.Meter.SerialNumber
                                           })
                                           .ToListAsync();
        }

        public DbSet<IdentityUser> GetUsers()
        {
            return users;
        }

        public override Task Update(int id, Receipt entity)
        {
            throw new System.NotImplementedException();
        }
    }

}
