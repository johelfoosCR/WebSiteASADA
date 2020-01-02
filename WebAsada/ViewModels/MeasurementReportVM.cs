using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebAsada.Models;

namespace WebAsada.ViewModels
{
    public class MeasurementReportVM
    {
        [Required]
        [DisplayName("Mes")]
        public string MonthNemotecnico { get; set; }

        public Month Month { get; set; }

        [Required]
        [Range(2000, 2500)]
        [DisplayName("Año")]
        public int Year { get; set; }
    }
}
