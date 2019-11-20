using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.Models;
using WebAsada.Repository;
using WebAsada.ViewModels;
 

namespace WebAsada.Controllers
{
    public class WaterMeterController : BasicViewControllerActions<WaterMeter>
    {
        private readonly SupplierReporsitory _supplierReporsitory;  
        private const string ATTRIBUTES_TO_BIND = "Model,SerialNumber,CurrentRead,BougthDate,SupplierId,IsActive,Comments";

        public WaterMeterController(WaterMeterRepository waterMeterRepository, SupplierReporsitory supplierReporsitory)
            : base(waterMeterRepository)
        {
            _supplierReporsitory = supplierReporsitory;
        }

        public async Task<IActionResult> Index() => await GetIndexViewWhitAllData<WaterMeterVM>();

        public async Task<IActionResult> Details(int? id) => await GetViewByObjectId<WaterMeterVM>(id);

        public IActionResult Create() => GetView(RefreshCollections);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(ATTRIBUTES_TO_BIND)] WaterMeterVM waterMeterVM) => await ConfirmSave(waterMeterVM, RefreshCollections);

        public async Task<IActionResult> Edit(int? id) => await GetViewByObjectId<WaterMeterVM>(id, RefreshCollections);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(ATTRIBUTES_TO_BIND)] WaterMeterVM waterMeterVM) => await ConfirmEdit(id, waterMeterVM, RefreshCollections);

        public async Task<IActionResult> Delete(int? id) => await GetViewByObjectId<WaterMeterVM>(id);

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) => await ConfirmDelete(id);

        private void RefreshCollections()
        { 
            ViewData["SupplierId"] = new SelectList(_supplierReporsitory.GetValidSupplierByNemotecnicoToView("MEDIDOR").Result, "Id", "Name"); 
        }
    }
}
