using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Core.DTOs;
using Customer.Core.Interfaces;
using Customer.Core.Repositories;
using Customer.Core.Services;
using Customer.Infrastructure.Data.EfCore;
using Customer.Infrastructure.Data.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Customer.UserTests.IntegrationTest
{
    public class GetSingleUserTest
    {
        private DbContextOptions<CustomerDbContext> options;
        private CustomerDbContext _context;
        private IUnitOfWork _unitOfWork;
        private ICustomerService _customerService;

        public GetSingleUserTest()
        {
            options = new DbContextOptionsBuilder<CustomerDbContext>()
            .UseInMemoryDatabase(databaseName: "GetSingleUserTest")
            .Options;
            _context = new CustomerDbContext(options);
            _unitOfWork = new UnitOfWork(_context);
            _customerService = new CustomerService(_unitOfWork);
        }

        [Fact]
        public async void Get_User_Successful()
        {
            // Arrange
            long userId = 1;
            GetUserDTO user;
            GetUserDTO expectedUser = new GetUserDTO
            {
                FirstName = "Victor",
                MiddleName = "Olamide",
                LastName = "Olatunde",
                Gender = "Male",
                DateOfBirth = Convert.ToDateTime("11-16-1989"),
                EmailAddress = "hustlaviola@gmail.com",
                AccountNumber = "2033445566",
                Address = "No 2, Viola Street",
                PhoneNumber = "08033445566"
            };

            // Act
            await SaveUserAsync();
            user = await _customerService.GetUser(userId);

            //Assert
            Assert.Equal(user.FirstName, expectedUser.FirstName);
        }

        [Fact]
        public async void MiddleName_Is_Match()
        {
            // Arrange
            long userId = 1;
            GetUserDTO user;

            // Act
            user = await _customerService.GetUser(userId);

            //Assert
            Assert.Equal("Olamide", user.MiddleName);
        }

        [Fact]
        public async void Email_Is_Match()
        {
            // Arrange
            long userId = 1;
            GetUserDTO user;

            // Act
            user = await _customerService.GetUser(userId);

            //Assert
            Assert.Equal("hustlaviola@gmail.com", user.EmailAddress);
        }

        private async Task SaveUserAsync()
        {
            var userDto = new AddUserDTO
            {
                FirstName = "Victor",
                MiddleName = "Olamide",
                LastName = "Olatunde",
                Gender = "Male",
                DateOfBirth = Convert.ToDateTime("11-16-1989"),
                EmailAddress = "hustlaviola@gmail.com",
                AccountNumber = "2033445566",
                Address = "No 2, Viola Street",
                PhoneNumber = "08033445566"
            };
            await _customerService.AddUser(userDto);
        }
    }
}
