using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.DTOs;
using WebAsada.Models;
using WebAsada.Models.Repository;

namespace WebAsada.Controllers
{
    public class EntitiesController : BasicViewControllerActions<Entity, InsertEntityDTO>
    {  
        public EntitiesController(EntityRepository entityRepository): base (entityRepository) { }
         
        public async Task<IActionResult> Index() => await GetIndexViewWhitAllData();

        public IActionResult Create() => View();

        public async Task<IActionResult> Details(int? id) => await GetViewByObjectId(id);

        public async Task<IActionResult> Edit(int? id) => await GetViewByObjectId(id);

        public async Task<IActionResult> Delete(int? id) => await GetViewByObjectId(id);

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) => await ConfirmDelete(id);

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Name,Description,IsGeneralTable")] InsertEntityDTO entity) => await ConfirmSave(new Entity(entity.Name, entity.Description, entity.IsGeneralTable));

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Name,Description,IsGeneralTable,Id")] UpdateEntityDTO entity) => await ConfirmEdit(id, new Entity(entity.Name, entity.Description, entity.IsGeneralTable));
    }
}
