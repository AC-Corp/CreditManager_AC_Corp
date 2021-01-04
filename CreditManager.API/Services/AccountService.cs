using CreditManager.API.Domain.Helpers;
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
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IAccountRepository accountRepository, IUserRepository userRepository, IUnitOfWork unitOfWork, ITransactionRepository transactionRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<Account>> ListAsync()
        {
            return await _accountRepository.ListAsync();
        }

        public async Task<AccountResponse> SaveAsync(Account account)
        {
            var existingAccount = await _accountRepository.FindByOwnerIdAndCompanyIdAsync(account.OwnerId, account.CompanyId);
            if (existingAccount is null)
            {
                var dni = await _userRepository.GetDniById(account.OwnerId);

                if (string.IsNullOrEmpty(dni))
                {
                    return new AccountResponse($"An error ocurred while saving the order: not exists dni for that user");
                }

                var accountNumber = AccountNumberGenerator.GenerateAccountNumber(dni);
                account.AccountNumber = accountNumber;
                account.DateOfLastPayment = DateTimeGetter.GetDateTimeFromPeru();
                try
                {
                    await _accountRepository.AddAsync(account);
                    await _unitOfWork.CompleteAsync();
                    // TODO: Luego de haber registrado la cuenta, se le envia un correo al cliente con los datos de su nuevo credito
                    return new AccountResponse(account);
                }
                catch (Exception ex)
                {
                    return new AccountResponse($"An error ocurred while saving the order: {ex.Message}");
                }
            }
            else
            {
                return new AccountResponse($"The client with ID {account.OwnerId} has already have an account in the company with ID {account.CompanyId}");
            }

        }

        public async Task<AccountResponse> UpdateAmountAsync(string accountNumber, Account account)
        { // TODO: FALTA COLOCAR EL ENUM DE TRANSACTION, PROBAR EL METODO Y VER QUE SI SE GUARDE EL MOVIMIENTO
            var existingAccount = await _accountRepository.FindByAccountNumberAsync(accountNumber);

            if (existingAccount == null) { return new AccountResponse("Account not found"); }

            Transaction newtransaction = new Transaction
            {
                AccountNumber = existingAccount.AccountNumber,
                Date = DateTimeGetter.GetDateTimeFromPeru(),
                TotalAmount = account.AvailableMoney - existingAccount.AvailableMoney, 
                Type = 'A'
            };


            existingAccount.AvailableMoney = account.AvailableMoney;

            try
            {
                _accountRepository.Update(existingAccount);
                await _transactionRepository.AddAsync(newtransaction);
                await _unitOfWork.CompleteAsync();

                return new AccountResponse(existingAccount);
            }
            catch (Exception ex)
            {
                return new AccountResponse($"An error ocurred while updating account: {ex.Message}");
            }
        }

        public async Task<AccountResponse> UpdateInterestAsync(string accountNumber, Account account)
        {
            var existingAccount = await _accountRepository.FindByAccountNumberAsync(accountNumber);

            if (existingAccount == null) { return new AccountResponse("Account not found"); }

            if (existingAccount.DebtMoney > 0)
            {
                return new AccountResponse("Account has debt, first pay debt to change Type and Rate of Interest");
            }


            existingAccount.RateInterest = account.RateInterest;
            existingAccount.TypeOfInterest = account.TypeOfInterest;

            try
            {
                _accountRepository.Update(existingAccount);
                await _unitOfWork.CompleteAsync();

                return new AccountResponse(existingAccount);
            }
            catch (Exception ex)
            {
                return new AccountResponse($"An error ocurred while updating account: {ex.Message}");
            }
        }
    }
}
