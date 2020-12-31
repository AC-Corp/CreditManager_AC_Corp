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
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task<string> GetDniById(int id)
        {
            var user = await _context.Users.Include(u => u.Profile).Where(u => u.Id == id).FirstOrDefaultAsync();
            return user.Profile.Dni; 
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
