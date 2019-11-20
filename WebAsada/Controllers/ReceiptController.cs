using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.Models;
using WebAsada.Repository;
using WebAsada.ViewModels;

namespace WebAsada.Controllers
{
    public class ReceiptController : BasicViewControllerActions<Receipt>
    {
        private readonly ReceiptRepository _receiptRepository;
        private const string ATTRIBUTES_TO_BIND = "NewRead,Measurement,Contract"; 

        public ReceiptController(ReceiptRepository receiptRepository) : base(receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        public async Task<IActionResult> Index() => await GetIndexViewWhitAllData<ReceiptVM>();

        public async Task<IActionResult> Details(int? id) => await GetViewByObjectId<ReceiptVM>(id);

        public IActionResult Create() => GetView(RefreshCollections);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(ATTRIBUTES_TO_BIND)] ReceiptVM ReceiptVM) => await ConfirmSave(ReceiptVM, RefreshCollections);

        public async Task<IActionResult> Edit(int? id) => await GetViewByObjectId<ReceiptVM>(id, RefreshCollections);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(ATTRIBUTES_TO_BIND)] ReceiptVM ReceiptVM) => await ConfirmEdit(id, ReceiptVM, RefreshCollections);

        public async Task<IActionResult> Delete(int? id) => await GetViewByObjectId<ReceiptVM>(id);

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) => await ConfirmDelete(id);

        private void RefreshCollections()
        {
            ViewData["RegisterUserId"] = new SelectList(_receiptRepository.GetUsers(), "Id", "UserName");
            ViewData["UpdateUserId"] = new SelectList(_receiptRepository.GetUsers(), "Id", "UserName");  
        }
    }
}
