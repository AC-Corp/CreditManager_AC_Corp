using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        //public ProfileResource Profile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
