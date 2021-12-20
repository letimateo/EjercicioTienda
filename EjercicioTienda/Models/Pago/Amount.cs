using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioTienda.Models.Pago
{
    public class Amount
    {
        public string currency { get; set; }
        public decimal total { get; set; }
        public TaxDetail[] taxes { get; set; }
        public AmountDetail[] details { get; set; }
    }
}
