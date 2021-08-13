using System;
using System.Collections.Generic;
using Customer.Core.Domain.Models;
using Customer.Core.Repositories;
using Customer.Infrastructure.Data.EfCore;
using Customer.Infrastructure.Data.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Customer.UnitTest
{
    public class CustomerTest
    {
        private DbContextOptions<CustomerDbContext> options;

        public CustomerTest()
        {
            options = new DbContextOptionsBuilder<CustomerDbContext>()
            .UseInMemoryDatabase(databaseName: "Customers")
            .Options;
        }

        [Fact]
        public async void Add_User_Successful()
        {
            // Arrange
            var user1 = new User { Id = 1, FirstName = "Viola", LastName = "Vino" };
            var user2 = new User { Id = 2, FirstName = "Viola", LastName = "Vino" };
            var context1 = new CustomerDbContext(options);
            var context2 = new CustomerDbContext(options);
            IReadOnlyList<User> users;

            // Act
            await context1.Users.AddAsync(user1);
            await context1.Users.AddAsync(user2);
            await context1.SaveChangesAsync();
            await context1.DisposeAsync();

            var userRepository = new UserRepository(context2);
            users = await userRepository.GetAllAsync();
            await context2.DisposeAsync();

            //Assert
            Assert.Equal(2, users.Count);
        }

        [Fact]
        public async void User_Not_Null()
        {
            // Arrange
            var user = new User { Id = 1, FirstName = "Viola", LastName = "Vino" };
            var searchId = 1;
            var context = new CustomerDbContext(options);

            // Act
            await context.Users.AddAsync(user);

            var userRepository = new UserRepository(context);
            var dbUser = await userRepository.GetAsync(searchId);
            await context.DisposeAsync();

            // Assert
            Assert.NotNull(dbUser);
        }

        [Fact]
        public async void User_Id_Equals_Expected()
        {
            // Arrange
            var user = new User { Id = 1, FirstName = "Viola", LastName = "Vino" };
            var expectedId = user.Id;
            var searchId = 1;
            var context = new CustomerDbContext(options);

            // Act
            await context.Users.AddAsync(user);

            var userRepository = new UserRepository(context);
            var dbUser = await userRepository.GetAsync(searchId);
            await context.DisposeAsync();

            // Assert
            Assert.Equal(expectedId, user.Id);
        }
    }
}