using System.Collections.Generic;
using System.ComponentModel;

namespace WebAsada.ViewModels
{
    public class DashboardVM
    {
        public DashboardVM()
        {
            ReceiptItemVM = new List<ReceiptVM>();
        }

        [DisplayName("Mes")]
        public string MonthNemotecnico { get; set; }

        [DisplayName("Año")]
        public int Year { get; set; }

        [DisplayName("Monto Cobrado")]
        public double ChargedAmount { get; set; }

        [DisplayName("Monto Pendiente")]
        public double PendingAmount { get; set; }

        public DashboardReceiptsVM DashboardReceiptsVM { get; set; }

        public List<ReceiptVM> ReceiptItemVM { get; set; }
    }

    public class DashboardReceiptsVM
    {
        public DashboardReceiptsVM(int totalReceipts, int totalReceiptsPaid )
        {
            TotalReceipts = totalReceipts;
            TotalReceiptsPaid = totalReceiptsPaid; 
        }

        public int TotalReceiptsPaid { get; }
        public int TotalReceipts { get; }
        public int TotalReceiptsPending => TotalReceipts - TotalReceiptsPaid;
        public double TotalReceiptsPaidPercentage => (TotalReceiptsPaid * 100) / TotalReceipts;
        public double TotalReceiptsPendingPercentage => (TotalReceiptsPending * 100) / TotalReceipts;
    }
}