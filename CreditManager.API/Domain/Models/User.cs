using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //public IList<Account> Accounts { get; set; } = new List<Account>();

        //TEST DE EF Core
        public IList<Account> CustomerAccounts { get; set; } = new List<Account>();
        public IList<Account> CompanyAccounts { get; set; } = new List<Account>();
    }
}
