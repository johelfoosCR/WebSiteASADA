using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using WebAsada.Common; 
using WebAsada.Models;
using WebAsada.Repository;
using WebAsada.ViewModels;

namespace WebAsada.Controllers
{
    public class ContractController : BasicViewControllerActions<Contract>
    {
        private const string ATTRIBUTES_TO_BIND = "PersonId,ContractTypeId,EstateId,MeterId,InitialMeterRead,DoubleBasicCharge,IsActive";
        private readonly PersonRepository _personRepository;
        private readonly WaterMeterRepository _waterMeterRepository;
        private readonly ContractTypeRepository _contractTypeRepository;
        private readonly PersonsByEstateRepository _personsByEstateRepository;

        public ContractController(ContractRepository contractRepository, PersonRepository personRepository, 
                                  WaterMeterRepository waterMeterRepository, ContractTypeRepository contractTypeRepository,
                                  PersonsByEstateRepository personsByEstateRepository) : base(contractRepository) {

            _personRepository = personRepository;
            _waterMeterRepository = waterMeterRepository;
            _contractTypeRepository = contractTypeRepository;
            _personsByEstateRepository = personsByEstateRepository;
        }

        public async Task<IActionResult> Index() => await GetIndexViewWhitAllData<ContractVM>();

        public IActionResult Create() => GetView(RefreshCollections);

        public async Task<IActionResult> Details(int? id) => await GetViewByObjectId<ContractVM>(id);

        public async Task<IActionResult> Edit(int? id) => await GetViewByObjectId<ContractVM>(id);

        public async Task<IActionResult> Delete(int? id) => await GetViewByObjectId<ContractVM>(id);

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) => await ConfirmDelete(id);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(ATTRIBUTES_TO_BIND)] ContractVM UpdateVm) => await ConfirmSave(UpdateVm);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(ATTRIBUTES_TO_BIND)] ContractVM UpdateVm) => await ConfirmEdit(id, UpdateVm);


        [HttpGet]
        public ActionResult GetEstatesByPerson(int id)
        { 
            return Json(new SelectList(_personsByEstateRepository.GetValidEstatesByPersonId(id).Result, "Value", "Text"));
        }

        private void RefreshCollections()
        {
            ViewData["PersonCollection"] = new SelectList(_personRepository.GetValidPersonToView().Result, "Id", "DisplayValue");
            ViewData["MeterCollection"] = new SelectList(_waterMeterRepository.GetValidWaterMeterToView().Result, "Value", "Text");
            ViewData["ContractTypeCollection"] = new SelectList(_contractTypeRepository.GetGeneralEntityValidData().Result, "Value", "Text"); 
        }
    }
}
