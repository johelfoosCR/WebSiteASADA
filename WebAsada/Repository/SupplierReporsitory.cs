using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.Data;
using WebAsada.Models;
using WebAsada.ViewModels;

namespace WebAsada.Repository
{
    public class SupplierReporsitory : CommonRepositoryEditorActions<Supplier>, IUpdatebleEntity<Supplier>
    {
        private readonly ApplicationDbContext _dbContext; 

        public DbSet<Month> Months { get; }

        public SupplierReporsitory(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbContext = applicationDbContext; 
        }

        public async override Task<IEnumerable<Supplier>> GetAll()
        {
            return await _dbContext.Supplier.Include(m => m.ProductType) 
                                            .ToListAsync();
        } 
         

        public async Task<IEnumerable<SelectItemVM<int>>> GetValidSupplierByNemotecnicoToView(string nemotecnico)
        {
            return await _dbContext.Supplier.Where(x => x.IsActive.Equals(true) 
                                                     && x.ProductType.Nemotecnico.Equals(nemotecnico))
                                            .Select(x => SelectItemVM<int>.Create(x.Id, x.Name))
                                            .ToListAsync();
        }

        public async override Task<Supplier> GetById(int id)
        {
            return await _dbContext.Supplier.Include(m => m.ProductType)
                                            .SingleAsync(x => x.Id.Equals(id));
        }
         
        public override async Task Update(int id, Supplier entity)
        {
            Supplier.SincronizeObject(currentObject: await GetById(id), newObject: entity);
            await SaveChanges();
        }
    }

}
