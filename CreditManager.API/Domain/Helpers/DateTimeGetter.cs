using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Domain.Helpers
{
    public class DateTimeGetter
    {
        public static DateTime GetDateTimeFromPeru()
        {// TODO: Ver sobre obtener la hora de peru, incluso cuando la app este alojada en USA o Europa
            //https://docs.microsoft.com/es-es/dotnet/standard/datetime/converting-between-time-zones
            return DateTime.Now;
        }
    }
}
