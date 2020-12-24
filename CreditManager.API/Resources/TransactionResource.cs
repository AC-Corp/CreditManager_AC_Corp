using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Resources
{
    public class TransactionResource
    {
        public int Id { get; set; }
        public float TotalAmount { get; set; }
        public char Type { get; set; }
        public DateTime Date { get; set; }
        public AccountResource Account { get; set; }
    }
}
