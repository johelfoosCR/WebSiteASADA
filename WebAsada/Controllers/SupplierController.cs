using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.Models;
using WebAsada.Repository;
using WebAsada.ViewModels;
 

namespace WebAsada.Controllers
{
    public class SupplierController : BasicViewControllerActions<Supplier>
    {
        private readonly ProductTypeRepository _productTypeRepository;  
        private const string ATTRIBUTES_TO_BIND = "Name,ContactName,PhoneNumber,Email,Address,Schedule,ProductTypeId,IsActive,Comments";

        public SupplierController(SupplierReporsitory supplierReporsitory, ProductTypeRepository productTypeRepository)
            : base(supplierReporsitory)
        {
            _productTypeRepository = productTypeRepository;
        }

        public async Task<IActionResult> Index() => await GetIndexViewWhitAllData<SupplierVM>();

        public async Task<IActionResult> Details(int? id) => await GetViewByObjectId<SupplierVM>(id);

        public IActionResult Create() => GetView(RefreshCollections);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(ATTRIBUTES_TO_BIND)] SupplierVM supplierVM) => await ConfirmSave(supplierVM, RefreshCollections);

        public async Task<IActionResult> Edit(int? id) => await GetViewByObjectId<SupplierVM>(id, RefreshCollections);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(ATTRIBUTES_TO_BIND)] SupplierVM supplierVM) => await ConfirmEdit(id, supplierVM, RefreshCollections);

        public async Task<IActionResult> Delete(int? id) => await GetViewByObjectId<SupplierVM>(id);

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) => await ConfirmDelete(id);

        private void RefreshCollections()
        { 
            ViewData["ProductTypeId"] = new SelectList(_productTypeRepository.GetGeneralEntityValidData().Result, "Id", "ShortDesc"); 
        }
    }
}
