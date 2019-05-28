using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace FrontHP
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            // Extract the forms authentication cookie
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = Context.Request.Cookies[cookieName];
            if (null == authCookie)
            {
                // There is no authentication cookie.
                return;
            }
            FormsAuthenticationTicket authTicket = null;
            try
            {
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            }
            catch (Exception ex)
            {
                // Log exception details (omitted for simplicity)
                return;
            }
            if (null == authTicket)
            {
                // Cookie failed to decrypt.
                return;
            }
            // When the ticket was created, the UserData property was assigned a
            // pipe delimited string of group names.
            String[] groups = authTicket.UserData.Split(new char[] { '|' });
            // Create an Identity object
            GenericIdentity id = new GenericIdentity(authTicket.Name,
            "LdapAuthentication");
            // This principal will flow throughout the request.
            GenericPrincipal principal = new GenericPrincipal(id, groups);
            // Attach the new principal object to the current HttpContext object
            Context.User = principal;
            //Muestra lista de grupos del usr
            //Response.Write("Groups: " + authTicket.UserData + "<br>");
        }
    }
}
