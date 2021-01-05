using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Resources
{
    public class SaveTransactionResource
    {
        [Required]
        public float TotalAmount { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string AccountNumber { get; set; }
    }
}
