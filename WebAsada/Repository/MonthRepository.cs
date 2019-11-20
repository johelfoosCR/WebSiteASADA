using WebAsada.Common;
using WebAsada.Data;
using WebAsada.Models;

namespace WebAsada.Repository
{
    public class MonthRepository : CommonRepositoryReaderActions<Month>
    {
        public MonthRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        } 
    } 
}
