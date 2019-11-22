using Microsoft.EntityFrameworkCore;
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

        public async Task<PersonsByEstate> GetDataByIdentifier(int personId, int estateId)
        {
            return await _dbContext.PersonsByEstate.SingleAsync(x => x.PersonId.Equals(personId) && x.EstateId.Equals(estateId));
        }

        public async Task Save(Person person, Estate estate)
        {  
            _dbContext.Add(PersonsByEstate.Create(person, estate));
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Person person, Estate estate)
        {
            var personByEstate = _dbContext.PersonsByEstate.Single(x => x.PersonId == person.Id && x.EstateId == estate.Id);
            _dbContext.Remove(personByEstate);
            await _dbContext.SaveChangesAsync();
        }
    }
}
