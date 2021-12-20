using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioTienda.Models.Pago
{
    public class Person
    {
        public string documentType { get; set; } //Tipo de identificación[CC, CE, TI, SSN, NIT, PPN]
        string document { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string company { get; set; }
        public string email { get; set; }
        //public Address address { get; set; }
        //public PhoneNumberType mobile { get; set; }
    }
}
