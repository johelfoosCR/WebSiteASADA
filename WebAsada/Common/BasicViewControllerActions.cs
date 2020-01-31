using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAsada.BaseObjects;
using WebAsada.Global;
using WebAsada.Helpers;

namespace WebAsada.Common
{
    public class BasicViewControllerActions<T> : BaseController where T : BaseEntity
    {
        private readonly CommonRepositoryEditorActions<T> _repository; 

        public BasicViewControllerActions(CommonRepositoryEditorActions<T> repository)
        {
            _repository = repository; 
        }

        #region ReadActions

        protected async Task<IActionResult> GetViewByObjectId<DtoType> (int? id)
        {
            if (!id.HasValue) return NotFound();

            var entity = await _repository.GetById(id.Value);

            var mappedEntity = MapperHelper<T, DtoType>.MapEntity(new MapperConfiguration(cfg => { cfg.CreateMap<T, DtoType>(); }), entity);

            return entity.HasValue() ? (IActionResult)base.View(mappedEntity) : base.NotFound();
        }

        protected async Task<IActionResult> GetViewByObjectId<DtoType>(int? id, Action beforeExecution)
        {
            beforeExecution.Invoke();
            return await GetViewByObjectId<DtoType>(id);
        }
        protected async Task<IActionResult> GetViewByObjectId<DtoType>(int? id, Func<Task> beforeExecution)
        {
            await beforeExecution.Invoke();
            return await GetViewByObjectId<DtoType>(id);
        }

        protected IActionResult GetView(Action beforeExecution)
        {
            beforeExecution?.Invoke();
            return View();
        }

        protected IActionResult GetView()
        { 
            return View();
        }

        protected async Task<IActionResult> GetIndexViewWhitAllData<DtoType>()
        { 
            return View(MapperHelper<T, DtoType>.MapEnumerable(new MapperConfiguration(cfg => { cfg.CreateMap<T, DtoType>(); }), await _repository.GetAll()));
        }

        private async Task<bool> EntityExists(int id)
        {
            return await _repository.VerifyIfEntityExistById(id);
        }

        #endregion

        #region Delete Actions
        protected async Task<IActionResult> ConfirmDelete(int id)
        {
            await _repository.Delete(id);
            TempData["javascriptMessage"] = Constants.JAVASCRIPT_DELETE_FUNCTION;
            return RedirectToAction("Index");
        }
        #endregion

        #region Update Actions
         
        protected async Task<IActionResult> ConfirmEdit<DtoType>(int? id, DtoType dtoObject, Action BeforeExecute)
        {
            BeforeExecute.Invoke();
            return await ConfirmEdit(id, dtoObject);
        }

        protected async Task<IActionResult> ConfirmEdit<DtoType>(int? id, DtoType dtoObject, Func<Task> BeforeExecute)
        {
            await BeforeExecute.Invoke();
            return await ConfirmEdit(id, dtoObject);
        }


        protected async Task<IActionResult> ConfirmEdit<DtoType>(int? id, DtoType dtoObject)
        {
            if (!id.HasValue) return NotFound(); 
            T entity = CreateInstanceFromDTO(dtoObject);  
            return  await ConfirmUpdateConcrete(id, entity, dtoObject); 
        }

        #endregion

        #region Save Actions 

        protected async Task<IActionResult> ConfirmSave<DtoType>(DtoType dtoObject, Action BeforeExecute)
        {
            BeforeExecute.Invoke();
            return await ConfirmSave(dtoObject);
        }

        protected async Task<IActionResult> ConfirmSave<DtoType>(DtoType dtoObject, Func<Task> BeforeExecute)
        {
            await BeforeExecute.Invoke();
            return await ConfirmSave(dtoObject);
        }

        protected async Task<IActionResult> ConfirmSave<DtoType>(DtoType dtoObject)
        {
            T instance = CreateInstanceFromDTO(dtoObject);
            return await ConfirmSaveConcrete(dtoObject, instance);
        }

        protected async Task<IActionResult> ConfirmSaveConcrete<DtoType>(DtoType dtoObject, T instance)
        {
            if (ModelState.IsValid)
            {
                TempData["javascriptMessage"] = Constants.JAVASCRIPT_SUCCESS_FUNCTION;
                await _repository.Save(instance);
                return RedirectToAction("Index");
            }

            return View(dtoObject);
        }


        protected async Task<IActionResult> ConfirmUpdateConcrete<DtoType>(int? id, T entity, DtoType dtoObject)
        {
            if (ModelState.IsValid)
            {
                try
                {
                  await _repository.Update(id.Value, entity);
                }
                catch (Exception ex)
                {
                    if (!await EntityExists(entity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                TempData["javascriptMessage"] = Constants.JAVASCRIPT_UPDATE_FUNCTION;
                return RedirectToAction("Index");
            }

            return View(dtoObject);
        }

        #endregion

        #region Local utilities
        private T CreateInstanceFromDTO<DtoType>(DtoType dtoObject)
        {
            var mapperSave = new MapperConfiguration(cfg => { cfg.CreateMap<DtoType, T>(); }); 
            return MapperHelper<DtoType, T>.MapEntity(mapperSave, dtoObject);
        }
        #endregion

    }
}
