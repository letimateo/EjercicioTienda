using EjercicioTienda.Models;
using EjercicioTienda.Models.Pago;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioTienda.Helpers
{
    public class PagoHelper
    {
        private readonly string _login = "6dd490faf9cb87a9862245da41170ff2";
        private readonly string _tranKey = "iQhxZqnRbJe";

        public async Task<ResultObject> PagoRequest(int id, TiendaHelper tiendaHelper)
        {
            ResultObject result = new ResultObject();

            ResultObject resultOrder = await tiendaHelper.GetOrder(id);
            if (resultOrder.Status)
            {
                Order order = (Order)resultOrder.Data;

                #region Login
                CultureInfo customCulture = new CultureInfo("es-UY");

                string nonce = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 19);
                String seed = DateTime.UtcNow.ToString("s", System.Globalization.CultureInfo.InvariantCulture);

                Auth auth = new Auth()
                {
                    login = _login,
                    tranKey = _tranKey,
                    nonce = nonce,
                    seed = seed
                };
                #endregion

                #region Payment
                Payment payment = new Payment()
                {
                    reference = order.Id.ToString(),
                    description = "Pago de prueba",
                    amount = new Amount()
                    {
                        currency = "USD",
                        total = 100
                    },
                    allowPartial = false,
                    person = new Person()
                    {
                        name = order.CustomerName,
                        email = order.CustomerEmail
                    }
                };
                #endregion

                PaymentRequest paymentRequest = new PaymentRequest();
                paymentRequest.locale = customCulture.Name;
                paymentRequest.auth = auth;
                paymentRequest.payment = payment;
                paymentRequest.expiration = DateTime.Now.AddMonths(1);
                paymentRequest.returnUrl = "https://dnetix.co/p2p/client";
                paymentRequest.ipAddress = "127.0.0.1";
                paymentRequest.userAgent = "PlacetoPay Sandbox";

                string uri = $"https://test.placetopay.com/redirection/api/session";
                IRestResponse response = await this.Request(uri, JsonConvert.SerializeObject(paymentRequest));
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Status = true;
                    result.ErrorCode = "200";
                    result.Message = "Pago solicitado con éxito.";

                    PaymentResponse paymentResponse = JsonConvert.DeserializeObject<PaymentResponse>(response.Content);

                    if (paymentResponse.status.status == "OK")
                        await tiendaHelper.UpdateOrderRequestId(order.Id, paymentResponse.requestId);

                    //tiendaHelper.UpdateOrder(order.Id, Models.Enums.Status.Payed); moverlo para el Pago result que va a ser la url a la vuelta
                }
                else
                {
                    result.ErrorCode = "401";
                    result.Message = "Unauthorized";
                    result.Detail = response.ErrorMessage;
                }
            }
            else
            {
                result = resultOrder;
            }
            return result;
        }

        public async Task<ResultObject> PagoResult()
        {
            ResultObject result = new ResultObject();

            return result;
        }

        private async Task<IRestResponse> Request(string uri, string jsonRequest)
        {
            var client = new RestClient(uri);
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddBody(jsonRequest);

            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}
