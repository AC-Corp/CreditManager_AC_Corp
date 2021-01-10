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
            /*var existingAccount = await _accountRepository.FindByAccountNumberAsync(transaction.AccountNumber);

            if (existingAccount is null)
            {
                return new TransactionResponse($"Don't exists an account with that account number");
            }
            switch (transaction.Type)
            {
                case ETransactionType.CompraProductos:
                    if (transaction.TotalAmount <= existingAccount.AvailableMoney)
                    {
                        existingAccount.AvailableMoney -= transaction.TotalAmount;

                        try
                        {
                            _accountRepository.Update(existingAccount);
                            await _transactionRepository.AddAsync(transaction);
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
                    break;
                case ETransactionType.AsignacionCredito:
                    return new TransactionResponse($"Operation invalid for Transaction of Asignacion Credito Type");
                    break;
                case ETransactionType.PagoDeuda: //SUMA A LA CANTIDAD
                    break;
                case ETransactionType.PagoInteres:             //para pago Mant e Interes, solo se guarda
                case ETransactionType.PagoMantenimiento:

                    break;
            }
            */

            return null;
        }

        public async Task<IEnumerable<Transaction>> ListAsync()
        {
            return await _transactionRepository.ListAsync();
        }
    }
}
