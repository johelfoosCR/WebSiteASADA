using System.ComponentModel.DataAnnotations;
namespace WebAsada.ViewModels
{
    public class UpdateChargeTypeVM : ChargeTypeVMBase
    {
        [Display(Name = "Código")]
        public string ChargeTypeCode
        {
            get { return GeneralEntityCode; }
            set { GeneralEntityCode = value; }
        } 
    }

    public class DetailsChargeTypeVM : ChargeTypeVMBase
    {
        [Display(Name = "Código")]
        public string ChargeTypeCode { get; set; } 
    }

    public abstract class ChargeTypeVMBase : GeneralTableVM
    {

        [Display(Name = "Porcentaje IVA")]
        public double VatRate { get; set; }

        [Required]
        [Display(Name = "Cobra IVA")]
        public bool IsVATCharge { get; set; }

        [Required]
        [Display(Name = "Es consumo Agua")]
        public bool IsWaterConsume { get; set; }
         
        [Required]
        [Display(Name = "Tarifa Base")]
        public bool IsBaseFare { get; set; }
    }
}