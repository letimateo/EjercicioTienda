using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioTienda.Models.Pago
{
    public class Auth
    {
        public string login { get; set; }
        public string tranKey { get; set; }
        public string nonce { get; set; }
        public string seed { get; set; }
    }
}
