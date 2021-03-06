﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.Data;
using WebAsada.Models;
using WebAsada.ViewModels;

namespace WebAsada.Repository
{
    public class ContractRepository : CommonRepositoryEditorActions<Contract>, IUpdatebleEntity<Contract>
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
        public async override Task<Contract> GetById(int id)
        {
            return await _dbContext.Contract.Include(x => x.Meter)
                                            .SingleAsync(x => x.Id == id);
        }

        public async Task<List<SelectItemVM<int>>> GetValidData()
        {
            return await _dbContext.Contract.Include(x => x.PersonsByEstate)
                                                .ThenInclude(x => x.Estate)
                                            .Include(x => x.PersonsByEstate)
                                                .ThenInclude(x => x.Person)
                                            .Include(x => x.Meter)
                                            .Where(x => x.IsActive.Equals(true))
                                            .Select(x => SelectItemVM<int>.Create(x.Id, $"{x.PersonsByEstate.Person.FullName} / {x.PersonsByEstate.Estate.Alias} / {x.Meter.SerialNumber}" ))
                                            .ToListAsync();
        }

        public async Task<IEnumerable<WaterMeter>> GetValidWaterMeterToView()
        {
            return await _dbContext.WaterMeter.Where(x => x.IsActive.Equals(true)) 
                                             .ToListAsync();
        }
           
        public override async Task Update(int id, Contract entity)
        { 
            MarkAsUpdated(Contract.SincronizeObject(currentObject: await GetById(id), newObject: entity));
            await SaveChanges(); 
        }
         
    } 
}
