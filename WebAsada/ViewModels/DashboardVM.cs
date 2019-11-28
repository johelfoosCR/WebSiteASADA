using System.Collections.Generic;

namespace WebAsada.ViewModels
{
    public class DashboardVM
    {
        public DashboardVM()
        {

        }

        public int MonthId { get; set; } 

        public int Year { get; set; }

        public DashboardReceiptsVM DashboardReceiptsVM { get; set; }

        public List<ReceiptItemVM> ReceiptItemVM { get; set; }
    }

    public class DashboardReceiptsVM
    {
        public int TotalReceiptsPaid { get; set; }
        public int TotalReceipts { get; set; }
        public int TotalReceiptsPending => TotalReceipts - TotalReceiptsPaid;
        public double TotalReceiptsPaidPercentage => (TotalReceiptsPaid * 100) / TotalReceipts;
        public double TotalReceiptsPendingPercentage => (TotalReceiptsPending * 100) / TotalReceipts;
    }
}