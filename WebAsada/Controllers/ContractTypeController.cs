using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAsada.Common; 
using WebAsada.Models;
using WebAsada.Repository;
using WebAsada.ViewModels;

namespace WebAsada.Controllers
{
    public class ContractTypeController : BasicViewControllerActions<ContractType>
    {
        private const string ATTRIBUTES_TO_BIND = GeneralEntityAttributes.ATTRIBUTES_TO_BIND_DTO_SAVE + ",ContractTypeCode";

        public ContractTypeController(ContractTypeRepository contractTypeRepository) : base(contractTypeRepository) { }

        public async Task<IActionResult> Index() => await GetIndexViewWhitAllData<DetailContractTypeVM>();

        public IActionResult Create() => GetView();

        public async Task<IActionResult> Details(int? id) => await GetViewByObjectId<DetailContractTypeVM>(id);

        public async Task<IActionResult> Edit(int? id) => await GetViewByObjectId<DetailContractTypeVM>(id);

        public async Task<IActionResult> Delete(int? id) => await GetViewByObjectId<DetailContractTypeVM>(id);

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) => await ConfirmDelete(id);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(ATTRIBUTES_TO_BIND)] UpdateContractTypeVM UpdateVm) => await ConfirmSave(UpdateVm);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(ATTRIBUTES_TO_BIND)] UpdateContractTypeVM UpdateVm) => await ConfirmEdit(id, UpdateVm);

    }
}
