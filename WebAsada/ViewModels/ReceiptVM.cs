using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName("Contrato")]
        public RelatedEntityVM Contract { get; set; }

        [DisplayName("Lectura Actual")]
        public int CurrentRead { get; set; }

        [DisplayName("Nueva Lectura")]
        public int NewRead { get; set; } 

        public List<ReceiptItemVM> Receipts { get; set; }
    }

    public class ReceiptItemVM
    {
        [DisplayName("Código Recibo")]
        public int ReceiptId { get; set; }

        [DisplayName("Lectura Actual")]
        public int CurrentRead { get; set; }

        [DisplayName("Nombre Completo")]
        public string FullName { get;  set; }

        [DisplayName("Medidor")]
        public string MeterSerialNumber { get;  set; }

        [DisplayName("Nueva Lectura")]
        public int NewRead { get; set; }

        [DisplayName("Consumo Total")]
        public int CubicMetersConsume => NewRead - CurrentRead; 
    } 

}