using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAsada.Common; 
using WebAsada.Models;
using WebAsada.Repository;
using WebAsada.ViewModels;

namespace WebAsada.Controllers
{
    public class ProductTypesController : BasicViewControllerActions<ProductType>
    {
        private const string ATTRIBUTES_TO_BIND = GeneralEntityAttributes.ATTRIBUTES_TO_BIND_DTO_SAVE + ",ProductTypeCode";

        public ProductTypesController(ProductTypeRepository productTypeRepository) : base(productTypeRepository) { }

        public async Task<IActionResult> Index() => await GetIndexViewWhitAllData<DetailProductTypeVM>();

        public IActionResult Create() => GetView();

        public async Task<IActionResult> Details(int? id) => await GetViewByObjectId<DetailProductTypeVM>(id);

        public async Task<IActionResult> Edit(int? id) => await GetViewByObjectId<DetailProductTypeVM>(id);

        public async Task<IActionResult> Delete(int? id) => await GetViewByObjectId<DetailProductTypeVM>(id);

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) => await ConfirmDelete(id);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(ATTRIBUTES_TO_BIND)] UpdateProductTypeVM updateVM) => await ConfirmSave(updateVM);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(ATTRIBUTES_TO_BIND)] UpdateProductTypeVM updateVM) => await ConfirmEdit(id, updateVM);

    }
     
}
