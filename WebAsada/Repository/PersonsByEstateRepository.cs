using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAsada.Data;
using WebAsada.Models;
using WebAsada.ViewModels;

namespace WebAsada.Repository
{
    public class PersonsByEstateRepository 
    {
        private readonly ApplicationDbContext _dbContext;

        public PersonsByEstateRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
          
        public async Task<IEnumerable<SelectItemVM<int>>> GetValidEstatesByPersonId(int id)
        {
            return await _dbContext.PersonsByEstate.Where(x => x.PersonId.Equals(id))
                                                   .Include(x => x.Estate)
                                                   .Select(x => SelectItemVM<int>.Create(x.EstateId, x.Estate.Alias))
                                                   .ToListAsync();
        }

        public async Task<int> VerifyIfContainPersonRelated(int id)
        {
            return (await _dbContext.PersonsByEstate.Where(x => x.EstateId.Equals(id)) 
                                                   .Select(x => new {x.PersonId })
                                                   .ToListAsync()).Count();
        }

        public async Task<Maybe<PersonsByEstate>> GetDataByIdentifier(int personId, int estateId)
        {
            return await _dbContext.PersonsByEstate.SingleOrDefaultAsync(x => x.PersonId.Equals(personId) && x.EstateId.Equals(estateId));
        }

        public async Task<Result> Save(Person person, Estate estate)
        {
            if ((await GetDataByIdentifier(person.Id, estate.Id)).HasValue) return Result.Failure($"{person.FullName} ya se encuentra registrado en esta propieda");

            _dbContext.Add(PersonsByEstate.Create(person, estate));
            await _dbContext.SaveChangesAsync();
         
            return Result.Ok();
        }

        public async Task Delete(Person person, Estate estate)
        {
            var personByEstate = _dbContext.PersonsByEstate.Single(x => x.PersonId == person.Id && x.EstateId == estate.Id);
            _dbContext.Remove(personByEstate);
            await _dbContext.SaveChangesAsync();
        }
    }
}
