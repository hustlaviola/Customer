using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Core.Domain.Enums;
using Customer.Core.Domain.Models;
using Customer.Core.DTOs;
using Customer.Core.Interfaces;
using Customer.Core.Repositories;

namespace Customer.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddUser(AddUserDTO userDTO)
        {
            Enum.TryParse(userDTO.Gender, out Gender gender);
            Console.WriteLine(userDTO.FirstName);
            var user = new User()
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                MiddleName = userDTO.MiddleName,
                DateOfBirth = userDTO.DateOfBirth,
                EmailAddress = userDTO.EmailAddress,
                AccountNumber = userDTO.AccountNumber,
                PhoneNumber = userDTO.PhoneNumber,
                Gender = gender,
                Address = userDTO.Address
            };

            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.SaveAsync();
        }

        public async Task<User> GetUser(long id)
        {
            return await _unitOfWork.UserRepository.GetAsync(id);
        }

        public async Task<IReadOnlyList<User>> GetUsers()
        {
            return await _unitOfWork.UserRepository.GetAllAsync();
        }
    }
}