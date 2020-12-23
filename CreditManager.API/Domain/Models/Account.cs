using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Domain.Models
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public float AvailableMoney { get; set; }
        public float DebtMoney { get; set; }
        public  ECurrency Currency { get; set; }
        public ETypeOfInterest TypeOfInterest { get; set; }
        public float RateInterest { get; set; }
        public float MaintenanceCost { get; set; }
        public DateTime DateOfLastPayment { get; set; }
        public int OwnerId { get; set; }
        public User Owner{ get; set; }
        public int CompanyId { get; set; }
        public User Company { get; set; }
        public IList<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
