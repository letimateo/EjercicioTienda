using EjercicioTienda.Adapters;
using EjercicioTienda.Models;
using EjercicioTienda.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioTienda.Helpers
{
    public class TiendaHelper
    {
        private IOrderAdapter _orderAdapter;

        public TiendaHelper(IOrderAdapter orderAdapter)
        {
            _orderAdapter = orderAdapter;
        }

        public async Task<ResultObject> AddOrder(string customer_name, string customer_email, string customer_mobile)
        {
            ResultObject result = new ResultObject();

            try
            {
                Order order = new Order()
                {
                    Id = 0,
                    CustomerName = customer_name,
                    CustomerEmail = customer_email,
                    CustomerMobile = customer_mobile,
                    Status = Status.Created.GetString(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                int i = await _orderAdapter.AddOrder(order);
                if (i > 0)
                {
                    result.Status = true;
                    result.ErrorCode = "201";
                    result.Message = "Orden creada con éxito.";
                }
                else
                {
                    result.ErrorCode = "404";
                    result.Message = "Ha ocurrido un error inesperado, contáctese con su proveedor.";
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = "404";
                result.Message = ex.Message;
                result.Detail = ex.InnerException.Message;
            }

            return result;
        }

        public async Task<ResultObject> GetOrders()
        {
            ResultObject result = new ResultObject();

            try
            {
                List<Order> ordenes = await _orderAdapter.GetOrders();
                if (ordenes != null)
                {
                    result.Status = true;
                    if (ordenes.Count > 0)
                    {
                        result.ErrorCode = "200";
                        result.Data = ordenes;
                        result.Message = $"Hay {ordenes.Count} órdenes.";
                    }
                    else
                    {
                        result.ErrorCode = "204";
                        result.Message = $"No hay órdenes.";
                    }
                }
                else
                {
                    result.ErrorCode = "404";
                    result.Message = "Ha ocurrido un error inesperado, contáctese con su proveedor.";
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = "404";
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<ResultObject> UpdateOrderStatus(int id, Status status)
        {
            ResultObject result = new ResultObject();

            try
            {
                Order order = await _orderAdapter.GetOrder(id);
                if (order != null)
                {
                    order.Status = status.GetString();
                    order.UpdatedAt = DateTime.Now;

                    result = await this.UpdateOrder(order);
                }
                else
                {
                    result.ErrorCode = "404";
                    result.Message = $"No existe orden con id {id}.";
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = "404";
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<ResultObject> UpdateOrderRequestId(int id, int requestId)
        {
            ResultObject result = new ResultObject();

            try
            {
                Order order = await _orderAdapter.GetOrder(id);
                if (order != null)
                {
                    //order.RequestId = requestId;
                    order.UpdatedAt = DateTime.Now;

                    result = await this.UpdateOrder(order);
                }
                else
                {
                    result.ErrorCode = "404";
                    result.Message = $"No existe orden con id {id}.";
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = "404";
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<ResultObject> UpdateOrder(Order order)
        {
            ResultObject result = new ResultObject();

            try
            {
                int i = await _orderAdapter.UpdateOrder(order);
                if (i > 0)
                {
                    result.Status = true;
                    result.ErrorCode = "201";
                    result.Message = "Orden modificada con éxito.";
                }
                else
                {
                    result.ErrorCode = "404";
                    result.Message = $"Ha ocurrido un error al modificar la orden {order.Id}.";
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = "404";
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<ResultObject> GetOrder(int id)
        {
            ResultObject result = new ResultObject();

            try
            {
                Order order = await _orderAdapter.GetOrder(id);
                if (order != null)
                {
                    result.Status = true;
                    result.ErrorCode = "200";
                    result.Data = order;
                    result.Message = $"Orden encontrada.";
                }
                else
                {
                    result.ErrorCode = "404";
                    result.Message = "No se encontró la orden.";
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = "404";
                result.Message = ex.Message;
            }

            return result;
        }

    }
}
