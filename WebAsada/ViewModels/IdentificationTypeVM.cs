using System.ComponentModel.DataAnnotations; 

namespace WebAsada.ViewModels
{
    public class UpdateIdentificationTypeVM : GeneralTableVM
    {
        [Display(Name = "Código")]
        public string IdentificationTypeCode
        {
            get { return GeneralEntityCode; }
            set { GeneralEntityCode = value; }
        }
    }

    public class DetailIdentificationTypeVM : GeneralTableVM
    {
        [Display(Name = "Código")]
        public string IdentificationTypeCode { get; set; }
    }
}
