using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Acceso;


namespace FrontHP.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Logon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logon(string txtUserName,string txtPassword)
        {
            // Path to you LDAP directory server.
            // Contact your network administrator to obtain a valid path.
            string adPath = "LDAP://hperrupato.com.ar/DC=hperrupato,DC=com,DC=ar";
            LdapAuthentication adAuth = new LdapAuthentication(adPath);
            List<GruposAD> groups = new List<GruposAD>();
            var cadena = "";
            try
            {
                if (true == adAuth.IsAuthenticated("hperrupato",
                txtUserName,
                txtPassword))
                {
                    // Retrieve the user's groups
                    groups = adAuth.GetGroups();
                    foreach (var item in groups)
                    {
                        cadena = cadena + item.grupo + "|";
                    }
                    
                    
                    // Create the authetication ticket
                    FormsAuthenticationTicket authTicket =
                    new FormsAuthenticationTicket(1, // version
                    txtUserName,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(60),
                    false, cadena);
                    // Now encrypt the ticket.
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    // Create a cookie and add the encrypted ticket to the 
                    // cookie as data.
                    HttpCookie authCookie =
                    new HttpCookie(FormsAuthentication.FormsCookieName,
                    encryptedTicket);
                    // Add the cookie to the outgoing cookies collection. 
                    Response.Cookies.Add(authCookie);
                    // Redirect the user to the originally requested page
                    Response.Redirect("~/Home/Index");
                    //Response.Redirect(
                    //FormsAuthentication.GetRedirectUrl(txtUserName,
                    //false));
                }
                else
                {
                    @ViewBag.Falla = "Incorrecto, revise usuario y contraseña";
                }
            }
            catch (Exception ex)
            {
                @ViewBag.Falla = "Error de autenticación. " + ex.Message;
            }
            return View();
        }
    }
}