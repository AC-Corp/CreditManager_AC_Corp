using CreditManager.API.Domain.Models;
using CreditManager.API.Domain.Persistence.Contexts;
using CreditManager.API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Persistence.Repositories
{
    public class TransactionRepository : BaseRepository, ITransactionRepository
    {
        public TransactionRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Transaction>> ListAsync()
        {
            return await _context.Transactions.ToListAsync();
        }
    }
}
