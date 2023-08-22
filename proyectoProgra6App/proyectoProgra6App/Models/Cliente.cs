using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace proyectoProgra6App.Models
{
    public class Cliente
    {
        [JsonIgnore]

        public RestRequest Request { get; set; }

        public int IdCliente { get; set; }
        public string Cedula { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string NombreCompleto { get; set; } = null!;
        public string FechaNacimiento { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string? Direccion { get; set; }
        public bool? Active { get; set; }
        public bool? IsBlocked { get; set; }


        public async Task<bool> AddClienteAsync()
        {
            try
            {
                string RouteSufix = string.Format("Clientes");

                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Post);

                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);

                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);



                string SerializedModel = JsonConvert.SerializeObject(this);

                Request.AddBody(SerializedModel, GlobalObjects.MimeType);

                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }

        }


    }

}

