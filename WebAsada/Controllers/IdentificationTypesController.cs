using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAsada.Common; 
using WebAsada.Models;
using WebAsada.Repository;
using WebAsada.ViewModels;

namespace WebAsada.Controllers
{
    public class IdentificationTypesController : BasicViewControllerActions<IdentificationType>
    {
        private const string ATTRIBUTES_TO_BIND = GeneralEntityAttributes.ATTRIBUTES_TO_BIND_DTO_SAVE + ",IdentificationTypeCode";

        public IdentificationTypesController(IdentificationTypeRepository identificationTypeRepository) : base(identificationTypeRepository) { }

        public async Task<IActionResult> Index() => await GetIndexViewWhitAllData<DetailIdentificationTypeVM>();

        public IActionResult Create() => GetView();

        public async Task<IActionResult> Details(int? id) => await GetViewByObjectId<DetailIdentificationTypeVM>(id);

        public async Task<IActionResult> Edit(int? id) => await GetViewByObjectId<DetailIdentificationTypeVM>(id);

        public async Task<IActionResult> Delete(int? id) => await GetViewByObjectId<DetailIdentificationTypeVM>(id);

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) => await ConfirmDelete(id);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(ATTRIBUTES_TO_BIND)] UpdateIdentificationTypeVM insertDTO) => await ConfirmSave(insertDTO);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(ATTRIBUTES_TO_BIND)] UpdateIdentificationTypeVM updateDTO) => await ConfirmEdit(id, updateDTO);

    }
     
}
