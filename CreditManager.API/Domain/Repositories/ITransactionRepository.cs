﻿using CreditManager.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Domain.Repositories
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> ListAsync();
        Task AddAsync(Transaction transaction);
    }
}
