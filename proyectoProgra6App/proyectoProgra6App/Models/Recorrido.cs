using System;
using System.Collections.Generic;
using System.Text;

namespace proyectoProgra6App.Models
{
    public class Recorrido
    {

        public int IdRecorrido { get; set; }
        public string Fecha { get; set; } = null!;
        public string HoraSalida { get; set; } = null!;
        public string Lugar { get; set; } = null!;
        public string CostoPp { get; set; } = null!;
        public bool? Active { get; set; }
        public bool? IsBlocked { get; set; }

    }
}
