using System.ComponentModel.DataAnnotations; 

namespace WebAsada.ViewModels
{
    public class UpdateProductTypeVM : GeneralTableVM
    {
        [Display(Name = "Código")]
        public string ProductTypeCode
        {
            get { return GeneralEntityCode; }
            set { GeneralEntityCode = value; }
        }
    }

    public class DetailProductTypeVM : GeneralTableVM
    {
        [Display(Name = "Código")]
        public string ProductTypeCode { get; set; }
    }
}
