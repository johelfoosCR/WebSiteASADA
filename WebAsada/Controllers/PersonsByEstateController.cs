using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;
using WebAsada.Repository;
using WebAsada.ViewModels;

namespace WebAsada.Controllers
{
    public class PersonsByEstateController : Controller
    {  
        private readonly PersonsByEstateRepository _personsByEstateRepository;
        private readonly PersonRepository _personRepository;
        private readonly EstateRepository _estateRepository;

        public PersonsByEstateController(PersonsByEstateRepository personsByEstateRepository, PersonRepository personsRepository, EstateRepository estateRepository) {
            _personsByEstateRepository = personsByEstateRepository;
            _personRepository = personsRepository;
            _estateRepository = estateRepository;
        }


        public async Task<IActionResult> AddOwner(int? id, PersonItemVM personItemVM)
        {
            if (!id.HasValue) return NotFound();

            var person = await _personRepository.GetById(personItemVM.Id);
            var estate = await _estateRepository.GetById(id.Value);

            await _personsByEstateRepository.Save(person, estate);
               
            return Ok(new {id.Value});
        }


        public async Task<IActionResult> DeleteOwner(int? estateId, int? personId)
        {
            if (!personId.HasValue) return NotFound(); 
            var person = await _personRepository.GetById(personId.Value);
            var estate = await _estateRepository.GetById(estateId.Value);
            await _personsByEstateRepository.Delete(person, estate);

            return Ok();
        }
    }
}
