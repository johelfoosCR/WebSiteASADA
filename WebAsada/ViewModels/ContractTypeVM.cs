using System.ComponentModel.DataAnnotations;

namespace WebAsada.ViewModels
{ 
    public class UpdateContractTypeVM : GeneralTableVM
    {
        [Display(Name = "Código")]
        public string ContractTypeCode
        {
            get { return GeneralEntityCode; }
            set { GeneralEntityCode = value; }
        } 
    }

    public class DetailContractTypeVM : GeneralTableVM
    {
        [Display(Name = "Código")]
        public string ContractTypeCode { get; set; } 
    }
}
