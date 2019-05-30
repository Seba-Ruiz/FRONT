using Acceso;
using Dominio;
using Modelo;
using Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Servicio
{
    public class servicio_subordinados_por_referente
    {

        public List<WEB_Subordinado> Sub_X_Referente()
        {


            dominio_servicio serv = new dominio_servicio();
            dominio_subordinado dom_sub = new dominio_subordinado();
            GrupoUsuario pertenecia = new GrupoUsuario();
           // List<DTO_Subordinado> dto = new List<DTO_Subordinado>();
            List<WEB_Subordinado> subor = new List<WEB_Subordinado>();

            bool esReferente = false;

            var servicios = serv.Listar();
            var grupos = pertenecia.Pertenencia();

            for (int i = 0; i < grupos.Length; i++)
            {
                if (grupos[i] == "RI")
                {
                    esReferente = true;
                }
            }


            if (esReferente)
            {
                List<WEB_Servicio> Servicios_de_usuario = new List<WEB_Servicio>();
                for (int i = 0; i < grupos.Length; i++)
                {
                    var servicio = serv.BuscarXNombre(grupos[i]);

                    if (servicio != null)
                    {
                        Servicios_de_usuario.Add(servicio);
                    }

                }

                foreach (var item in Servicios_de_usuario)
                {
                   var subordinados = dom_sub.ObtenerPorIDServicio(item.idservicio);

                    foreach (var a in subordinados)
                    {
                        subor.Add(a);
                    }

                }
            }



            return subor;
        }
    }
}