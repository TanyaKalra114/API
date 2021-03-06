using InsuranceAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace InsuranceAPI.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions options) : base(options)
        {
        }

        //Dbset
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car>Cars { get; set; }
        public DbSet<Claim> Claims { get; set; }

    }
}
