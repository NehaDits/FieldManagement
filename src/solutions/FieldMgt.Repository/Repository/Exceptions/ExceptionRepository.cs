using FieldMgt.Core.DomainModels;
using FieldMgt.Core.Interfaces;
using FieldMgt.Repository.UOW;
using System.Threading.Tasks;

namespace FieldMgt.Repository.Repository.Exceptions
{
    public class ExceptionRepository : GenericRepository<ExceptionLog>,IExceptionInterface
    {
        private readonly ApplicationDbContext _dbContext;
        public ExceptionRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task SaveLogs(ExceptionLog model)
        {
            await InsertAsync(model);
            await _dbContext.SaveChangesAsync();
        }
    }
}
