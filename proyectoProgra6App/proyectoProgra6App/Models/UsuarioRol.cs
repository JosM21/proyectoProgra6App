using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace proyectoProgra6App.Models
{
    public class UsuarioRol
    {
        public RestRequest Request { get; set; }
        public int IdUsuarioRol { get; set; }
        public string Descripcion { get; set; } = null!;


        public async Task<List<UsuarioRol>> GetAllUserRolesAsync()
        {
            try
            {
                string RouteSufix = string.Format("UsuarioRols");
               
                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

               
                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);

                
                RestResponse response = await client.ExecuteAsync(Request);

                
                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<List<UsuarioRol>>(response.Content);

                    return list;
                }
                else
                {
                    return null;
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
