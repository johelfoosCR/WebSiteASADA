using System.ComponentModel.DataAnnotations;

namespace WebAsada.ViewModels
{ 
    public class UpdateCurrencyVM : GeneralTableVM
    {
        [Display(Name = "Código Moneda")]
        public string CurrencyCode
        {
            get { return GeneralEntityCode; }
            set { GeneralEntityCode = value; }
        }

        [MaxLength(5)]
        [Display(Name = "Acrónimo")]
        public string Acronym { get; set; }
    }

    public class DetailCurrencyVM : GeneralTableVM
    {
        [Display(Name = "Código Moneda")]
        public string CurrencyCode { get; set; }

        [MaxLength(5)]
        [Display(Name = "Acrónimo")]
        public string Acronym { get; set; }
    }
}
