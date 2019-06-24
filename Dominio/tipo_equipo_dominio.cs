using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class tipo_equipo_dominio
    {

        public List<WEB_TipoEquipo> Listar()
        {
            var tipo = new List<WEB_TipoEquipo>();
            try
            {
                using (var ctx = new FRONTEntities())

                    tipo = ctx.WEB_TipoEquipo
                        .Where(x => x.estado == true)
                        .ToList();
            }
            catch (Exception E)
            {

                throw E;
            }
            return tipo;
        }



    }
}
