using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioTienda.Models.Pago
{
    public class StatusResponse
    {
        public string status { get; set; }
        public string reason { get; set; }
        public string message { get; set; }
        public DateTime date { get; set; }
    }
}
