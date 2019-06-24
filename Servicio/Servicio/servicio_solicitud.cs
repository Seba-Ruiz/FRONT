using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Modelo;
using Servicio.DTO;

namespace Servicio.Servicio
{
    public class servicio_solicitud
    {

        public void Guardar(DTO_Solicitud_Guardar dto)
        {
            dominio_solicitud soli = new dominio_solicitud();
            WEB_Solicitud solicitud = new WEB_Solicitud();

            solicitud.impresora = dto.impresora;
            solicitud.internet = dto.internet;
            solicitud.home_personal = dto.h_personal;
            solicitud.home_grupal = dto.h_grupal;
            solicitud.laboratorio = dto.laboratorio;
            solicitud.rayos = dto.rayos;
            solicitud.wifi = dto.wifi;
            solicitud.acceso_remoto = dto.vpn;
            solicitud.fecha_solicitud = DateTime.Now;
            solicitud.estado = "NO REVISADO";
            solicitud.subordinado_id = dto.id_subordinado;
            solicitud.escritura_home = dto.escritura;

            soli.Guardar(solicitud);
            

        }


    }
}
