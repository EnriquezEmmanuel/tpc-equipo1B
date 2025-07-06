using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
    public class ServicioEmail
    {
        private MailMessage email;
        private SmtpClient server;
        public ServicioEmail()
        {
            server = new SmtpClient("sandbox.smtp.mailtrap.io", 587);
            server.Credentials = new NetworkCredential("c814023631e3ec", "9370ca069b699a");
            server.EnableSsl = true;
        }
        public void ArmarCorreo(string emailDestino, string asunto, string mensaje)
        {
            email = new MailMessage();
            email.From = new MailAddress("no-responder@print360.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = "<h1>Recuperacion de contraseña</h1><p>"+mensaje+"</p>";
        }
        public void EnviarMail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception)
            { throw; }
        }
    }
}
