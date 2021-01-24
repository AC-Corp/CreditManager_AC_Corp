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
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<bool> FindByProfileId(int profileId)
        {
            var profile = await _context.Profiles.Where(u => u.Id == profileId).FirstOrDefaultAsync();
            return profile!=null;
        }

        public async Task<string> FindDniById(int id)
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
