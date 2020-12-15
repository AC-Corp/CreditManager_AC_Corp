using CreditManager.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Domain.Services.Communications
{
    public class EntityResponse : BaseResponse<Entity>
    {
        public EntityResponse(Entity resource) : base(resource)
        {
        }

        public EntityResponse(string message) : base(message)
        {
        }
    }
}
