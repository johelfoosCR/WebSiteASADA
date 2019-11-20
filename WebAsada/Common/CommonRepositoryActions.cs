using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAsada.BaseObjects;
using WebAsada.Data;
using WebAsada.Data.Repository;

namespace WebAsada.Common
{
    public abstract class CommonRepositoryActions<T> : BaseRepository<T>
        where T : BaseEntity
    {
        public CommonRepositoryActions(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        public abstract Task Update(int id, T entity);

        public virtual async Task<T> GetById(int id) => await FindById(id);

        public virtual async Task<IEnumerable<T>> GetAll() => await FindAll();

        public virtual async Task Delete(int id) => await DeleteEntityById(id);

        public virtual async Task Save(T entity) => await SaveNewEntity(entity);

        public virtual async Task<bool> VerifyIfEntityExistById(int id) => await EntityExist(id); 
    }

    public abstract class GeneralEntityCommonRepositoryActions<T> : CommonRepositoryActions<T>
      where T : GeneralEntity
    { 
        public GeneralEntityCommonRepositoryActions(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        { 
        }

        public virtual async Task<IEnumerable<T>> GetGeneralEntityValidData() => await GetValidData<T>();
    }
     
}
