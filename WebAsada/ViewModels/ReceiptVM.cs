using System;
using System.Collections.Generic;
using System.Linq;
using WebAsada.Models;

namespace WebAsada.ViewModels
{
    public class ReceiptVM
    {
        public ReceiptVM()
        { 
        }

        public int Id { get; }

        public MeasurementDetailVM Measurement { get; set; }

        public RelatedEntityVM Contract { get; set; }  

        public int CurrentRead { get; set; }

        public int NewRead { get; set; } 

        public List<ReceiptItemVM> Receipts { get; set; }
    }

    public class ReceiptItemVM
    {
        public int ReceiptId { get; set; }

        public int CurrentRead { get; set; }

        public string FullName { get;  set; }

        public string MeterSerialNumber { get;  set; }

        public int NewRead { get; set; }

        public int CubicMetersConsume => NewRead - CurrentRead;

        public double TotalAmount { get; set; }
    } 

}