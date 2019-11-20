using System.ComponentModel.DataAnnotations;

namespace WebAsada.ViewModels
{ 
    public class UpdatePersonTypeVM : GeneralTableVM
    {
        [Display(Name = "Código Tipo de Persona")]
        public string PersonTypeCode
        {
            get { return GeneralEntityCode; }
            set { GeneralEntityCode = value; }
        }
    }

    public class DetailPersonTypeVM : GeneralTableVM
    {
        [Display(Name = "Código Tipo de Persona")]
        public string PersonTypeCode { get; set; }
    }
}
