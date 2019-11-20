using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAsada.Common; 
using WebAsada.Models;
using WebAsada.Repository;
using WebAsada.ViewModels;

namespace WebAsada.Controllers
{
    public class CurrencyController : BasicViewControllerActions<Currency>
    {
        private const string ATTRIBUTES_TO_BIND = GeneralEntityAttributes.ATTRIBUTES_TO_BIND_DTO_SAVE + ",CurrencyCode,Acronym";

        public CurrencyController(CurrencyRepository currencyRepository) : base(currencyRepository) { }

        public async Task<IActionResult> Index() => await GetIndexViewWhitAllData<DetailCurrencyVM>();

        public IActionResult Create() => GetView();

        public async Task<IActionResult> Details(int? id) => await GetViewByObjectId<DetailCurrencyVM>(id);

        public async Task<IActionResult> Edit(int? id) => await GetViewByObjectId<DetailCurrencyVM>(id);

        public async Task<IActionResult> Delete(int? id) => await GetViewByObjectId<DetailCurrencyVM>(id);

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) => await ConfirmDelete(id);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(ATTRIBUTES_TO_BIND)] UpdateCurrencyVM UpdateVm) => await ConfirmSave(UpdateVm);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(ATTRIBUTES_TO_BIND)] UpdateCurrencyVM UpdateVm) => await ConfirmEdit(id, UpdateVm);

    }
}
