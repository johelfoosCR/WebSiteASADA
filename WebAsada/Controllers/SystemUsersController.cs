using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAsada.Repository;
using WebAsada.ViewModels;

namespace WebAsada.Controllers
{
    public class SystemUsersController: Controller
    { 
        private const string ATTRIBUTES_TO_BIND = "Id,UserName,FullName,Password,ConfirmPassword,IsAdministrator,IsActive,IsOperational";

        private readonly SystemUserRepository _repository;   


        public SystemUsersController(SystemUserRepository repository) 
        {
             _repository = repository;
         }

        public async Task<IActionResult> Index() 
        {           
            return View(await _repository.GetAll());
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(ATTRIBUTES_TO_BIND)] SystemUserVM UpdateVm) {
            return Ok();    
        }

    }
}