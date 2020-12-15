using AutoMapper;
using CreditManager.API.Domain.Models;
using CreditManager.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
           CreateMap<Entity, EntityResource>();

        }
    }
}
