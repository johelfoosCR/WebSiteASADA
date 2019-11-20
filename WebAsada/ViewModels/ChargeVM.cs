using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations; 
using WebAsada.Global;

namespace WebAsada.ViewModels
{ 
    public class UpdateChargeVM : GeneralTableVM
    { 
        [Display(Name = "Código del Cargo")]
        public string ChargeCode
        {
            get { return GeneralEntityCode; }
            set { GeneralEntityCode = value; }
        }

        [Display(Name = "Precio")]  
        [RegularExpression(Constants.TWO_DECIMALS_REGEX_EXPRESSION, ErrorMessage = Constants.TWO_DECIMALS_VALIDATION_MESSAGE)]
        public float Price { get; set; }
    }

    public class DetailsChargeVM : GeneralTableVM
    {
        [Display(Name = "Código del Cargo")]
        public string ChargeCode { get; set; }

        [Display(Name = "Precio")] 
        [RegularExpression(Constants.TWO_DECIMALS_REGEX_EXPRESSION, ErrorMessage = Constants.TWO_DECIMALS_VALIDATION_MESSAGE)]
        public float Price { get; set; }
    }
}
