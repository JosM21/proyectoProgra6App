using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using RestSharp;

namespace proyectoProgra6App.Models
{
    public class Usuario
    {

        public RestRequest Request { get; set; }

        public Usuario()
        {
            Active = true;
            IsBlocked = false;
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public string BackUpEmail { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string? Direccion { get; set; }
        public bool? Active { get; set; }
        public bool? IsBlocked { get; set; }
        public int FkUsuarioRol { get; set; }

        public virtual UsuarioRol? UsuarioRol { get; set; } = null!;


        public async Task<bool> ValidateUserLogin()
        {
            try
            {


                string RouteSufix = string.Format("Usuarios/ValidateLogin?username={0}&password={1}",this.Email, this.Contrasenia);
                                                                       
               
                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                
                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);

               
                RestResponse response = await client.ExecuteAsync(Request);

               
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

        public async Task<bool> AddUserAsync()
        {
            try
            {
                string RouteSufix = string.Format("Users");
                
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

    
