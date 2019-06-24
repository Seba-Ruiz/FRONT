using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Dominio;
using Servicio.DTO;

namespace Servicio.Servicio
{
    public class servicio_solicitud
    {
        dominio_solicitud ds = new dominio_solicitud();
        dominio_subordinado su = new dominio_subordinado();
        public List<DTO_Solicitud> SolicitudesPendientes()
        {
            var lista = ds.Listar();
            List<DTO_Solicitud> dto = new List<DTO_Solicitud>();
            foreach (var item in lista)
            {
                DTO_Solicitud s = new DTO_Solicitud();
                s.idsolicitud = item.id_solicitud;
                s.subordinado = su.ObtenerNombrePorId(item.subordinado_id);
                s.servicio = su.ObtenerServicioPorId(item.subordinado_id);
                s.fecha_solicitud = item.fecha_solicitud;
                s.wifi = item.wifi;
                s.home_personal = item.home_personal;
                s.home_grupal = item.home_grupal;
                s.internet = item.internet;
                s.laboratorio = item.laboratorio;
                s.rayos = item.rayos;
                s.impresora = item.impresora;
                s.acceso_remoto = item.acceso_remoto;
                s.escritura_home = item.escritura_home;
                s.estado = item.estado;

                dto.Add(s);
            }
            return dto;
        }
    }
}
