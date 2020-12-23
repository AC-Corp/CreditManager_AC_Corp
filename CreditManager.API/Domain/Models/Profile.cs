using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Domain.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public string Phone { get; set; }
        public DateTime RegisterDate { get; set; }
        public EUserType UserType { get; set; }
        public string ImageUrl { get; set; }
        public User User { get; set; }
    }
}
