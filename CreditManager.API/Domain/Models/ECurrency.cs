using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Domain.Models
{
    public enum ECurrency
    {
        [Description("Soles")] Soles,
        [Description("Dolares")] Dolares,
        [Description("Euros")] Euros
    }
}
