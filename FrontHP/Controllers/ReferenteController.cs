using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Servicio.DTO;
using Servicio.Servicio;

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

                dto.Add(dto_sub);
            }


            return View(dto);
        }

        public ActionResult Error()
        {

            return View();
        }



    }
}