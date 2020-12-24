using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Resources
{
    public class SaveAccountResource
    {
        [Required]
        public float AvailableMoney { get; set; }
        [Required]
        [MaxLength(10)]
        public string Currency { get; set; }

        [MaxLength(15)]
        public string TypeOfInterest { get; set; }
        public float RateInterest { get; set; }
        public float MaintenanceCost { get; set; }
            //por definir si se pasa los ID del cliente y establecimiento
    }
}
