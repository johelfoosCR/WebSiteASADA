using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAsada.Common;  
using WebAsada.Models;
using WebAsada.Repository;
using WebAsada.ViewModels;

namespace WebAsada.Controllers
{
    public class PersonTypesController : BasicViewControllerActions<PersonType>
    {
        private const string ATTRIBUTES_TO_BIND = GeneralEntityAttributes.ATTRIBUTES_TO_BIND_DTO_SAVE + ",PersonTypeCode";

        public PersonTypesController(PersonTypeRepository chargeRepository) : base(chargeRepository) { }

        public async Task<IActionResult> Index() => await GetIndexViewWhitAllData<DetailPersonTypeVM>();

        public IActionResult Create() => GetView();

        public async Task<IActionResult> Details(int? id) => await GetViewByObjectId<DetailPersonTypeVM>(id);

        public async Task<IActionResult> Edit(int? id) => await GetViewByObjectId<DetailPersonTypeVM>(id);

        public async Task<IActionResult> Delete(int? id) => await GetViewByObjectId<DetailPersonTypeVM>(id);

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) => await ConfirmDelete(id);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(ATTRIBUTES_TO_BIND)] UpdatePersonTypeVM insertGeneralTableVM) => await ConfirmSave(insertGeneralTableVM);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(ATTRIBUTES_TO_BIND)] UpdatePersonTypeVM updateGeneralTableVM) => await ConfirmEdit(id, updateGeneralTableVM);

    }
}
