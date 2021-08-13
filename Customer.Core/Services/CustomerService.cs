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

        public async Task<GetUserDTO> GetUser(long id)
        {
            GetUserDTO userDTO = new GetUserDTO();
            var user = await _unitOfWork.UserRepository.GetAsync(id);
            userDTO.FirstName = user.FirstName;
            userDTO.LastName = user.LastName;
            userDTO.MiddleName = user.MiddleName;
            userDTO.DateOfBirth = user.DateOfBirth;
            userDTO.EmailAddress = user.EmailAddress;
            userDTO.AccountNumber = user.AccountNumber;
            userDTO.PhoneNumber = user.PhoneNumber;
            userDTO.Gender = user.Gender.ToString();
            userDTO.Address = user.Address;
            userDTO.DateCreated = user.DateCreated;
            return userDTO;
        }

        public async Task<IReadOnlyList<GetUserDTO>> GetUsers()
        {
            List<GetUserDTO> userDTOs = new List<GetUserDTO>();
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            foreach (var user in users)
            {
                userDTOs.Add(new GetUserDTO
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    MiddleName = user.MiddleName,
                    DateOfBirth = user.DateOfBirth,
                    EmailAddress = user.EmailAddress,
                    AccountNumber = user.AccountNumber,
                    PhoneNumber = user.PhoneNumber,
                    Gender = user.Gender.ToString(),
                    Address = user.Address,
                    DateCreated = user.DateCreated
                });
            }
            return userDTOs.AsReadOnly();
        }
    }
}