using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Servicio.Servicio;

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
    }
}