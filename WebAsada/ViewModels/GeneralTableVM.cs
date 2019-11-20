using System.ComponentModel.DataAnnotations;
using WebAsada.BaseObjects;

namespace WebAsada.ViewModels
{
    public abstract class GeneralTableVM: BaseEntity
    { 
        [Display(Name = "Descripción Corta")] 
        public string ShortDesc { get; set; }

        [Display(Name = "Descripción Larga")]
        public string LongDesc { get; set; }

        [Display(Name = "Nemotecnico")]
        public string Nemotecnico { get; set; }

        [Display(Name = "Codigo Regulador")]
        public string OfficialId { get; set; } 

        [Display(Name = "Activo?")]
        public bool IsActive { get; set; }

        [Display(Name = "Código")]
        public string GeneralEntityCode { get; set; }
    } 
}
