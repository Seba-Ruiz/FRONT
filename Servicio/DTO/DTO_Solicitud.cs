using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.DTO
{
    public class DTO_Solicitud
    {
        public int idsolicitud { get; set; }
        public string subordinado { get; set; }
        public string servicio { get; set; }
        public DateTime fecha_solicitud { get; set; }
        public bool wifi { get; set; }
        public bool home_personal { get; set; }
        public bool home_grupal { get; set; }
        public bool internet { get; set; }
        public bool laboratorio { get; set; }
        public bool rayos { get; set; }
        public bool impresora { get; set; }
        public bool acceso_remoto { get; set; }
        public bool escritura_home { get; set; }
        public string estado { get; set; }
    }
}
