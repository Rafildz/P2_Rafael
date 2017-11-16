using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P2TalpRaf
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SmtpClient cliente = new SmtpClient();
            cliente.Host = "smtp.gmail.com";
            cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
            cliente.EnableSsl = true;
            cliente.Port = 587;

            System.Net.NetworkCredential credenciais = new NetworkCredential("rafaelblima22@gmail.com", "mudar234");
            cliente.Credentials = credenciais;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("rafaelblima22@gmail.com");
            mail.To.Add(new MailAddress(TextBox2.Text));
            mail.Body = TextBox3.Text;
            cliente.Send(mail);
        }
    }
}