/*
  Author:    Joshua Lipio
  Date:      9/27/2019
  Course:    CS 4540, University of Utah, School of Computing
  Copyright: CS 4540 and Joshua Lipio - This work may not be copied for use in Academic Coursework.

  I, Joshua Lipio, certify that I wrote this code from scratch and did not copy it in part or whole from
  another source.  Any references used in the completion of the assignment are cited in my README file.
*/

using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
namespace Learning_Outcome_Tracker.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var task = new Task(() =>
            {
                SmtpClient smtpClient = new SmtpClient("smtp.utah.edu", 25);
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("admin@cs4540.com", "LOT");
                mail.To.Add(new MailAddress(email));

                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                smtpClient.Send(mail);
            });
            task.Start();
            return task;
        }
    }
}