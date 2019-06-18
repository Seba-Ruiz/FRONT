using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Servicio.DTO;
using Servicio.Servicio;
using Dominio;

namespace FrontHP.Controllers
{
    public class ReferenteController : Controller
    {
        // GET: Referente
       
        public ActionResult Index()
        {
            servicio_subordinados_por_referente serv_ref = new servicio_subordinados_por_referente();
            servicio_servicio serv = new servicio_servicio();
            var sr = serv_ref.Sub_X_Referente();

            if (sr.Count() == 0)
            {
                return Redirect("Error");
            }

            List<DTO_Subordinado> dto = new List<DTO_Subordinado>();

            foreach (var item in sr)
            {
                DTO_Subordinado dto_sub = new DTO_Subordinado();
                dto_sub.apellido = item.apellido;
                dto_sub.nombre = item.nombre;
                dto_sub.mail = item.mail;
                dto_sub.nombre_servicio = serv.NombreServicio(item.servicio_id);
                dto_sub.estado = item.estado;
                dto_sub.dni = item.dni;
                dto.Add(dto_sub);
            }


            return View(dto);
        }

        public ActionResult Error()
        {
            return View();
        }
        
         public ActionResult CrearLegajo(int? id)
        {

            dominio_subordinado srv = new dominio_subordinado();
            var coso = srv.ObtenerPorDNI(id);

            return View(coso); 
        }


        public PartialViewResult MostrarCheckHomeGrupal(int id)
        {
            if (id==1)
            {
                return PartialView("_MostrarCheckHomeGrupal");
            }
            else
            {
                return PartialView("_SinSeleccion");     
            }


            
        }

    }
}