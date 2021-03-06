﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebAsada.BaseObjects;
using WebAsada.Models;

namespace WebAsada.ViewModels
{
    public class ContractVM : BaseEntity
    {
        [DisplayName("Cliente")]
        public int PersonId { get; set; }

        public Person Person { get; set; }

        [DisplayName("Tipo Contrato")]
        public int ContractTypeId { get; set; }

        public ContractType ContractType { get; set; } 

        [DisplayName("Propiedad")]
        public int EstateId { get; set; }

        public Estate Estate { get; set; } 

        [DisplayName("Medidor")]
        public int MeterId { get; set; }

        public WaterMeter Meter { get; set; }

        public PersonsByEstate PersonsByEstate{ get; set; }
         
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Fecha de Emision")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EmissionDate { get; set; }

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
