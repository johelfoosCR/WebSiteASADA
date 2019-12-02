using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAsada.BaseObjects;
using WebAsada.Data;
using WebAsada.Data.Repository;
using WebAsada.ViewModels;

namespace WebAsada.Common
{
    public interface IUpdatebleEntity<T>
    {
        Task Update(int id, T entity);
    }

    public abstract class CommonRepositoryActions<T> : BaseRepository<T>
        where T : BaseEntity
    {
        public CommonRepositoryActions(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        } 

        public virtual async Task<T> GetById(int id) => await FindById(id);

        public virtual async Task<IEnumerable<T>> GetAll() => await FindAll();

        public virtual async Task Delete(int id) => await DeleteEntityById(id);

        public virtual async Task Save(T entity) => await SaveNewEntity(entity);

        public virtual async Task<bool> VerifyIfEntityExistById(int id) => await EntityExist(id);
         
    }

    public abstract class CommonRepositoryEditorActions<T> : CommonRepositoryActions<T>, IUpdatebleEntity<T>
        where T : BaseEntity
    {
        public CommonRepositoryEditorActions(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public abstract Task Update(int id, T entity);
    }

    public abstract class GeneralEntityCommonRepositoryActions<T> : CommonRepositoryEditorActions<T>
      where T : GeneralEntity
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GeneralEntityCommonRepositoryActions(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
          
        public async Task<IEnumerable<SelectItemVM<int>>> GetGeneralEntityValidData()
        {
           return  await _applicationDbContext.Set<T>()
                                              .Where(x => x.IsActive.Equals(true))
                                              .Select(x => SelectItemVM<int>.Create(x.Id, x.ShortDesc))
                                              .ToListAsync();
        }

        public async Task<IEnumerable<SelectItemVM<int>>> GetValueByNemotecnic(string nemotecnico)
        {
            return await _applicationDbContext.Set<T>()
                                               .Where(x => x.Nemotecnico.Equals(nemotecnico))
                                               .Select(x => SelectItemVM<int>.Create(x.Id, x.ShortDesc))
                                               .ToListAsync();
        }
    }
}
