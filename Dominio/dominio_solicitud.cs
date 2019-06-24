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

    }
}
