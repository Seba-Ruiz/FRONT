using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Acceso;
using Modelo;
using Servicio.Servicio;
using Servicio.DTO;

namespace FrontHP.Controllers
{
    public class ReferenteController : Controller
    {
        // GET: Referente
       
        public ActionResult Index()
        {
            servicio_subordinados_por_referente serv_ref = new servicio_subordinados_por_referente();
            var sr = serv_ref.Sub_X_Referente();

            return View(sr);
        }
    }
}