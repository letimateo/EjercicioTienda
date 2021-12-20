using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioTienda.Models.Pago
{
    public class TaxDetail
    {
        public string kind { get; set; }
        public AmountType amount { get; set; }
        public AmountType Base { get; set; }
    }
}
