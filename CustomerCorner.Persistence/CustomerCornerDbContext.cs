using CustomerCorner.Domain.Common;
using CustomerCorner.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCorner.Persistence
{
    public class CustomerCornerDbContext : DbContext
    {
        public CustomerCornerDbContext(DbContextOptions<CustomerCornerDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }



        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken =
            new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
