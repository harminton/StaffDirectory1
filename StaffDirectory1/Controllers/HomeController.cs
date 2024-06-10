using Microsoft.AspNetCore.Mvc;
using StaffDirectory1.Models;
using System.Diagnostics;
using System.Net.Mail;
using System.Reflection.Emit;

namespace StaffDirectory1.Controllers
{
    public class HomeController : Controller
    {
        //Global Declarations
        string MailBody = "<DOCTYPE html>" +
                                "<hmtl" +
                                "<body style=\"background -color:#ff7f26;texh-alinge:center\"> " +
                                "h1 style=\"color:#051a80;\">Wolcome to Avondale Collage</h1> " +
                                "h2 style=\"color:#fff;\">Please find the attached files.<h2> " +
                                "label style=\"color:orange;font-size:100px;border:5px dotted;border<label> " +
                                "</body> " +
                                "<html> ";
        
        string mailTitle = "Attached Demo";
        string mailSubject = "Email With Attachment";
        string fromEmail = "your email";
        string mailPassword = "Your mail password";
        string toEmail;
        string fileToAttach;
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string toEmail, IFormFile fileToAttach)
        {
            return View();
        }

        public IActionResult Privacy()
        {
            //Mail message
            MailMessage message = new MailMessage(new MailAddress(fromEmail, mailTitle), new MailAddress(toEmail));

            //Mail Content
            message.Subject = mailSubject;
            message.Body = MailBody;
            message.IsBodyHtml = true;

            //Attachment
            message.Attachments.Add(new Attachment(fileToAttach.OpenRead(), fileToAttach.FileName));
            //Server details

            //Credentials


            return View();
        }


    }
}
