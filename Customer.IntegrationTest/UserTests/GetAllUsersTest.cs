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
    public class GetAllUsersTest
    {
        private DbContextOptions<CustomerDbContext> options;
        private CustomerDbContext _context;
        private IUnitOfWork _unitOfWork;
        private ICustomerService _customerService;

        public GetAllUsersTest()
        {
            options = new DbContextOptionsBuilder<CustomerDbContext>()
            .UseInMemoryDatabase(databaseName: "GetAllUsersTest")
            .Options;
            _context = new CustomerDbContext(options);
            _unitOfWork = new UnitOfWork(_context);
            _customerService = new CustomerService(_unitOfWork);
        }

        [Fact]
        public async void Get_All_User_Successful()
        {
            // Arrange
            IReadOnlyList<GetUserDTO> users;

            // Act
            await SaveUsersAsync();
            users = await _customerService.GetUsers();

            //Assert
            Assert.True(users.Count == 2);
        }

        [Fact]
        public async void User_2_LastName_Is_Match()
        {
            // Arrange
            IReadOnlyList<GetUserDTO> users;

            // Act
            users = await _customerService.GetUsers();

            //Assert
            Assert.Equal("Brain", users[1].LastName);
        }

        private async Task SaveUsersAsync()
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

            var userDto2 = new AddUserDTO
            {
                FirstName = "Femi",
                MiddleName = "Johnson",
                LastName = "Brain",
                Gender = "Female",
                DateOfBirth = Convert.ToDateTime("11-16-1999"),
                EmailAddress = "hustlaviola@yahoo.com",
                AccountNumber = "2033445522",
                Address = "No 2, Viola Street",
                PhoneNumber = "08033115566"
            };
            await _customerService.AddUser(userDto);
            await _customerService.AddUser(userDto2);
        }
    }
}