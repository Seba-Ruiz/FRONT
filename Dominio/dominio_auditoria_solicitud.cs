using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;


namespace Dominio
{
    public class dominio_auditoria_solicitud
    {
        public void Guardar(WEB_AuditoriaSolicitud a)
        {
            try
            {
                using (var ctx = new FRONTEntities())
                {
                    if (a.id_auditoria_solicitud > 0) //Registro que ya existe
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


    }
}
