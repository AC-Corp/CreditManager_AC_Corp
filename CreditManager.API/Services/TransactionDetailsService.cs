using CreditManager.API.Domain.Models;
using CreditManager.API.Domain.Repositories;
using CreditManager.API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Services
{
    public class TransactionDetailsService : ITransactionDetailsService
    {
        private readonly ITransactionDetailsRepository _transactionDetailsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionDetailsService(ITransactionDetailsRepository transactionDetailsRepository, IUnitOfWork unitOfWork)
        {
            _transactionDetailsRepository = transactionDetailsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TransactionDetails>> ListAsync()
        {
            return await _transactionDetailsRepository.ListAsync();
        }
    }
}
