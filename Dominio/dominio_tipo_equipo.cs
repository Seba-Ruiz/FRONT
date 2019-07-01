using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class dominio_tipo_equipo
    {
        public WEB_TipoEquipo ObtenerPorId(int? id)
        {
            var sol = new WEB_TipoEquipo();
            try
            {
                using (var ctx = new FRONTEntities())

                    sol = ctx.WEB_TipoEquipo.OrderByDescending(x => x.id_tipo).Where(x => x.id_tipo == id)
                                                .FirstOrDefault();

            }
            catch (Exception E)
            {
                throw E;
            }
            return sol;
        }
    }
}
