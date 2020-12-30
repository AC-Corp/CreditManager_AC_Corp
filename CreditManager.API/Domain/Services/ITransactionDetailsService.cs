using CreditManager.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Domain.Services
{
    public interface ITransactionDetailsService
    {
        Task<IEnumerable<TransactionDetails>> ListAsync();
    }
}
