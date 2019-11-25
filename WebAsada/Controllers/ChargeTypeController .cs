using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAsada.Common; 
using WebAsada.Models;
using WebAsada.Repository;
using WebAsada.ViewModels;

namespace WebAsada.Controllers
{
    public class ChargeTypeController : BasicViewControllerActions<ChargeType>
    {
        private const string ATTRIBUTES_TO_BIND = GeneralEntityAttributes.ATTRIBUTES_TO_BIND_DTO_SAVE + ",ChargeTypeCode,VatRate,IsVATCharge";

        public ChargeTypeController(ChargeTypeRepository chargeTypeRepository) : base(chargeTypeRepository) { }

        public async Task<IActionResult> Index() => await GetIndexViewWhitAllData<DetailsChargeTypeVM>();

        public IActionResult Create() => GetView();

        public async Task<IActionResult> Details(int? id) => await GetViewByObjectId<DetailsChargeTypeVM>(id);

        public async Task<IActionResult> Edit(int? id) => await GetViewByObjectId<DetailsChargeTypeVM>(id);

        public async Task<IActionResult> Delete(int? id) => await GetViewByObjectId<DetailsChargeTypeVM>(id);

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) => await ConfirmDelete(id);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(ATTRIBUTES_TO_BIND)] UpdateChargeTypeVM UpdateVm) => await ConfirmSave(UpdateVm);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(ATTRIBUTES_TO_BIND)] UpdateChargeTypeVM UpdateVm) => await ConfirmEdit(id, UpdateVm);

    }
}
