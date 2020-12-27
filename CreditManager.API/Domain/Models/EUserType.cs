using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Domain.Models
{
    public enum EUserType
    {
        [Description("Customer")] Customer,
        [Description("OwnerCompany")] OwnerCompany
    }
}
