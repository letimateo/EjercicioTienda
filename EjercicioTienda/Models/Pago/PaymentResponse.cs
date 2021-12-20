using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioTienda.Models.Pago
{
    public class PaymentResponse
    {
        public StatusResponse status { get; set; }
        public int requestId { get; set; }
        public string processUrl { get; set; }
    }
}
