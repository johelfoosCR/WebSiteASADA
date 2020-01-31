using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.Data;
using WebAsada.Models;

namespace WebAsada.Repository
{
    public class MeasurementRepository : CommonRepositoryEditorActions<Measurement>, IUpdatebleEntity<Measurement>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<SystemUser> users;

        public DbSet<Month> Months { get; }

        public MeasurementRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbContext = applicationDbContext;
            users = _dbContext.SystemUser;
            Months = _dbContext.Month;
        }

        public async override Task<IEnumerable<Measurement>> GetAll()
        {
            return await _dbContext.Measurement.Include(m => m.RegisterUser)
                                               .Include(m => m.UpdateUser)
                                               .Include(m => m.Month)
                                               .Take(12)
                                               .OrderByDescending(x => x.MonthId).ThenByDescending(x=> x.Year)
                                               .ToListAsync();
        }

        public async override Task<Measurement> GetById(int id)
        {
            Maybe<Measurement> measurement = await _dbContext.Measurement.Include(m => m.ReadUser)
                                               .Include(m => m.RegisterUser)
                                               .Include(m => m.Month)
                                               .FirstOrDefaultAsync(m => m.Id == id);

            if (measurement.HasValue)
            {
                if (await _dbContext.Receipt.Include(x => x.Measurement)
                                           .Where(m => m.Measurement.Id == id && m.IsPaid == true)
                                           .ToAsyncEnumerable().Any())
                {
                    measurement.Value.SetHasPaymentReceipts();
                }
            }

            return measurement.Value;
        }


        public async Task<Maybe<Measurement>> TryGetById(int id)
        {
            return await _dbContext.Measurement.Include(m => m.ReadUser)
                                               .Include(m => m.RegisterUser)
                                               .Include(m => m.Month)
                                              .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Result> ActivateMeasurement(int id)
        {
            var result = await TryGetById(id);

            if (result.HasNoValue) return Result.Failure("No se encontró la lectura informada");

            var measurement = result.Value;
            measurement.Activate();

            MarkAsUpdated(measurement);
            await SaveChanges();

            return Result.Ok();
        }

        public async Task<Maybe<Measurement>> GetByMonthAndYear(string monthMnemonic, int year)
        {
            return await _dbContext.Measurement.Include(x => x.Month).FirstOrDefaultAsync(m => m.Year == year && 
                                                                    m.Month.Nemotecnico.Equals(monthMnemonic) &&
                                                                    m.IsActive == true);
        }


        public DbSet<SystemUser> GetUsers()
        {
            return _dbContext.SystemUser;
        }

        public override async Task Update(int id, Measurement entity)
        {
            MarkAsUpdated(Measurement.SincronizeObject(currentMeasurement: await GetById(id), entity));
            await SaveChanges();
        }
    }

}
