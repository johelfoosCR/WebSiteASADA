using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebAsada.Services
{
    public class YesNoOptions : IYesNoOptions
    {
        public SelectList GetOptions()
        {
            return new SelectList(new List<SelectListItem>() {
                new SelectListItem { Text = "Sí", Value = "True"},
                new SelectListItem { Text = "No", Value = "False"}
            }, "Value", "Text");
        }
    }


    public interface IYesNoOptions: IOptions
    {
    }

    public interface IOptions
    {
        SelectList GetOptions();
    }
}
