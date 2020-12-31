using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Resources
{
    public class ProfileResource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Dni { get; set; }
        public string CompanyName { get; set; }
        public string Ruc { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public string Phone { get; set; }
        public DateTime RegisterDate { get; set; }
        public string UserType { get; set; }
        public string ImageUrl { get; set; }

        public int UserId { get; set; }
        //public UserResource User { get; set; }
    }
}
