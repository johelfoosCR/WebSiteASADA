using System.ComponentModel.DataAnnotations; 
using WebAsada.Global;
using WebAsada.Models;

namespace WebAsada.ViewModels
{ 
    public class UpdateChargeVM : GeneralTableVM, IChargeVM
    { 
        public string ChargeCode
        {
            get { return GeneralEntityCode; }
            set { GeneralEntityCode = value; }
        }

        [RegularExpression(Constants.TWO_DECIMALS_REGEX_EXPRESSION, ErrorMessage = Constants.TWO_DECIMALS_VALIDATION_MESSAGE)]
        public float Price { get; set; } 

        public int ChargeTypeId { get; set; }
         
        public ChargeType ChargeType { get; set; }

        public double CubicMeterFrom { get; set; }
        
        public double CubicMeterTo { get; set; }

        public double VatRate { get;  set; }

        public bool IsVATCharge { get; set; }
    }

    public class DetailsChargeVM : GeneralTableVM, IChargeVM
    { 
        public string ChargeCode { get; set; }

        public float Price { get; set; }

        public int ChargeTypeId { get; set; }

        public ChargeType ChargeType { get; set; }

        public double CubicMeterFrom { get; set; }

        public double CubicMeterTo { get; set; }

        public double VatRate { get; set; }

        public bool IsVATCharge { get; set; }
    }

    public interface IChargeVM
    {
        [Display(Name = "Código del Cargo")]
        string ChargeCode { get; set; }

        [Display(Name = "Precio")]
        [RegularExpression(Constants.TWO_DECIMALS_REGEX_EXPRESSION, ErrorMessage = Constants.TWO_DECIMALS_VALIDATION_MESSAGE)]
        float Price { get; set; }

        [Display(Name = "Tipo de Cargo")]
        int ChargeTypeId { get; set; }

        ChargeType ChargeType { get; set; }

        [Display(Name = "m3 Desde")]
        double CubicMeterFrom { get; set; }

        [Display(Name = "m3 Hasta")]
        double CubicMeterTo { get; set; }

        [Display(Name = "Pocentaje IVA")]
        double VatRate { get; set; }

        [Display(Name = "Cobra IVA")]
        bool IsVATCharge { get; set; }
    }
}
