using EjercicioTienda.Adapters;
using EjercicioTienda.Helpers;
using EjercicioTienda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioTiendaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TiendaController : ControllerBase
    {

        private readonly ILogger<TiendaController> _logger;
        private readonly IOrderAdapter _orderAdapter;
        public TiendaController(ILogger<TiendaController> logger, IOrderAdapter orderAdapter)
        {
            _logger = logger;
            _orderAdapter = orderAdapter;

        }


        [HttpPost("AddOrder")]
        public async Task<ActionResult<ResultObject>> AddOrder(string customer_name, string customer_email, string customer_mobile)
        {
            if (customer_name.Equals(String.Empty) || customer_email.Equals(String.Empty) || customer_mobile.Equals(String.Empty))
            {
                ResultObject result = new ResultObject() { Status = false, ErrorCode = "400", Message = "Verifique los datos de entrada." };
                return BadRequest(result);
            }
            else
            {
                TiendaHelper tiendaHelper = new TiendaHelper(_orderAdapter);
                ResultObject result = await tiendaHelper.AddOrder(customer_name, customer_email, customer_mobile);
                return result.Status ? Ok(result) : NotFound(result);
            }
        }

        [HttpGet("GetOrders")]
        public async Task<ActionResult<ResultObject>> GetOrders()
        {
            TiendaHelper tiendaHelper = new TiendaHelper(_orderAdapter);
            ResultObject result = await tiendaHelper.GetOrders();
            return result.Status ? Ok(result) : NoContent();
        }

        [HttpGet("Pagar")]
        public async Task<ActionResult<ResultObject>> Pagar(int id)
        {
            PagoHelper pagoHelper = new PagoHelper();
            TiendaHelper tiendaHelper = new TiendaHelper(_orderAdapter);

            ResultObject result = await pagoHelper.PagoRequest(id, tiendaHelper);

            return result.Status ? Ok(result) : Unauthorized();
        }
    }
}
