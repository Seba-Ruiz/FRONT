using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.DTO
{
    public class DTO_Equipo_Guardar
    {
        public int id_subordinado { get; set; }
        public string mac { get; set; }
        public int tipo_equipo { get; set; }
    }
}
