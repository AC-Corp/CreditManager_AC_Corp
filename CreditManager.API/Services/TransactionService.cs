using CreditManager.API.Domain.Models;
using CreditManager.API.Domain.Repositories;
using CreditManager.API.Domain.Services;
using CreditManager.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionService(ITransactionRepository transactionRepository, IAccountRepository accountRepository, IUnitOfWork unitOfWork)
        {
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
            _accountRepository = accountRepository;
        }

        public async Task<TransactionResponse> SaveAsync(Transaction transaction)
        {
            var existingAccount = await _accountRepository.FindByAccountNumberAsync(transaction.AccountNumber);

            if (transaction.TotalAmount <= existingAccount.AvailableMoney)
            {
                // TODO: Agregar lo de Transaction Details
                // TODO: Probar que a los objetos TD que se pasen, 
                //se les ponga el objeto padre Transaction y ver que se registren correctamente

                try
                {
                    await  _transactionRepository.AddAsync(transaction);
                    await _unitOfWork.CompleteAsync();
                    return new TransactionResponse(transaction);
                }
                catch (Exception ex)
                {
                    return new TransactionResponse($"An error ocurred while saving the transaction: {ex.Message}");
                }

            }
            else
            {
                throw new Exception("You don't have enough money");
            }
        }

        public async Task<IEnumerable<Transaction>> ListAsync()
        {
            return await _transactionRepository.ListAsync();
        }
    }
}
