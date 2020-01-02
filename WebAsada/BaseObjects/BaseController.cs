using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAsada.BaseObjects
{
    public class BaseController: Controller
    { 
        public ActionResult ErrorContent(string errorMessage)
        {
            return Json(new { hasError = true, message = errorMessage });
        }
    }
}
