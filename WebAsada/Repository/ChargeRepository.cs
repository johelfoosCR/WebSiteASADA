﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.Data;
using WebAsada.Models;

namespace WebAsada.Repository
{
    public class ChargeRepository : GeneralEntityCommonRepositoryActions<Charge>
    {
        public ChargeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }  

        public override async Task Update(int id, Charge newCharge)
        { 
            MarkAsUpdated(Charge.SincronizeObject(currentCharge: await GetById(id), newCharge));
            await SaveChanges();
        }
    }
}