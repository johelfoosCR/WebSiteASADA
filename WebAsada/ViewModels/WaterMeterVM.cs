using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebAsada.BaseObjects;
using WebAsada.Models;

namespace WebAsada.ViewModels
{
    public class WaterMeterVM : BaseEntity
    { 
        [DisplayName("Modelo")]
        public string Model { get; set; }

        [Required]
        [DisplayName("Número de Serie")]
        public string SerialNumber { get; set; }
        
        [Required]
        [DisplayName("Numeración Actual")]
        public int CurrentRead { get; set; }

        [Required]
        [DataType(DataType.Date)] 
        [DisplayName("Fecha de Compra")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BougthDate { get; set; }

        [Required]
        [DisplayName("Proveedor")]
        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        [Required]
        [DisplayName("Activo?")]
        public bool IsActive { get; set; }

        [DisplayName("Comentarios")]
        public string Comments { get; set; }
    }
}
