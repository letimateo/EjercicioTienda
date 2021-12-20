using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioTienda.Models.Pago
{
    public class PaymentRequest
    {
        public string locale { get; set; }
        public Auth auth { get; set; }
        public Payment payment { get; set; }
        public DateTime expiration { get; set; }
        public string returnUrl { get; set; }
        public string ipAddress { get; set; }
        public string userAgent { get; set; }

    }
}
