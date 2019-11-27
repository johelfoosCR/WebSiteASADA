using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAsada.ViewModels;

namespace WebAsada.Controllers
{
    public class DashboardController : Controller
    { 

        public IActionResult Index()
        {
            
            var dashboardVM = new DashboardVM() { 
                DashboardReceiptsVM = new DashboardReceiptsVM() { TotalReceipts = 120, TotalReceiptsPaid = 50 },
                ReceiptItemVM = new List<ReceiptItemVM>() { new ReceiptItemVM() {  CurrentRead = 10, FullName = "JOhel", MeterSerialNumber = "wewqeq", NewRead = 30, ReceiptId = 1}   }
            };
             

            var a = dashboardVM.DashboardReceiptsVM.TotalReceiptsPaidPercentage;
            var b = dashboardVM.DashboardReceiptsVM.TotalReceiptsPendingPercentage;

            return View(dashboardVM);
        }
    }
}