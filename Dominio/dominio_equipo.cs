using Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class dominio_equipo
    {
        public void Guardar(WEB_Equipo a)
        {
            try
            {
                using (var ctx = new FRONTEntities())
                {
                    if (a.id_equipo > 0) //Registro que ya existe
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
