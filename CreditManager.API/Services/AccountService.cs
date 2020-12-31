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
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IAccountRepository accountRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Account>> ListAsync()
        {
            return await _accountRepository.ListAsync();
        }

        public async Task<AccountResponse> SaveAsync(Account account)
        {
            var existingAccount = await _accountRepository.FindByOwnerIdAndCompanyIdAsync(account.OwnerId, account.CompanyId);
            if(existingAccount is null)
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
    }
}
