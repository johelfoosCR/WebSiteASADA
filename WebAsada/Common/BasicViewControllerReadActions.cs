using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAsada.BaseObjects;
using WebAsada.Helpers;

namespace WebAsada.Common
{
    public class BasicViewControllerReadActions<T, V> : Controller where T : BaseEntity
    {
        private readonly CommonRepositoryReaderActions<T> _repository;
        private readonly MapperConfiguration _mapperConfiguration;

        public BasicViewControllerReadActions(CommonRepositoryReaderActions<T> repository)
        {
            _repository = repository;
            _mapperConfiguration = new MapperConfiguration(cfg => { cfg.CreateMap<T, V>(); });
        }
         

        public async Task<IActionResult> GetViewByObjectId(int? id)
        {
            if (!id.HasValue) return NotFound();

            var entity = await _repository.GetById(id.Value);

            return entity.HasValue() ? (IActionResult)base.View(MapperHelper<T,V>.MapEntity(_mapperConfiguration,entity)) : base.NotFound();
        }
 
        public async Task<IActionResult> GetIndexViewWhitAllData() { 
            return View(MapperHelper<T, V>.MapEnumerable(_mapperConfiguration, await _repository.GetAll()));
        }
          
    }
}
