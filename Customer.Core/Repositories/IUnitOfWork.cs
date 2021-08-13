using System;
using System.Threading.Tasks;

namespace Customer.Core.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        Task<int> SaveAsync();
    }
}