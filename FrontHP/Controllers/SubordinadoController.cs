using Dominio;
using Servicio.DTO;
using Servicio.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontHP.Controllers
{
    public class SubordinadoController : Controller
    {
        // GET: Subordinado
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CargarSubordinado()
        {
            var dto = new DTO_Subordinado();
            var serv = new dominio_servicio();

            ViewBag.servicios = serv.Listar();

            return View(dto);
        }

        [HttpPost]
        public ActionResult GuardarSubordinado(DTO_Subordinado dto)
        {


            servicio_subordinado srv = new servicio_subordinado();


            var resultado = srv.GuardarSubordinado(dto);

            if (resultado == null)
            {
                return Redirect("Exito");
            }
            else
            {
                return Redirect("Error");
            }

        }
        [HttpPost]
        public JsonResult ExisteDni(int dni)
        {
            servicio_subordinado srv = new servicio_subordinado();
            var resul = srv.Existe_Dni(dni);
            return Json(resul ? string.Format("El dni ingresado ya existe en el sistema") : "true");

        }
        [HttpPost]
        public JsonResult ExisteMail(string mail)
        {
            servicio_subordinado srv = new servicio_subordinado();
            var resul = srv.Existe_Mail(mail);
            return Json(resul ? string.Format("El mail ingresado ya existe en el sistema") : "true");
        }


        public ActionResult Exito()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }


    }
}