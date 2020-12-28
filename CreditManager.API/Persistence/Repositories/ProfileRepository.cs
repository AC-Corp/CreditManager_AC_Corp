using CreditManager.API.Domain.Persistence.Contexts;
using CreditManager.API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Persistence.Repositories
{
    public class ProfileRepository : BaseRepository, IProfileRepository
    {
        public ProfileRepository(AppDbContext context) : base(context) { }
    }
}
