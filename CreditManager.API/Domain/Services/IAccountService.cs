using CreditManager.API.Domain.Models;
using CreditManager.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Domain.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> ListAsync();
        Task<AccountResponse> SaveAsync(Account account);
        Task<AccountResponse> UpdateInterestAsync(string accountNumber, Account account);
        Task<AccountResponse> UpdateAmountAsync(string accountNumber, Account account);
    }
}
