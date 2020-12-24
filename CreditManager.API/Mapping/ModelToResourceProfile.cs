﻿
using CreditManager.API.Domain.Models;
using CreditManager.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Mapping
{
    public class ModelToResourceProfile : AutoMapper.Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Account, AccountResource>();
            CreateMap<Profile, ProfileResource>();
            CreateMap<User, UserResource>();
            CreateMap<Transaction, TransactionResource>();
            CreateMap<TransactionDetails, TransactionDetailsResource>();

            /* FALTA PONER ESTO PARA LOS ENUMS
             * CreateMap<Product, ProductResource>()
               .ForMember(src => src.UnitOfMeasurement,
               opt => opt.MapFrom(src => src.UnitOfMeasurement
               .ToDescriptionString()));*/
        }
    }
}
