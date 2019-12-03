using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;
using WebAsada.Repository;
using WebAsada.ViewModels;

namespace WebAsada.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ReceiptRepository _receiptRepository;
        private readonly MeasurementRepository _measurementRepository;
        private readonly MonthRepository _monthRepository;

        public DashboardController(ReceiptRepository receiptRepository, MeasurementRepository measurementRepository, MonthRepository monthRepository)
        {
            _measurementRepository = measurementRepository;
            _receiptRepository = receiptRepository;
            _monthRepository = monthRepository;
        }

        public async Task<IActionResult> Index()
        { 
            await RefreshCollections();
            return View(new DashboardVM() { Year  = DateTime.Now.Year});
        }

        [HttpGet]
        public async Task<IActionResult> Search(DashboardVM dashboardVM)
        {   
            var measurement = await _measurementRepository.GetByMonthAndYear(dashboardVM.MonthNemotecnico, dashboardVM.Year);
            if (measurement.HasValue())
            {
                dashboardVM.ReceiptItemVM = await _receiptRepository.GetByMeasurement(measurement);

                var totalReceiptsPaid = 0;
                var totalPaidAmount = 0d;
                var totalPendingAmount = 0d;

                foreach (var receipt in dashboardVM.ReceiptItemVM)
                {
                    if (receipt.IsPaid)
                    {
                        totalPaidAmount += receipt.TotalAmount;
                        totalReceiptsPaid++;
                    }
                    else {
                        totalPendingAmount += receipt.TotalAmount;
                    }
                }

                dashboardVM.ChargedAmount = totalPaidAmount;
                dashboardVM.PendingAmount = totalPendingAmount;

                dashboardVM.DashboardReceiptsVM = new DashboardReceiptsVM(totalReceipts:dashboardVM.ReceiptItemVM.Count, totalReceiptsPaid: totalReceiptsPaid);
                
                await RefreshCollections();
                return View("Index", dashboardVM);
            }

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Pay(int receiptId, int year, string monthNemotecnico)
        {

            var receipt = await _receiptRepository.GetById(receiptId);
            receipt.MarkAsPaid();
            await _receiptRepository.Update(receipt);

            await RefreshCollections();
            return RedirectToAction("Search", new DashboardVM() { MonthNemotecnico = monthNemotecnico, Year = year });
        }

        private async Task RefreshCollections()
        {
            var data = await _monthRepository.GetAll();
            ViewData["MonthCollection"] = new SelectList(data, "Nemotecnico", "ShortDesc");
        }

        
    }
}