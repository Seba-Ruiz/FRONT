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

        public WEB_Equipo ObtenerPorIdSubordinado(int id)
        {
            dominio_equipo equipo = new dominio_equipo();
            var eq = equipo.ObtenerPorIdSubordinado(id);

            return eq;

        }
        public bool Existe_Mac(string mac)
        {
            dominio_equipo equi = new dominio_equipo();
            var comparar = equi.Listar();
            bool result = false;

            foreach (var item in comparar)
            {
                if (item.mac == mac)
                {
                    result = true;
                    return result;
                }
            }

            return result;
        }




    }
}
