using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebAsada.BaseObjects;
using WebAsada.Models;

namespace WebAsada.ViewModels
{
    public class MeasurementVM: BaseEntity
    { 
        [Required]
        [DisplayName("Mes")] 
        public int MonthId { get; set; }

        public Month Month { get; set; }

        [Required]
        [DisplayName("Código")]
        public string MeasurementId => $"{Month?.ShortDesc.ToUpper()}-{Year}";

        [Required]
        [Range(2000, 2500)]
        [DisplayName("Año")]
        public int Year { get; set; }

        [Required]
        [DisplayName("Usuario de Lectura")]
        public string ReadUserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Fecha de Lectura")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReadDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Fecha Desde")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateFrom { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Fecha Hasta")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateTo { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Fecha de pago máxima")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime MaxPaymentDate { get; set; }

        [DisplayName("Mensaje del Mes")]
        [MaxLength(500, ErrorMessage = "No puede exceder los 500 caracteres")]
        [DataType(DataType.MultilineText)]
        public string MessageOfTheMonth { get; set; }

        [DisplayName("Lugar de Pago")]
        [MaxLength(500, ErrorMessage = "No puede exceder los 500 caracteres")]
        [DataType(DataType.MultilineText)]
        public string PaymentPlace { get; set; }
         
        public bool HasPaymentReceipts { get; set; }
    }


    public class MeasurementDetailVM
    { 
        public int Id { get; set; }

        public Month Month { get; set; }

        [Required]
        [DisplayName("Código")]
        public string MeasurementId => $"{Month?.ShortDesc.ToUpper()}-{Year}";

        [Required]
        [Range(2000, 2500)]
        [DisplayName("Año")]
        public int Year { get; set; }
         
        [DataType(DataType.Date)]
        [DisplayName("Fecha Desde")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateFrom { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Fecha Hasta")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateTo { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Fecha de pago máxima")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime MaxPaymentDate { get; set; }
         
    }

}
