using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Domain.Models
{
    public enum ETypeOfInterest
    {
        [Description("Simple")] Simple,
        [Description("Nominal")] Nominal,
        [Description("Efectivo")] Efectivo
    }
}
