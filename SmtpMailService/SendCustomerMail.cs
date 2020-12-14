using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using WishCards.Enumerations;

namespace WishCards.SmtpMailService
{
    #region mailservice
    public static class SendCustomerMail
    {
        public static void SendMailToCustomer(string email, string pathfile, Mp3Enum mp3)
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
                string songfilepath;
                if (mp3 == Mp3Enum.Jingle1)
                {
                    var filename = "Andy Williams - It's The Most Wonderful Time Of The Year.mp3";
                    FileInfo f = new FileInfo(filename);
                    songfilepath = f.FullName;
                }
                if (mp3 == Mp3Enum.Jingle2)
                {
                    var filename = "Mariah Carey - All I Want For Christmas Is You (Official Video).mp3";
                    FileInfo f = new FileInfo(filename);
                    songfilepath = f.FullName;
                }
                else
                {
                    var filename = "Wham! - Last Christmas (Official Video).mp3";
                    FileInfo f = new FileInfo(filename);
                    songfilepath = f.FullName;
                }
                System.Net.Mail.Attachment songattachment = new Attachment(songfilepath);
                mail.Attachments.Add(songattachment);
                mail.Attachments.Add(attachment);

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("testmailopdracht@gmail.com", "testmail");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }

            }
        }
    }

    #endregion
}
