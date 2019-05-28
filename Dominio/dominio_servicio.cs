using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Dominio
{
    public class dominio_servicio
    {
        public List<WEB_Servicio> Listar()
        {
            var tel = new List<WEB_Servicio>();
            try
            {
                using (var ctx = new FRONTEntities())

                    tel = ctx.WEB_Servicio
                        .ToList();
            }
            catch (Exception E)
            {

                throw E;
            }
            return tel;
        }
    }
}
