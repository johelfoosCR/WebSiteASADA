using System.Collections.Generic;
using System.Threading.Tasks;
using WebAsada.BaseObjects;
using WebAsada.Data;
using WebAsada.Data.Repository;

namespace WebAsada.Common
{
    public abstract class CommonRepositoryReaderActions<T> : BaseRepository<T>
       where T : BaseEntity
    {
        public CommonRepositoryReaderActions(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public virtual async Task<T> GetById(int id) => await FindById(id);

        public virtual async Task<IEnumerable<T>> GetAll() => await FindAll();
    }
}
