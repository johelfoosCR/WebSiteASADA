using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.Global;
using WebAsada.Models;
using WebAsada.Repository;
using WebAsada.ViewModels;

namespace WebAsada.Controllers
{
    public class EstatesController : BasicViewControllerActions<Estate>
    {
        private const string ATTRIBUTES_TO_BIND = "RealFolio,CadastralPlans,Area,Comments,Owners,Alias,ExactAddress";
         
        private readonly PersonRepository _personRepository;
        private readonly EstateRepository _estateRepository;

        public EstatesController(EstateRepository estateRepository, PersonRepository personRepository) : base(estateRepository) {
             _personRepository = personRepository;
             _estateRepository = estateRepository;
        }

        public async Task<IActionResult> Index() => await GetIndexViewWhitAllData<EstateVM>();

        public IActionResult Create() => GetView(RefreshCollections); 

        public async Task<IActionResult> Details(int? id) => await GetViewByObjectId<EstateVM>(id);

        public async Task<IActionResult> Edit(int? id) => await GetViewMappedForEditor(id); 

        public async Task<IActionResult> Delete(int? id) => await GetViewByObjectId<EstateVM>(id);

        public IActionResult RefreshPersonCollection(List<PersonItemVM> personListItemVM)
        {
            ViewData["attributeName"] = "Owners"; 
            return PartialView("../Person/Partial/_List", personListItemVM); 
        }

        public async Task<IActionResult> EditOwners(int? id) => await GetViewMappedForEditor(id); 

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) => await ConfirmDelete(id);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(ATTRIBUTES_TO_BIND)] EstateVM insertDTO) {
            if (ModelState.IsValid)
            {
                if (insertDTO.Owners == null || insertDTO.Owners.Count == 0)
                {
                    ModelState.AddModelError(string.Empty, "Debe agregar al menos un propietario");
                }
                else
                {
                    Estate localState = Estate.Create(realFolio: insertDTO.RealFolio,
                                                      cadastralPlans: insertDTO.CadastralPlans,
                                                      comments: insertDTO.Comments,
                                                      alias: insertDTO.Alias,
                                                      exactAddress: insertDTO.ExactAddress,
                                                      area: insertDTO.Area,
                                                      Owners: await _personRepository.GetByIds(insertDTO.Owners.Select(x => x.Id)));

                    return await ConfirmSaveConcrete(insertDTO, localState);
                }
            }
            RefreshCollections();
            return View(insertDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(ATTRIBUTES_TO_BIND)] EstateVM updateDTO) => await ConfirmEdit(id, updateDTO);

        private void RefreshCollections()
        {
            ViewData["PersonCollection"] = new SelectList(_personRepository.GetValidPersonToView().Result, "Id", "DisplayValue"); 
        }

        private async Task<IActionResult> GetViewMappedForEditor(int? id)
        {
            if (!id.HasValue) return NotFound();

            var estate = await _estateRepository.GetById(id.Value);
            if (estate.HasValue())
            {
                RefreshCollections();

                EstateVM estateVM = new EstateVM()
                {
                    Id = estate.Id,
                    Area = estate.Area,
                    CadastralPlans = estate.CadastralPlans,
                    Comments = estate.Comments,
                    RealFolio = estate.RealFolio,
                    Owners = new List<PersonItemVM>()
                };

                foreach (var personByEstate in estate.PersonsByEstateCollection)
                {
                    estateVM.Owners.Add(new PersonItemVM()
                    {
                        Id = personByEstate.Person.Id,
                        DisplayValue = personByEstate.Person.ToString()
                    });
                }

                ViewData["attributeName"] = "Owners";
                return View(estateVM);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
