using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebAsada.BaseObjects;
using WebAsada.Models;

namespace WebAsada.ViewModels
{
    public class ContractVM : BaseEntity
    {
        [DisplayName("Finca")]
        public int EstateId { get; set; }

        public Estate Estate { get; set; } 

        public PersonsByEstate PersonsByEstate { get; set; } 

        [DisplayName("Medidor")]
        public int MeterId { get; set; }

        public WaterMeter Meter { get; set; }

        [DisplayName("Lectura Medidor")]
        public int InitialMeterRead { get; set; }

        [Required]
        [DisplayName("Tarifa Basica Doble?")]
        public bool DoubleBasicCharge { get; set; }

        [Required]
        [DisplayName("Activo?")]
        public bool IsActive { get; set; } 
    }
}
