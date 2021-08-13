using Customer.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer.Infrastructure.Data.EfCore
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}