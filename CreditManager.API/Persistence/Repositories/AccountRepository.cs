using CreditManager.API.Domain.Persistence.Contexts;
using CreditManager.API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Persistence.Repositories
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(AppDbContext context) : base(context) { }
    }
}
