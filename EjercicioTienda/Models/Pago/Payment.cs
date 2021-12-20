using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioTienda.Models.Pago
{
    public class Payment
    {
        public string reference { get; set; }
        public string description { get; set; }
        public Amount amount { get; set; }
        public bool allowPartial { get; set; }
        public Person person { get; set; }
        public Item[] items { get; set; }
        public NameValuePair[] fields { get; set; }
        public Recurring recurring { get; set; }
    }
}
