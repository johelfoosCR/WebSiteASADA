using System.ComponentModel.DataAnnotations;  
namespace WebAsada.ViewModels
{
    public class UpdateChargeTypeVM : GeneralTableVM
    {
        [Display(Name = "Código")]
        public string ChargeTypeCode
        {
            get { return GeneralEntityCode; }
            set { GeneralEntityCode = value; }
        }

        [Display(Name = "Porcentaje IVA")]
        public double VatRate { get; set; }

        [Required]
        [Display(Name = "Cobra IVA")]
        public bool IsVATCharge { get; set; }
    }

    public class DetailsChargeTypeVM : GeneralTableVM
    {
        [Display(Name = "Código")]
        public string ChargeTypeCode { get; set; }

        [Display(Name = "Porcentaje IVA")]
        public double VatRate { get; set; }

        [Required]
        [Display(Name = "Cobra IVA")]
        public bool IsVATCharge { get; set; }
    }
}
