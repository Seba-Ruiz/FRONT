using Dominio;
using Modelo;
using Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Servicio
{
    public class servicio_equipo
    {
        public void Guardar(DTO_Equipo_Guardar dto)
        {
            dominio_equipo equipo = new dominio_equipo();
            WEB_Equipo eq = new WEB_Equipo();

            eq.fecha_alta = DateTime.Now;
            eq.tipo_id = dto.tipo_equipo;
            eq.mac = dto.mac;
            eq.subordinado_id = dto.id_subordinado;

            equipo.Guardar(eq);




        }
    }
}
