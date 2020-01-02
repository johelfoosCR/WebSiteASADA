using CSharpFunctionalExtensions;
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

        public async Task<Result> VerifyExistingReceiptInMeasurement(int MeasurementId, int ContractId)
        {
            if (await _dbContext.Receipt.Where(x => x.ContractId == ContractId && x.MeasurementId == MeasurementId)
                                        .AsNoTracking()
                                        .ToAsyncEnumerable()
                                        .Count() > 0)
            {
                return Result.Failure("Ya se encuentra un recibo registrado para este contrato");
            }

            return Result.Ok(true);
        }

        public async Task<List<ReceiptVM>> GetReceiptDetailsByMeasurement(int measurementId)
        {
            return await _dbContext.Receipt
                                    .Include(m => m.Contract)
                                        .ThenInclude(m => m.Meter)
                                    .Include(m => m.Contract)
                                        .ThenInclude(m => m.PersonsByEstate)
                                        .ThenInclude(m => m.Person)
                                    .Include(m => m.Measurement)
                                        .ThenInclude(m => m.Month) 
                                    .Include(m => m.Items)
                                    .Where(m => m.Measurement.Id == measurementId)
                                        .Select(ReceiptInfo => new ReceiptVM()
                                        {
                                            ReceiptId = ReceiptInfo.Id,
                                            NewRead = ReceiptInfo.NewRead,
                                            IsPaid = ReceiptInfo.IsPaid,
                                            LastRead = ReceiptInfo.LastRead,
                                            ReceiptCode = $"{ReceiptInfo.Contract.Meter.SerialNumber}|{ReceiptInfo.Measurement.Month.Nemotecnico}{ReceiptInfo.Measurement.Year}",
                                            TotalAmount = ReceiptInfo.TotalAmount,  
                                            CurrentRead = ReceiptInfo.Contract.Meter.CurrentRead,
                                            FullName = ReceiptInfo.Contract.PersonsByEstate.Person.FullName,
                                            IdentificatioNumber = ReceiptInfo.Contract.PersonsByEstate.Person.IdentificationNumber,
                                            MeterSerialNumber = ReceiptInfo.Contract.Meter.SerialNumber,
                                            DoubleBasicCharge = ReceiptInfo.Contract.DoubleBasicCharge,
                                            Items = ReceiptInfo.Items.Select(item => new ReceiptItemVM()
                                            {
                                                 Amount = item.Amount,
                                                 Name = item.Description,
                                                 Quantity = item.Quantity,
                                                 TotalAmount = item.TotalAmount,
                                                 VatAmount = item.VatAmount
                                            }).ToList()
                                        })
                                        .ToListAsync();
        } 

        public DbSet<IdentityUser> GetUsers()
        {
            return users;
        } 

        public async Task Update(Receipt receipt)
        { 
            MarkAsUpdated(receipt);
            await SaveChanges();
        }
    }

}
