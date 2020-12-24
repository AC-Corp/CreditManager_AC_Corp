using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Resources
{
    public class SaveProfileResource
    {
        [MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }
        [MaxLength(30)]
        public string CompanyName { get; set; }
        public DateTime DateOfBirthday { get; set; }
        [Required]
        [MaxLength(9)]
        public string Phone { get; set; }
        [Required]
        public string UserType { get; set; }
        public string ImageUrl { get; set; }
    }
}
