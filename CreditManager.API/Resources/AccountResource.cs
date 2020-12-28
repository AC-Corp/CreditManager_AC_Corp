using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Resources
{
    public class AccountResource
    {
        public string AccountNumber { get; set; }
        public float AvailableMoney { get; set; }
        public float DebtMoney { get; set; }
        public string Currency { get; set; }
        public string TypeOfInterest { get; set; }
        public float RateInterest { get; set; }
        public float MaintenanceCost { get; set; }
        public DateTime DateOfLastPayment { get; set; }//Ver si mejor se pasa como string

        public int OwnerId { get; set; }
        //public UserResource Owner { get; set; }

        public int CompanyId { get; set; }
        //public UserResource Company { get; set; }
    }
}
