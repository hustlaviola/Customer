using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Core.Domain.Models;
using Customer.Core.DTOs;

namespace Customer.Core.Interfaces
{
    public interface ICustomerService
    {
        Task AddUser(AddUserDTO userDTO);
        Task<GetUserDTO> GetUser(long id);
        Task<IReadOnlyList<GetUserDTO>> GetUsers();
    }
}