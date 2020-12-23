using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Domain.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public float TotalAmount { get; set; }
        public char Type { get; set; }
        public DateTime Date { get; set; }
        public string AccountNumber { get; set; }
        public Account Account { get; set; }

        public IList<TransactionDetails> TransactionDetails { get; set; } = new List<TransactionDetails>();
    }
}
