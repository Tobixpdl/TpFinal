using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("ayuda.buyeverything@gmail.com", "utxnqmbbylcrkzwm");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void armarCorreo(string emailUsuario, string asunto, string cuerpo, bool desdeManager)
        {
            email = new MailMessage();
            email.Subject = asunto;
            email.Body = cuerpo;

            if (desdeManager)
            {
                email.From = new MailAddress("ayuda.buyeverything@gmail.com");
                email.To.Add(emailUsuario);
            }
            else
            {
                email.From = new MailAddress(emailUsuario);
                email.To.Add("ayuda.buyeverything@gmail.com");
            }
        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
