using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Servicio.Servicio
{
    public class servicio_mail
    {
        public async Task MandarMail()
        {
            await Task.Run(() =>
            {
                servicio_subordinado svc = new servicio_subordinado();
                string sub = "Querí waifai";

                //var dest = svc.Correo_Subordinado();
                var dest = "mdiegosebastian@gmail.com";

                if (dest != null && dest != "")
                {
                    try
                    {
                        MailMessage correo = new MailMessage();

                        correo.From = new MailAddress("calidad.hperrupato@gmail.com");
                        correo.To.Add(dest);
                        correo.Subject = sub;
                        correo.Body = "Prueba para envio de correos";
                        correo.IsBodyHtml = true;
                        correo.Priority = MailPriority.Normal;

                        ConfigMail(correo);
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Error al crear E-Mail", e);
                    }
                }
            });
        }
        public void ConfigMail(MailMessage correo)
        {
            var mail = "calidad.hperrupato@gmail.com";
            var clave = "Calidad2018";
            try
            {
                SmtpClient smtp = new SmtpClient();
                //smtp.Host = "smtp.live.com"; hotmail,outlook
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 25;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new System.Net.NetworkCredential(mail, clave);
                smtp.Send(correo);
            }
            catch (Exception e)
            {
                throw new Exception("Error al enviar E-Mail", e);
            }
        }
    }
}
