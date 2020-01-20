using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAsada.Global;
using WebAsada.Models;
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

        public IActionResult Create() => View(new SystemUserVM());

        public async Task<IActionResult> Edit(string id) => await GetViewByUserId(id);

        public async Task<IActionResult> ChangePassword(string id) => await GetViewByUserId(id);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(ATTRIBUTES_TO_BIND)] SystemUserVM UpdateVm)
        { 
            if (ModelState.IsValid)
            {
                var username = UserName.Create(UpdateVm.UserName);
                var password = Password.Create(UpdateVm.Password);
                var result = Result.Combine("|", username, password); 

                if (result.IsSuccess)
                {
                    TempData["javascriptMessage"] = Constants.JAVASCRIPT_SUCCESS_FUNCTION;
                    await _repository.Save(SystemUser.CreateOperational(username.Value,
                                                                        UpdateVm.FullName,
                                                                        password.Value,
                                                                        UpdateVm.IsAdministrator));
                    return RedirectToAction("Index");
                }
                else { 
                    Array.ForEach(result.Error.Split('|'), x => ModelState.AddModelError(string.Empty, x));
                }
            }

            return View(UpdateVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword([Bind(ATTRIBUTES_TO_BIND)] SystemUserVM UpdateVm)
        {
            if (ModelState.IsValid)
            {
                var newPassword = Password.Create(UpdateVm.Password); 

                if (newPassword.IsSuccess)
                { 
                    TempData["javascriptMessage"] = string.Format(Constants.JAVASCRIPT_WHIT_MESSAGE_FUNCTION,"Cambio de contraseña Exitoso!!");
                    var result = await _repository.UpdatePassword(UpdateVm.Id, newPassword.Value);
                    return result.IsSuccess ? (IActionResult)RedirectToAction("Index") : NotFound(result.Error);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, newPassword.Error);
                }
            }

            return View(UpdateVm);
        }


        private async Task<IActionResult> GetViewByUserId(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var entity = await _repository.GetById(id);

            return entity.HasValue ? (IActionResult)base.View(entity.Value) : base.NotFound();
        }
    }
}