using System;
using System.Collections.Generic;
using System.Text;

namespace proyectoProgra6App.Models
{
    public class Viaje
    {

        public int IdViaje { get; set; }
        public string Destino { get; set; } = null!;
        public string FechaSalida { get; set; } = null!;
        public string FechaRegreso { get; set; } = null!;
        public string Costo { get; set; } = null!;
        public bool? Active { get; set; }
        public bool? IsBlocked { get; set; }
        public int FkHospedaje { get; set; }
        public int? FkUsuario { get; set; }

        public virtual Hospedaje FkHospedajeNavigation { get; set; } = null!;
        public virtual Usuario? FkUsuarioNavigation { get; set; }
    }
}
