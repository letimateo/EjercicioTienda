using EjercicioTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioTienda.Adapters
{
    public interface IOrderAdapter
    {
        
        Task<int> AddOrder(Order order);

        Task<List<Order>> GetOrders();

        Task<Order> GetOrder(int Id);

        Task<int> UpdateOrder(Order order);

    }
}
