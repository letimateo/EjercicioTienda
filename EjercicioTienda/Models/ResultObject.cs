using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioTienda.Models
{
    public class ResultObject
    {
        public ResultObject()
        {
            Status = false;
        }
        public bool Status { get; set; }

        public string Message { get; set; }

        public string Detail { get; set; }

        public string ErrorCode { get; set; }

        public Object Data { get; set; }
    }
}
