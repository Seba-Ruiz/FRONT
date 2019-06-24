using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;


namespace Dominio
{
    public class dominio_solicitud
    {
        FRONTEntities ctx = new FRONTEntities();
        public List<WEB_Solicitud> Listar()
        {
            var query = (from c in ctx.WEB_Solicitud
                         where c.estado == "NO REVISADO" || c.estado == "MODIFICADO"
                         select c).ToList();
            List<WEB_Solicitud> lista = new List<WEB_Solicitud>();
            foreach (var item in query)
            {
                WEB_Solicitud s = new WEB_Solicitud();
                s.id_solicitud = item.id_solicitud;
                s.subordinado_id = item.subordinado_id;
                s.fecha_solicitud = item.fecha_solicitud;
                s.wifi = item.wifi;
                s.home_personal = item.home_personal;
                s.home_grupal = item.home_grupal;
                s.internet = item.internet;
                s.laboratorio = item.laboratorio;
                s.rayos = item.rayos;
                s.impresora = item.impresora;
                s.acceso_remoto = item.acceso_remoto;
                s.estado = item.estado;

                lista.Add(s);
            }
            return lista;
        }
    }
}
