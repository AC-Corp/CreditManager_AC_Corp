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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> FindByProfileId(int profileId)
        {
            return await _userRepository.FindByProfileId(profileId);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<UserResponse> SaveAsync(User user)
        {
            if (_userRepository.FindByProfileId(user.ProfileId).Result)
            {
                try
                {
                    await _userRepository.AddAsync(user);
                    await _unitOfWork.CompleteAsync();
                    return new UserResponse(user);
                }
                catch(Exception ex)
                {
                    return new UserResponse($"An error ocured while saving the order: {ex.Message}");
                }
            }
            else
            {
                return new UserResponse("The profile don't exist.");
            }
        }
    }
}
