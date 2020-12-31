
using CreditManager.API.Domain.Models;
using CreditManager.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Mapping
{
    public class ResourceToModelProfile : AutoMapper.Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<AccountResource, Account>();
            CreateMap<ProfileResource, Profile>();
            CreateMap<UserResource, User>();
            CreateMap<TransactionResource, Transaction>();
            CreateMap<TransactionDetailsResource, TransactionDetails>();

            CreateMap<SaveAccountResource, Account>();
            CreateMap<SaveProfileResource, Profile>();
            CreateMap<SaveTransactionDetailsResource, TransactionDetails>();
            CreateMap<SaveTransactionResource, Transaction>();
            CreateMap<SaveUserResource, User>();

            /* FALTA PONER ESTO PARA LOS ENUMS
             * CreateMap<Product, ProductResource>()
               .ForMember(src => src.UnitOfMeasurement,
               opt => opt.MapFrom(src => src.UnitOfMeasurement
               .ToDescriptionString()));*/
        }
    }
}
