using System.ComponentModel.DataAnnotations; 

namespace WebAsada.ViewModels
{  
    public class MonthVM
    {
        [Display(Name = "Nombre de Mes")]
        public string ShortDesc { get; set; }

        [Display(Name = "Nemotecnico de Mes")]
        public string Nemotecnico { get; set; }
         
    }
}
