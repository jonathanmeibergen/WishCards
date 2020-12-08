using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WishCards.SmtpMailService
{
    public static class SendCustomerMail
    {
        public static void SendMailToCustomer(string email, string pathfile)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("testmailopdracht@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Christmas card";
                mail.Body = "Dear Sir/Ma'am we wish you a well christmas and a happy new year, in the attachment you will find the christmas card.";
                mail.IsBodyHtml = true;
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(pathfile);
                mail.Attachments.Add(attachment);

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new System.Net.NetworkCredential("testmailopdracht@gmail.com", "testmail");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}
