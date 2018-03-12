using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using PostEmailsEncriptados.Models;

namespace PostEmailsEncriptados.Controllers
{
    public class HomeController : Controller
    {
     
        [HttpGet]
        public ActionResult EnviarCorreo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EnviarCorreo(String para, String asunto, String mensaje
            , HttpPostedFileBase fichero)
        {
            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("correosencriptados123@gmail.com", "JJ");
                correo.To.Add(para);
                correo.Subject = asunto;
                correo.Body = Cipher.Encrypt(mensaje, "123");
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 25;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                string sCuentaCorreo = "correosencriptados123@gmail.com";
                string sPasswordCorreo = "tajamar365";
                smtp.Credentials = new System.Net.NetworkCredential(sCuentaCorreo, sPasswordCorreo);
                smtp.Send(correo);
                ViewBag.Mensaje = "Mensaje enviado correctamente";
              
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }

    }
}