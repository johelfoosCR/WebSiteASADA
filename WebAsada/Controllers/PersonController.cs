using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.Models;
using WebAsada.Repository;
using WebAsada.ViewModels;

namespace WebAsada.Controllers
{
    public class PersonController : BasicViewControllerActions<Person>
    {
        private readonly IdentificationTypeRepository _identificationTypeRepository;
        private readonly PersonTypeRepository _personTypeRepository;

        private const string ATTRIBUTES_TO_BIND = "Name,FirstLastName,SecondLastName,PersonTypeId,IdentificationTypeId,IdentificationNumber,TelephoneNumber,EmailAddress,IsActive";
         
        public PersonController(PersonRepository personRepository, IdentificationTypeRepository identificationTypeRepository, PersonTypeRepository personTypeRepository) 
            : base(personRepository)
        {
            _identificationTypeRepository = identificationTypeRepository;
            _personTypeRepository = personTypeRepository;
        }

        public async Task<IActionResult> Index() => await GetIndexViewWhitAllData<PersonVM>();

        public async Task<IActionResult> Details(int? id) => await GetViewByObjectId<PersonVM>(id);

        public IActionResult Create() => GetView(RefreshCollections);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(ATTRIBUTES_TO_BIND)] PersonVM PersonVM) => await ConfirmSave(PersonVM, RefreshCollections);

        public async Task<IActionResult> Edit(int? id) => await GetViewByObjectId<PersonVM>(id, RefreshCollections);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(ATTRIBUTES_TO_BIND)] PersonVM PersonVM) => await ConfirmEdit(id, PersonVM, RefreshCollections);

        public async Task<IActionResult> Delete(int? id) => await GetViewByObjectId<PersonVM>(id);

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) => await ConfirmDelete(id);

        private void RefreshCollections()
        { 
            ViewData["IdentificationTypeId"] = new SelectList(_identificationTypeRepository.GetGeneralEntityValidData().Result, "Id", "ShortDesc");
            ViewData["PersonTypeId"] = new SelectList(_personTypeRepository.GetGeneralEntityValidData().Result, "Id", "ShortDesc"); 
        }
    }
}
