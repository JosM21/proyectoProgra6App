using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace proyectoProgra6App.Models
{
    public class UsuarioDTO
    {

        [JsonIgnore]
        public RestRequest Request { get; set; }

        public int IdUser { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string backupEmail { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Address { get; set; }
        public bool? Active { get; set; }
        public bool? isBlocked { get; set; }
        public int IDRol { get; set; }
        public string DescriptionRol { get; set; } = null!;


        //FUNCIONES+
        public async Task<UsuarioDTO> GetUserInfo(string PEmail)
        {

            try
            {
                string RouteSufix = string.Format("Usuarios/GetUserInfoByEmail?Pemail={0}", PEmail);
                //armamos la ruta completa al endpoint en el API 
                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //agregamos mecanismo de seguridad, en este caso API key
                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);

                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);

                //ejecutar la llamada al API 
                RestResponse response = await client.ExecuteAsync(Request);

                //saber si las cosas salieron bien 
                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {


                    var list = JsonConvert.DeserializeObject<List<UsuarioDTO>>(response.Content);

                    var item = list[0];

                    return item;
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

        public async Task<bool> UpdateUserAsync()
        {
            try
            {
                string RouteSufix = string.Format("Usuarios/{0}", this.IdUser);
                //armamos la ruta completa al endpoint en el API 
                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Put);

                //agregamos mecanismo de seguridad, en este caso API key
                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);

                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);

                //en el caso de una operación POST debemos serializar el objeto para pasarlo como 
                //json al API

                string SerializedModel = JsonConvert.SerializeObject(this);
                //agregamos el objeto serializado el el cuerpo del request. 
                Request.AddBody(SerializedModel, GlobalObjects.MimeType);

                //ejecutar la llamada al API 
                RestResponse response = await client.ExecuteAsync(Request);

                //saber si las cosas salieron bien 
                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
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
