using proyectoProgra6App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace proyectoProgra6App
{
    public static class GlobalObjects
    {
        public static string MimeType = "application/json";
        public static string ContentType = "Content-Type";

        public static UsuarioDTO MiUsuarioLocal = new UsuarioDTO();
        public static Cliente MiClienteLocal = new Cliente();
        public static Hospedaje MiHospedajeLocal = new Hospedaje();
        public static Recorrido MiRecorridoLocal = new Recorrido();
        public static Viaje MiViajeLocal = new Viaje();
        public static Vuelo MiVueloLocal = new Vuelo();
        
       

    }
}
