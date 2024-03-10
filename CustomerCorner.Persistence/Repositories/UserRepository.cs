using CustomerCorner.Application.Contracts.Persistence;
using CustomerCorner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCorner.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(CustomerCornerDbContext customerCornerDbContext) : base(customerCornerDbContext)
        {
        }
    }
}
