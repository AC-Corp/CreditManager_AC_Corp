using CreditManager.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Domain.Services.Communications
{
    public class AccountResponse : BaseResponse<Account>
    {
        public AccountResponse(Account resource) : base(resource)
        {
        }

        public AccountResponse(string message) : base(message)
        {
        }
    }
}
