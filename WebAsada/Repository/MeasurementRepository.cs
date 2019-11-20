using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.Data;
using WebAsada.Models;

namespace WebAsada.Repository
{
    public class MeasurementRepository : CommonRepositoryActions<Measurement>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<IdentityUser> users;

        public DbSet<Month> Months { get; }

        public MeasurementRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbContext = applicationDbContext;
            users = _dbContext.Users;
            Months = _dbContext.Month;
        }

        public async override Task<IEnumerable<Measurement>> GetAll()
        {
            return await _dbContext.Measurement.Include(m => m.RegisterUser).Include(m => m.UpdateUser).Include(m => m.Month).ToListAsync();
        }

        public async override Task<Measurement> GetById(int id)
        {
           return await _dbContext.Measurement.Include(m => m.ReadUser)
                                              .Include(m => m.RegisterUser)
                                              .Include(m => m.Month)
                                              .FirstOrDefaultAsync(m => m.Id == id);
        }

        public DbSet<IdentityUser> GetUsers()
        {
            return users;
        }

        public override async Task Update(int id, Measurement entity)
        {
            MarkAsUpdated(Measurement.SincronizeObject(currentMeasurement: await GetById(id), entity));
            await SaveChanges();
        }
    }

}
