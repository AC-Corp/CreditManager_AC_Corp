﻿using CreditManager.API.Domain.Models;
using CreditManager.API.Domain.Persistence.Contexts;
using CreditManager.API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Persistence.Repositories
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
        }

        public async Task<Account> FindByAccountNumberAsync(string accountNumber)
        {
            return await _context.Accounts.FindAsync(accountNumber);
        }

        public async Task<Account> FindByOwnerIdAndCompanyIdAsync(int ownerId, int companyId)
        {
            return await _context.Accounts.Where(a => a.OwnerId == ownerId && a.CompanyId == companyId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Account>> ListAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public void Update(Account account)
        {
            _context.Accounts.Update(account);
        }
    }
}
