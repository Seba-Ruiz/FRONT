using Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class dominio_solicitud
    {

        public void Guardar(WEB_Solicitud a)
        {
            try
            {
                using (var ctx = new FRONTEntities())
                {
                    if (a.id_solicitud > 0) //Registro que ya existe
                    {
                        ctx.Entry(a).State = EntityState.Modified;
                    }
                    else // Registro que es nuevo
                    {
                        ctx.Entry(a).State = EntityState.Added;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception E)
            {
                throw E;
            }
        }

        public int ObtenerUltimo()
        {
            var sol = new WEB_Solicitud();
            try
            {
                using (var ctx = new FRONTEntities())

                    sol = ctx.WEB_Solicitud.OrderByDescending(x => x.id_solicitud)
                                                .FirstOrDefault();

            }
            catch (Exception E)
            {
                throw E;
            }
            return sol.id_solicitud;
        }

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

        public List<WEB_Solicitud> ListarXId(int id)
        {
            var query = (from c in ctx.WEB_Solicitud
                         where
                            c.id_solicitud == id &&
                            c.estado == "NO REVISADO" || c.estado == "MODIFICADO"
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

        public WEB_Solicitud ObtenerPorID(int id)
        {
            var sub = new WEB_Solicitud();
            try
            {
                using (var ctx = new FRONTEntities())

                    sub = ctx.WEB_Solicitud.OrderByDescending(x => x.id_solicitud).Where(x => x.subordinado_id == id)
                        .FirstOrDefault();
            }
            catch (Exception E)
            {
                throw E;
            }
            return sub;
        }
    }
}
