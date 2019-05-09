using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace MLT.MayLocNuocViet.Utilities.Helpers
{
    public class MailHelper
    {


        public static bool SendMail(string To, string CC, string Bcc, string subject, string body, string attachmentFilename = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(new MailAddress(To));
                if (!String.IsNullOrEmpty(CC))
                {
                    string[] listAddress = CC.Split(",");
                    foreach (string address in listAddress)
                    {
                        mail.CC.Add(new MailAddress(address));
                    }
                }
                if (!String.IsNullOrEmpty(Bcc))
                {
                    string[] listAddress = Bcc.Split(",");
                    foreach (string address in listAddress)
                    {
                        mail.Bcc.Add(new MailAddress(address));
                    }
                }
                mail.From = new MailAddress(ConfigHelper.GetByKey("MailHelper:Username"), ConfigHelper.GetByKey("MailHelper:DisplayName"));
                mail.Subject = subject;
                mail.Body = body;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                if (attachmentFilename != null)
                {
                    Attachment attachment = new Attachment(attachmentFilename, MediaTypeNames.Application.Octet);
                    ContentDisposition disposition = attachment.ContentDisposition;
                    disposition.CreationDate = File.GetCreationTime(attachmentFilename);
                    disposition.ModificationDate = File.GetLastWriteTime(attachmentFilename);
                    disposition.ReadDate = File.GetLastAccessTime(attachmentFilename);
                    disposition.FileName = Path.GetFileName(attachmentFilename);
                    disposition.Size = new FileInfo(attachmentFilename).Length;
                    disposition.DispositionType = DispositionTypeNames.Attachment;
                    mail.Attachments.Add(attachment);
                }


                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigHelper.GetByKey("SMTPHost");
                smtp.Port = int.Parse(ConfigHelper.GetByKey("SMTPPort"));
                smtp.Credentials = new NetworkCredential(ConfigHelper.GetByKey("MailHelper:Username"), ConfigHelper.GetByKey("MailHelper:Password"));
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Timeout = 100000;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(mail);
                return true;
            }
            catch (SmtpException)
            {

                return false;
            }
        }
        public static bool SendMail(string toEmail, string subject, string content)
        {
            try
            {
                var host = ConfigHelper.GetByKey("SMTPHost");
                var port = int.Parse(ConfigHelper.GetByKey("SMTPPort"));
                var fromEmail = ConfigHelper.GetByKey("FromEmailAddress");
                var password = ConfigHelper.GetByKey("FromEmailPassword");
                var fromName = ConfigHelper.GetByKey("FromName");

                var smtpClient = new SmtpClient(host, port)
                {
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(fromEmail, password),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    Timeout = 100000
                };

                var mail = new MailMessage
                {
                    Body = content,
                    Subject = subject,
                    From = new MailAddress(fromEmail, fromName)
                };

                mail.To.Add(new MailAddress(toEmail));
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                smtpClient.Send(mail);

                return true;
            }
            catch (SmtpException)
            {

                return false;
            }
        }


        public static string mailTemplate()
        {
            return $"Dear a,";
        }
    }
}

