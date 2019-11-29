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

        public async Task<IActionResult> Index()
        { 
            await RefreshCollections();
            return View(new DashboardVM());
        }

        [HttpGet]
        public async Task<IActionResult> Search(DashboardVM dashboardVM)
        {   
            var measurement = await _measurementRepository.GetByMonthAndYear(dashboardVM.MonthNemotecnico, dashboardVM.Year);
            if (measurement.HasValue())
            {
                dashboardVM.ReceiptItemVM = await _receiptRepository.GetByMeasurement(measurement);
                dashboardVM.DashboardReceiptsVM = new DashboardReceiptsVM(totalReceipts:140, totalReceiptsPaid: 45);
                await RefreshCollections();
                return View("Index", dashboardVM);
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Pay(int receiptId, int year, string monthNemotecnico)
        {
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