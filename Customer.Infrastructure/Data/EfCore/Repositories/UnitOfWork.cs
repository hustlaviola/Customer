using System;
using System.Threading.Tasks;
using Customer.Core.Repositories;

namespace Customer.Infrastructure.Data.EfCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CustomerDbContext _context;
        public UnitOfWork(CustomerDbContext context)
        {
            _context = context;
        }
        public IUserRepository UserRepository => new UserRepository(_context);

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

    }
}