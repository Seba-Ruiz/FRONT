using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Servicio.Servicio
{
    public class servicio_servicio
    {
        public string NombreServicio (int? id_servicio)
        {
            dominio_servicio dom_serv = new dominio_servicio();
            var servicio = dom_serv.BuscarXID(id_servicio);

            var nombre_servicio = servicio.servicio;

            return nombre_servicio;


        }



    }
}
