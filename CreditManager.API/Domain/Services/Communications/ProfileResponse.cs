using CreditManager.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Domain.Services.Communications
{
    public class ProfileResponse : BaseResponse<Profile>
    {
        public ProfileResponse(Profile resource) : base(resource)
        {
        }

        public ProfileResponse(string message) : base(message)
        {
        }
    }
}
