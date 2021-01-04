using CreditManager.API.Domain.Models;
using System;
using CreditManager.API.Domain.Services.Communications;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<bool> FindByProfileId(int profileId);
        Task<UserResponse> SaveAsync(User user);
    }
}
