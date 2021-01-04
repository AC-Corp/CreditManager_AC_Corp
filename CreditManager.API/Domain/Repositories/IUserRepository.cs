using CreditManager.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task<string> FindDniById(int id);
        Task<bool> FindByProfileId(int profileId);
        Task AddAsync(User user);
    }
}
