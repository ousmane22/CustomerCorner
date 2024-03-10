using CustomerCorner.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomerCorner.Identity
{
    public class CustomerCornerIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public CustomerCornerIdentityDbContext()
        {

        }

        public CustomerCornerIdentityDbContext(DbContextOptions<CustomerCornerIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
        .LogTo(Console.WriteLine)
        .EnableSensitiveDataLogging();

    }
}
