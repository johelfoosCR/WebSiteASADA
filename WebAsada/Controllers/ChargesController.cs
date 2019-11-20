using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAsada.Common; 
using WebAsada.Models;
using WebAsada.Repository;
using WebAsada.ViewModels;

namespace WebAsada.Controllers
{
    public class ChargesController : BasicViewControllerActions<Charge>
    {
        public ChargesController(ChargeRepository chargeRepository) : base(chargeRepository) { }

        public async Task<IActionResult> Index() => await GetIndexViewWhitAllData<DetailsChargeVM>();

        public IActionResult Create() => GetView();

        public async Task<IActionResult> Details(int? id) => await GetViewByObjectId<DetailsChargeVM>(id);

        public async Task<IActionResult> Edit(int? id) => await GetViewByObjectId<DetailsChargeVM>(id);

        public async Task<IActionResult> Delete(int? id) => await GetViewByObjectId<DetailsChargeVM>(id);

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) => await ConfirmDelete(id);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(GeneralEntityAttributes.ATTRIBUTES_TO_BIND_DTO_SAVE + ",ChargeCode,Price")] UpdateChargeVM insertGeneralTableVM) => await ConfirmSave(insertGeneralTableVM);
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(GeneralEntityAttributes.ATTRIBUTES_TO_BIND_DTO_UPDATE + ",ChargeCode,Price")] UpdateChargeVM updateGeneralTableVM) => await ConfirmEdit(id, updateGeneralTableVM);
    }
}
