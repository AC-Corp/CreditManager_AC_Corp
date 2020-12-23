using CreditManager.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Domain.Services.Communications
{
    public class TransactionDetailsResponse : BaseResponse<TransactionDetails>
    {
        public TransactionDetailsResponse(TransactionDetails resource) : base(resource)
        {
        }

        public TransactionDetailsResponse(string message) : base(message)
        {
        }
    }
}
