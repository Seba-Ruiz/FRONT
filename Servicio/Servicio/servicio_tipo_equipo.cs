using Dominio;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Servicio
{
    public class servicio_tipo_equipo
    {
        public WEB_TipoEquipo ObtenerPorId(int? id)
        {
            dominio_tipo_equipo equipo = new dominio_tipo_equipo();
            var eq = equipo.ObtenerPorId(id);

            return eq;

        }

        public WEB_TipoEquipo ObtenerPorNombre(string nombre)
        {
            dominio_tipo_equipo equipo = new dominio_tipo_equipo();
            var eq = equipo.ObtenerPorNombre(nombre);

            return eq;

        }

    }
}
