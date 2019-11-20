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
    public class PersonsByEstateRepository 
    {
        private readonly ApplicationDbContext _repository;

        public PersonsByEstateRepository(ApplicationDbContext applicationDbContext)
        {
            _repository = applicationDbContext;
        }

        public async Task Save(Person person, Estate estate)
        {  
            _repository.Add(PersonsByEstate.Create(person, estate));
            await _repository.SaveChangesAsync();
        }
        public async Task Delete(Person person, Estate estate)
        {
            var personByEstate = _repository.PersonsByEstate.Single(x => x.PersonId == person.Id && x.EstateId == estate.Id);
            _repository.Remove(personByEstate);
            await _repository.SaveChangesAsync();
        }
    }
}
