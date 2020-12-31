using CreditManager.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Domain.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> ListAsync();

        Task AddAsync(Account account);

        Task<Account> FindByOwnerIdAndCompanyIdAsync(int ownerId, int companyId); 
    }
}
