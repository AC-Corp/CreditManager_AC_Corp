using CreditManager.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Domain.Services.Communications
{
    public class TransactionResponse : BaseResponse<Transaction>
    {
        public TransactionResponse(Transaction resource) : base(resource)
        {
        }

        public TransactionResponse(string message) : base(message)
        {
        }
    }
}
