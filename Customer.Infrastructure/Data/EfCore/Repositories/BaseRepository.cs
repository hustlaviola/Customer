using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Core.Domain.Models;
using Customer.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Customer.Infrastructure.Data.EfCore.Repositories
{
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : BaseModel
    {
        public readonly DbContext context;
        public BaseRepository(DbContext dbContext)
        {
            context = dbContext;
        }

        public async Task AddAsync(TModel model)
        {
            await context.Set<TModel>().AddAsync(model).ConfigureAwait(false);
        }

        public async Task<TModel> GetAsync(long id)
        {
            return await context.Set<TModel>().FindAsync(id).ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<TModel>> GetAllAsync()
        {
            return await context.Set<TModel>().AsNoTracking().ToListAsync().ConfigureAwait(false);
        }
    }
}