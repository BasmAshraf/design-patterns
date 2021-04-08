using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace TheOrderKata
{
    public class EmailInvoiceCreation : InvoiceCreation
    {
        public override void Generate(Order order)
        {
            using (SmtpClient client = new SmtpClient("smtp.sendgrid.net", 587))
            {
                NetworkCredential credentials = new NetworkCredential("username", "password");
                client.Credentials = credentials;

                MailMessage mail = new MailMessage("basma.farag@integrant.com", "basma.farag@integrant.com")
                {
                    Subject = "We've created an invoice for your order",
                    Body = GenerateTextInvoice(order)
                };

                client.Send(mail);
            }
        }
    }
}
