using Customer.Core.Domain.Models;
using Customer.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Customer.Infrastructure.Data.EfCore.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
            
        }
    }
}