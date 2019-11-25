using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using WebAsada.Common; 
using WebAsada.Models;
using WebAsada.Repository;
using WebAsada.ViewModels;

namespace WebAsada.Controllers
{
    public class ChargesController : BasicViewControllerActions<Charge>
    {

        private const string ATTRIBUTES_TO_BIND = GeneralEntityAttributes.ATTRIBUTES_TO_BIND_DTO_SAVE + ",ChargeCode,Price,ChargeTypeId,CubicMeterFrom,CubicMeterTo,VatRate,IsVATCharge";

        private readonly ChargeTypeRepository _chargeTypeRepository;

        public ChargesController(ChargeRepository chargeRepository, ChargeTypeRepository chargeTypeRepository) : base(chargeRepository) {
            _chargeTypeRepository = chargeTypeRepository;
        }

        public async Task<IActionResult> Index() => await GetIndexViewWhitAllData<DetailsChargeVM>();

        public IActionResult Create() => GetView(RefreshCollections);

        public async Task<IActionResult> Details(int? id) => await GetViewByObjectId<DetailsChargeVM>(id);

        public async Task<IActionResult> Edit(int? id) => await GetViewByObjectId<DetailsChargeVM>(id, RefreshCollections);

        public async Task<IActionResult> Delete(int? id) => await GetViewByObjectId<DetailsChargeVM>(id);

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) => await ConfirmDelete(id);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(ATTRIBUTES_TO_BIND)] UpdateChargeVM insertGeneralTableVM) => await ConfirmSave(insertGeneralTableVM);
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(ATTRIBUTES_TO_BIND)] UpdateChargeVM updateGeneralTableVM) => await ConfirmEdit(id, updateGeneralTableVM);

        private async void RefreshCollections()
        { 
            ViewData["ChargeTypeCollection"] = new SelectList(await _chargeTypeRepository.GetGeneralEntityValidData(), "Value", "Text");  
        }
    }
}
