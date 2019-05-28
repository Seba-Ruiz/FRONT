using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Acceso;
using Dominio;
using Servicio.DTO;
using Servicio.Servicio;

namespace FrontHP.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

       


        [HttpGet]
        public JsonResult Menu()
        {
            GrupoUsuario gu = new GrupoUsuario();
            var gru = gu.Pertenencia();
            var menu = gu.CargaDto(gru);

            if (menu.Count > 0)
            {
                return Json(menu, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Salir()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Logon", "Login");
        }

       

    }
}