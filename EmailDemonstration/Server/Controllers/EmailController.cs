using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailDemonstration.Shared;
using System.Net.Mail;
using System.Net;

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
            const string emailFromAddress = "blazordemo.emmw@gmail.com"; //Sender Email Address  
            const string password = "Suncat123!"; //Sender Password 

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFromAddress);
                    mail.To.Add(email.Address);
                    mail.Subject = email.Subject;
                    mail.Body = email.Message;
                    mail.IsBodyHtml = true;
                    //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFromAddress, password);
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
