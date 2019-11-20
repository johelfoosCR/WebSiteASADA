using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic; 
using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.Data;
using WebAsada.Models;

namespace WebAsada.Repository
{
    public class ReceiptRepository : CommonRepositoryActions<Receipt>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<IdentityUser> users; 

        public ReceiptRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbContext = applicationDbContext;
            users = _dbContext.Users; 
        }

        public async override Task<IEnumerable<Receipt>> GetAll()
        {
            return await _dbContext.Receipt.Include(m => m.RegisterUser).Include(m => m.Contract).ToListAsync();
        }

        public async override Task<Receipt> GetById(int id)
        {
            return await _dbContext.Receipt.Include(m => m.Contract)
                                            .Include(m => m.RegisterUser) 
                                            .FirstOrDefaultAsync(m => m.Id == id);
        }

        public DbSet<IdentityUser> GetUsers()
        {
            return users;
        }

        public override Task Update(int id, Receipt entity)
        {
            throw new System.NotImplementedException();
        }
    }

}
