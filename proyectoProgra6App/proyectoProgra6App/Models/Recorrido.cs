using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace proyectoProgra6App.Models
{
    public class Recorrido
    {

        [JsonIgnore]

        public RestRequest Request { get; set; }

        public int IdRecorrido { get; set; }
        public string Fecha { get; set; } = null!;
        public string HoraSalida { get; set; } = null!;
        public string Lugar { get; set; } = null!;
        public string CostoPp { get; set; } = null!;
        public bool? Active { get; set; }
        public bool? IsBlocked { get; set; }


        public async Task<bool> AddRecorridoAsync()
        {
            try
            {
                string RouteSufix = string.Format("Recorridos");

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

        //FUNCIONES DEL MODELO lista
        public async Task<ObservableCollection<Recorrido>> GetRecorridoListByIDM()
        {
            try
            {
                string RouteSufix = string.Format("Recorridos/GetRecorridoListByID?id={0}", this.IdRecorrido);
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

                    var list = JsonConvert.DeserializeObject<ObservableCollection<Recorrido>>(response.Content);

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
