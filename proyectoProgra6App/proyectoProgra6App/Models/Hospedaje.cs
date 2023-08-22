using System;
using System.Collections.Generic;
using System.Text;

namespace proyectoProgra6App.Models
{
    public class Hospedaje
    {
        public int IdHotel { get; set; }
        public string NombreHotel { get; set; } = null!;
        public string Ubicacion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public bool? Active { get; set; }
        public bool? IsBlocked { get; set; }

    }
}
