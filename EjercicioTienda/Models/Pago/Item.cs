using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioTienda.Models.Pago
{
    public class Item
    {
        public string sku { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string qty { get; set; }
        public decimal price { get; set; }
        public decimal tax { get; set; }
    }
}
