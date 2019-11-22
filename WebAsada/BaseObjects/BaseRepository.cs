using Microsoft.EntityFrameworkCore; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAsada.BaseObjects;
using WebAsada.ViewModels;

namespace WebAsada.Data.Repository
{
    public abstract class BaseRepository<EntityType>
        where EntityType : BaseEntity
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext; 
        }

        protected void Add(EntityType entity) => _applicationDbContext.Add(entity);

        protected void Delete(EntityType entity) => _applicationDbContext.Remove(entity);

        protected void MarkAsUpdated(EntityType entity) => _applicationDbContext.Entry(entity).State = EntityState.Modified;

        protected Task<EntityType> FindById(int Id) => _applicationDbContext.Set<EntityType>().FirstOrDefaultAsync(x => x.Id.Equals(Id));

        protected async Task<bool> EntityExist(int? Id) => Id.HasValue ? await _applicationDbContext.Set<EntityType>().AnyAsync(x => x.Id.Equals(Id.Value)) : false;

        protected async Task<IEnumerable<EntityType>> FindAll() => await _applicationDbContext.Set<EntityType>().ToListAsync();

        protected async Task<int> SaveChanges() => await _applicationDbContext.SaveChangesAsync();
         
        protected async Task<IEnumerable<SelectItemVM<int>>> GetValidData<T>() where T : GeneralEntity =>
             await _applicationDbContext.Set<T>()
                                        .Where(x => x.IsActive.Equals(true))
                                        .Select(x => SelectItemVM<int>.Create(x.Id, x.ShortDesc))
                                        .ToListAsync();
        protected async Task<int> SaveNewEntity(EntityType entity)
        {
            Add(entity);
            return await SaveChanges();
        }
        protected async Task DeleteEntityById(int id)
        {
            var entityToDelete = await FindById(id);
            Delete(entityToDelete);
            await SaveChanges();
        }

    }
}