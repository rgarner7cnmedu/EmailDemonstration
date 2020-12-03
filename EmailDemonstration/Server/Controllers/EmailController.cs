using EmailDemonstration.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Mail;

namespace EmailDemonstration.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpGet]
        public string GetEmail()
        {
            return "Hello from email controller";
        }

        [HttpPost]
        public IActionResult PostEmail(Email email)
        {
            //TODO: Move to app.config
            const string smtpAddress = "smtp.gmail.com";
            const int portNumber = 587;
            const string adminEmail = "blazordemo.emmw@gmail.com"; //Sender Email Address  
            const string password = "Suncat123!"; //Sender Password 

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(email.Address);
                    mail.To.Add( adminEmail);
                    mail.Subject = email.Subject;
                    mail.Body = email.Message;
                    mail.IsBodyHtml = true;
                    //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(adminEmail, password);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
                return Ok();
            }
            catch (Exception exc)
            {
                return NotFound(exc.Message);
            }
        }
    }
}
