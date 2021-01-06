using CreditManager.API.Domain.Models;
using CreditManager.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Domain.Services
{
   public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> ListAsync();
        Task<TransactionResponse> SaveAsync(Transaction transaction);
    }
}
