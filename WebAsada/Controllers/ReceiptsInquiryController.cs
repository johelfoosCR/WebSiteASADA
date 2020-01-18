using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebAsada.Repository;
using WebAsada.ViewModels;

namespace WebAsada.Controllers
{
    [AllowAnonymous]
    public class ReceiptsInquiryController : Controller
    {
        private readonly ReceiptRepository _receiptRepository;
         
        public ReceiptsInquiryController(ReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        public IActionResult Index()
        {
            return View(new ReceiptInquiryVM());
        }
         
        public async Task<IActionResult> GetPendingReciptsByContract(ReceiptInquiryVM receiptInquiry)
        {
            if (receiptInquiry.ContractId.HasValue)
            {
                ReceiptInquiryVM result = new ReceiptInquiryVM
                {
                    Receipts = await _receiptRepository.GetReceiptsInformationByContract(receiptInquiry.ContractId.Value)
                };

                if (!result.Receipts.Any())
                {
                    TempData["InfomationMessage"] = "No se encontró ningún recibo Pendiente";
                }

                return View("Index", result);
            } 

            TempData["InfomationMessage"] = "Debe indicar el número de contrato";
            return View("Index");
        }   
    }
}