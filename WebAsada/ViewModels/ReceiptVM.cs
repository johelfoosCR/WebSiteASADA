using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace WebAsada.ViewModels
{
    public class NewReceiptVM
    {
        public NewReceiptVM()
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

        public List<ReceiptVM> Receipts { get; set; }
    }

    public class ReceiptVM
    { 

        [DisplayName("Código Recibo")]
        public int ReceiptId { get; set; }

        [DisplayName("Lectura Actual")]
        public int CurrentRead { get; set; }

        [DisplayName("Nombre Completo")]
        public string FullName { get;  set; }

        [DisplayName("Monto")]
        public double TotalAmount { get; set; }

        [DisplayName("Tarifa Basica Doble")]
        public bool DoubleBasicCharge { get; set; }
          
        [DisplayName("Medidor")]
        public string MeterSerialNumber { get;  set; } 

        [DisplayName("Codigo Recibo")]
        public string ReceiptCode { get; set; }

        [DisplayName("Nueva Lectura")]
        public int NewRead { get; set; }

        [DisplayName("Pagado")]
        public bool IsPaid { get; set; }

        [DisplayName("Consumo Total")]
        public int CubicMetersConsume => NewRead - CurrentRead;
         
        public List<ReceiptItemVM> Items { get; set; }

        [DisplayName("Numero de Identificación")]
        public string IdentificatioNumber { get; set; }

        [DisplayName("Última Lectura")]
        public int LastRead { get; internal set; } 

        [DisplayName("Id Contrato")]
        public string ContractIdentifier { get; internal set; }
    }

    public class ReceiptItemVM
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public double Amount { get; set; }

        public double VatAmount { get; set; }

        public double TotalAmount { get; set; }
    }


    public class ReceiptInquiryVM
    {
        public ReceiptInquiryVM()
        {
            Receipts = Enumerable.Empty<ReceiptVM>();
        }

        [DisplayName("Número de Conctrato")]
        public int? ContractId { get; set; }

        public IEnumerable<ReceiptVM> Receipts { get; set; }
    }
}