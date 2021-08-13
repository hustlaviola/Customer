using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Core.Domain.Models;

namespace Customer.Core.Repositories
{
    public interface IBaseRepository<TModel> where TModel : BaseModel
    {
        Task<TModel> GetAsync(long id);
        Task AddAsync(TModel model);
        Task<IReadOnlyList<TModel>> GetAllAsync();
    }
}