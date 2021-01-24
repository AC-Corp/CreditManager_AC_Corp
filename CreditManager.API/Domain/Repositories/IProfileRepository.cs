﻿using CreditManager.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Domain.Repositories
{
    public interface IProfileRepository
    {
        Task<IEnumerable<Profile>> ListAsync();

        Task AddAsync(Profile profile);
    }
}
