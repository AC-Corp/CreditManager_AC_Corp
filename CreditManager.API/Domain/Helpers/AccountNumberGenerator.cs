using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Domain.Helpers
{
    public class AccountNumberGenerator
    {
        public static string GenerateAccountNumber(string key)
        {
            Random r = new Random();
            int number = r.Next(100, 999);
            return key + number;
        }
    }
}
