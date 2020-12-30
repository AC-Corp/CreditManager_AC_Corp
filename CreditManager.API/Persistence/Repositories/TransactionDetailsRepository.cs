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
    public class TransactionDetailsRepository : BaseRepository, ITransactionDetailsRepository
    {
        public TransactionDetailsRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<TransactionDetails>> ListAsync()
        {
            return await _context.TransactionDetails.ToListAsync();
        }
    }
}
