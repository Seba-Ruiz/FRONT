using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Servicio.Servicio;
using Modelo;

namespace FrontHP.Controllers
{
    public class AdminController : Controller
    {
        servicio_solicitud ss = new servicio_solicitud();
        public ActionResult Index()
        {
            var sol = ss.SolicitudesPendientes();
            return View(sol);
        }

        public ActionResult SolicitudPorEmpleado(int id)
        {
            var obj = ss.SolicitudesPendientesXId(id);
            return PartialView("_RequerimientoSubordinado",obj);
        }

        [HttpGet]
        public ActionResult Revisar(int id)
        {

            return PartialView("_Revisado");
        }
    }
}