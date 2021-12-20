using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioTienda.Models.Enums
{

    public static class StatusExtensions
    {
        public static string GetString(this Status status)
        {
            switch (status)
            {
                case Status.Created:
                    return "CREATED";
                case Status.Payed:
                    return "PAYED";
                case Status.Rejected:
                    return "REJECTED";
                default:
                    return "ERROR";
            }
        }
    }

    public enum Status
    {
        Created,
        Payed,
        Rejected
    }

}
