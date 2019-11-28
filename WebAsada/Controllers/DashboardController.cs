using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<IActionResult> Index(DashboardVM dashboardVM = null)
        {
            if (!dashboardVM.HasValue())
            {
                dashboardVM = new DashboardVM()
                {
                    DashboardReceiptsVM = new DashboardReceiptsVM() { TotalReceipts = 120, TotalReceiptsPaid = 50 },
                    ReceiptItemVM = new List<ReceiptItemVM>() { new ReceiptItemVM() { CurrentRead = 10, FullName = "JOhel", MeterSerialNumber = "wewqeq", NewRead = 30, ReceiptId = 1 } }
                };
            }
            await RefreshCollections();

            return View(dashboardVM);
        }

        [HttpGet]
        public async Task<IActionResult> Search(DashboardVM dashboardVM)
        {
            var measurement = await _measurementRepository.GetByMonthAndYear(dashboardVM.MonthNemotecnico, dashboardVM.Year);
            dashboardVM.ReceiptItemVM = await _receiptRepository.GetByMeasurement(measurement);

            return RedirectToAction("Index", dashboardVM);
        }

        private async Task RefreshCollections()
        {
            var data = await _monthRepository.GetAll();
            ViewData["MonthCollection"] = new SelectList(data, "Nemotecnico", "ShortDesc");
        }

        
    }
}