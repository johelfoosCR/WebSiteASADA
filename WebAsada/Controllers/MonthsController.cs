using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAsada.Common; 
using WebAsada.Models;
using WebAsada.Repository;
using WebAsada.ViewModels;

namespace WebAsada.Controllers
{
    public class MonthsController : BasicViewControllerReadActions<Month, MonthVM>
    {  
        public MonthsController(MonthRepository monthRepository) : base(monthRepository) { }

        public async Task<IActionResult> Index() => await GetIndexViewWhitAllData(); 
    }
}
