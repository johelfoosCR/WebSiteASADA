using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebAsada.Services
{
    public class YesNoOptions : IYesNoOptions
    {
        public SelectList GetOptions(bool addDefaultOption = false)
        {
            var listElements = new List<SelectListItem>();
            if (addDefaultOption) listElements.Add(new SelectListItem { Text = "Seleccione una opción", Value = "", Selected = true });
            listElements.Add(new SelectListItem { Text = "Sí", Value = "True", Selected = false });
            listElements.Add(new SelectListItem { Text = "No", Value = "False", Selected = false }); 

            return new SelectList(listElements, "Value", "Text");
        }
    }


    public interface IYesNoOptions: IOptions
    {
    }

    public interface IOptions
    {
        SelectList GetOptions(bool addDefaultOption = false);
    }
}
