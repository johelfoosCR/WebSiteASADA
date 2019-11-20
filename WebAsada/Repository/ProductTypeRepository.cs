using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAsada.Common;
using WebAsada.Data;
using WebAsada.Models;

namespace WebAsada.Repository
{
    public class ProductTypeRepository : GeneralEntityCommonRepositoryActions<ProductType>
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductTypeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
         
        public override async Task Update(int id, ProductType productType)
        {
            MarkAsUpdated(ProductType.SincronizeObject(currentObject: await GetById(id), newObject:productType));
            await SaveChanges();
        }
    }
}
