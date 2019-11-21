using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAsada.ViewModels;

namespace WebAsada.Components
{
    public class PersonListWidget : ViewComponent
    { 
        public PersonListWidget()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync(SelectItemVM<int>[] listPerson, SelectItemVM<int> personItemVM)
        { 
            if (!listPerson.HasValue())
            {
                listPerson = Array.Empty<SelectItemVM<int>>();
            }


            Array.Resize(ref listPerson, listPerson.Length + 1);
            if (personItemVM.HasValue())
            {
                listPerson.SetValue(personItemVM,0);
            }
            return View(listPerson);
        }
    }
}
