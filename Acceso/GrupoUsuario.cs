using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Modelo;

namespace Acceso
{
    public class GrupoUsuario
    {
        public List<DTOMenu> CargaDto(string[] gru)
        {
            FRONTEntities ctx = new FRONTEntities();
            var db = (from a in ctx.WEB_Servicio
                      from b in ctx.WEB_Aplicacion
                      from c in ctx.WEB_AppxServicio
                      where gru.Contains(a.servicio)
                      && c.idservicio == a.idservicio
                      && c.idapp == b.idapp
                      select new { b.nombre, b.ruta}).ToList();

             db = db.Distinct().ToList();


            List<DTOMenu> lista = new List<DTOMenu>();

            foreach (var item in db)
            {
                DTOMenu m = new DTOMenu();
                m.app = item.nombre;
                m.ruta = item.ruta;

                lista.Add(m);
            }

            return lista;
        }

        public string[] Pertenencia()
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            string[] gad = null;
            if (authCookie != null)
            {
                //Extract the forms authentication cookie
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                // If caching roles in userData field then extract
                gad = authTicket.UserData.Split(new char[] { '|' });
            }
            return gad;
        }

        //public List<GruposAD> Pertenencia()
        //{
        //    List<GruposAD> grupos = new List<GruposAD>();
        //    HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
        //    if (authCookie != null)
        //    {
        //        //Extract the forms authentication cookie
        //        FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

        //        // If caching roles in userData field then extract
        //        string[] gad = authTicket.UserData.Split(new char[] { '|' });
        //        foreach (var item in gad)
        //        {
        //            if (item != "")
        //            {
        //                GruposAD g = new GruposAD();
        //                g.grupo = item;
        //                grupos.Add(g);
        //            }
        //        }
        //    }
        //    return grupos;
        //}


        //public List<GruposAD> Pertenencia()
        //{
        //    List<GruposAD> grupos = new List<GruposAD>();
        //    HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
        //    if (authCookie != null)
        //    {
        //        //Extract the forms authentication cookie
        //        FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

        //        // If caching roles in userData field then extract
        //        string[] gad = authTicket.UserData.Split(new char[] { '|' });
        //        foreach (var item in gad)
        //        {
        //            if (item != "")
        //            {
        //                GruposAD g = new GruposAD();
        //                g.grupo = item;
        //                grupos.Add(g);
        //            }
        //        }
        //    }
        //    return grupos;
        //}
        //Codigo para meter grupos en un arreglo de string
        //ViewBag.coso = User.Identity.Name; //nombre de usuario
        //HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
        //if (authCookie != null)
        //{
        //    //Extract the forms authentication cookie
        //    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

        //    // If caching roles in userData field then extract
        //    string[] roles = authTicket.UserData.Split(new char[] { '|' });
        //}


    }
}
