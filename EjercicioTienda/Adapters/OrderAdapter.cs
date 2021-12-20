using EjercicioTienda.Context;
using EjercicioTienda.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioTienda.Adapters
{
    public class OrderAdapter : IOrderAdapter
    {
        private readonly ITiendaContext _tiendaContext;

        public OrderAdapter(ITiendaContext tiendaContext)
        {
            _tiendaContext = tiendaContext;
        }

        public async Task<int> AddOrder(Order order)
        {
            try
            {
                _tiendaContext.Orders.Add(order);

                int i = await _tiendaContext.SaveChangesAsync(true);

                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _tiendaContext.Orders.ToListAsync();
        }

        public async Task<Order> GetOrder(int Id)
        {
            return _tiendaContext.Orders.Where(x => x.Id == Id).ToList().FirstOrDefault();
        }

        public async Task<int> UpdateOrder(Order order)
        {
            try
            {
                Order orderUpdaed = _tiendaContext.Orders.Update(order).Entity;

                int i = await _tiendaContext.SaveChangesAsync(true);

                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
