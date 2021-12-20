using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioTienda.Models.Pago
{
    public class Recurring
    {
        public string periodicity { get; set; }
        public int interval { get; set; }
        public DateTime nextPayment { get; set; }
        public int maxPeriods { get; set; }
        public DateTime dueDate { get; set; }
        public string notificationUrl { get; set; }
    }
}
