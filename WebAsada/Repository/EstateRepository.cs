using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.Data;
using WebAsada.Models;

namespace WebAsada.Repository
{
    public class EstateRepository : CommonRepositoryEditorActions<Estate>, IUpdatebleEntity<Estate>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EstateRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public override async Task<Estate> GetById(int id)
        {
            return await _applicationDbContext.Estate
                                              .Where(x => x.Id.Equals(id))
                                              .Include(m => m.PersonsByEstateCollection)
                                              .ThenInclude(x => x.Person)
                                              .FirstOrDefaultAsync(); 
        }
           
        public override async Task Update(int id, Estate newCharge)
        {
            MarkAsUpdated(Estate.SincronizeObject(currentState: await GetById(id), newCharge));
            await SaveChanges();
        } 
    }
}
