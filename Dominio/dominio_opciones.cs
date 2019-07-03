using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class dominio_opciones
    {
        public List<WEB_Opciones> Listar()
        {
            var opci = new List<WEB_Opciones>();
            try
            {
                using (var ctx = new FRONTEntities())

                    opci = ctx.WEB_Opciones
                            .ToList();
            }
            catch (Exception E)
            {

                throw E;
            }
            return opci;
        }

        public WEB_Opciones Obtener_por_valor(bool valor)
        {
            var opci = new WEB_Opciones();

            try
            {
                using (var ctx = new FRONTEntities())

                    opci = ctx.WEB_Opciones
                            .Where(x=>x.valor==valor)
                            .FirstOrDefault();
            }
            catch (Exception E)
            {

                throw E;
            }
            return opci;

        }


    }
}
