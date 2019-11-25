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
    public class PersonRepository : CommonRepositoryActions<Person>
    {
        private readonly ApplicationDbContext _dbContext; 

        public DbSet<Month> Months { get; }

        public PersonRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbContext = applicationDbContext; 
        }

        public async override Task<IEnumerable<Person>> GetAll()
        {
            return await _dbContext.Person.Include(m => m.RegisterUser)
                                          .Include(m => m.IdentificationType)
                                          .Include(m => m.PersonType)
                                          .ToListAsync();
        }

        public async Task<IEnumerable<PersonItemVM>> GetValidPersonToView()
        {
            var personItems = await _dbContext.Person.Where(x => x.IsActive.Equals(true))
                                          .Select(x => new { x.Id, DisplayValue = x.ToString()})
                                          .Select(x => new PersonItemVM { Id =x.Id,
                                                                          DisplayValue = x.DisplayValue})
                                          .ToListAsync();

            personItems.Add(new PersonItemVM
            {
                Id = 0,
                DisplayValue = "Seleccione una opción"
            });

            return personItems;
         }

        public async override Task<Person> GetById(int id)
        {
            return await _dbContext.Person.Include(m => m.RegisterUser)
                                          .Include(m => m.IdentificationType)
                                          .Include(m => m.PersonType)
                                          .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Person>> GetByIds(IEnumerable<int> ids)
        {
            return await _dbContext.Person.Where(m => ids.Contains(m.Id))
                                          .ToListAsync();
        }

        public override async Task Update(int id, Person entity)
        {
            Person.SincronizeObject(currentPerson: await GetById(id), entity);
            await SaveChanges();
        }
    }

}
