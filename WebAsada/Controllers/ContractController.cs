using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAsada.Common; 
using WebAsada.Models;
using WebAsada.Repository;
using WebAsada.ViewModels;

namespace WebAsada.Controllers
{
    public class ContractController : BasicViewControllerActions<Contract>
    {
        private const string ATTRIBUTES_TO_BIND = ",Contract";

        public ContractController(ContractRepository contractRepository) : base(contractRepository) {

        }

        public async Task<IActionResult> Index() => await GetIndexViewWhitAllData<ContractVM>();

        public IActionResult Create() => GetView();

        public async Task<IActionResult> Details(int? id) => await GetViewByObjectId<ContractVM>(id);

        public async Task<IActionResult> Edit(int? id) => await GetViewByObjectId<ContractVM>(id);

        public async Task<IActionResult> Delete(int? id) => await GetViewByObjectId<ContractVM>(id);

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) => await ConfirmDelete(id);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(ATTRIBUTES_TO_BIND)] ContractVM UpdateVm) => await ConfirmSave(UpdateVm);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(ATTRIBUTES_TO_BIND)] ContractVM UpdateVm) => await ConfirmEdit(id, UpdateVm);

    }
}
