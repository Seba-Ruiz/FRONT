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
            var serv = new List<WEB_Servicio>();
            try
            {
                using (var ctx = new FRONTEntities())

                    serv = ctx.WEB_Servicio
                            .ToList();
            }
            catch (Exception E)
            {

                throw E;
            }
            return serv;
        }

        public WEB_Servicio BuscarXNombre(string nombre)
        {
            var tel = new WEB_Servicio();
            try
            {
                using (var ctx = new FRONTEntities())

                    tel = ctx.WEB_Servicio.Where(x => x.servicio==nombre)
                        .FirstOrDefault();
            }
            catch (Exception E)
            {

                throw E;
            }
            return tel;
        }

        public WEB_Servicio BuscarXID(int? id_servicio)
        {
            var tel = new WEB_Servicio();
            try
            {
                using (var ctx = new FRONTEntities())

                    tel = ctx.WEB_Servicio.Where(x => x.idservicio == id_servicio)
                        .FirstOrDefault();
            }
            catch (Exception E)
            {

                throw E;
            }
            return tel;
        }



    }
}
