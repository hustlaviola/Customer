using System;
using System.Collections.Generic;
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
    public class CreateUserTest
    {
        private DbContextOptions<CustomerDbContext> options;
        private CustomerDbContext _context;
        private IUnitOfWork _unitOfWork;
        private ICustomerService _customerService;

        public CreateUserTest()
        {
            options = new DbContextOptionsBuilder<CustomerDbContext>()
            .UseInMemoryDatabase(databaseName: "CreateUserTest")
            .Options;
            _context = new CustomerDbContext(options);
            _unitOfWork = new UnitOfWork(_context);
            _customerService = new CustomerService(_unitOfWork);
        }

        [Fact]
        public async void Add_User_Successful()
        {
            // Arrange
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
            IReadOnlyList<GetUserDTO> users;

            // Act
            await _customerService.AddUser(userDto);
            users = await _customerService.GetUsers();

            //Assert
            Assert.Single(users);
        }
    }
}