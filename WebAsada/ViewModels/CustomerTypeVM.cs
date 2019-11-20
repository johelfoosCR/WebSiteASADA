using System.ComponentModel.DataAnnotations; 

namespace WebAsada.ViewModels
{ 
    public class UpdateCustomerTypeVM : GeneralTableVM
    {  
        [Display(Name = "Código Tipo de Persona")]
        public string PersonTypeCode
        {
            get { return GeneralEntityCode; }
            set { GeneralEntityCode = value; }
        }
    }

    public class DetailCustomerTypeDTO : GeneralTableVM
    {
        [Display(Name = "Código Tipo de Persona")]
        public string PersonTypeCode { get; set; }
    }
}
