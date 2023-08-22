using System;
using System.Collections.Generic;
using System.Text;

namespace proyectoProgra6App.Models
{
    public class Vuelo
    {

        public int IdVuelo { get; set; }
        public string Destino { get; set; } = null!;
        public string Aerolinea { get; set; } = null!;
        public string Fecha { get; set; } = null!;
        public string Gate { get; set; } = null!;
        public string HoraDespegue { get; set; } = null!;
        public string? HoraAterrizaje { get; set; }
        public bool? Active { get; set; }
        public bool? IsBlocked { get; set; }
        public int FkViaje { get; set; }

        public virtual Viaje FkViajeNavigation { get; set; } = null!;

    }
}
