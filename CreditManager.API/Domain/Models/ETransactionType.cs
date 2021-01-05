using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Domain.Models
{
    public enum ETransactionType
    {
        [Description("D")] PagoDeuda,
        [Description("I")] PagoInteres,
        [Description("M")] PagoMantenimiento,
        [Description("C")] CompraProductos,
        [Description("A")] AsignacionCredito


        /*[Pago Deuda: D | Pago Interes: I | Pago Mantenimiento: M | Compra Productos: C | Asignacion Credito: A]*/
    }
}
