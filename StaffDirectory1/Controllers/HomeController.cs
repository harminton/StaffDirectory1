using Microsoft.AspNetCore.Mvc;
using StaffDirectory1.Models;
using System.Diagnostics;
using System.Net.Mail;
using System.Reflection.Emit;

namespace StaffDirectory1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


//    {
//Global Declarations
//        string MailBody = "<DOCTYPE html>" +
//                                "<hmtl" +
//                                "<body style=\"background -color:#ff7f26;texh-alinge:center\"> " +
//                                "h1 style=\"color:#051a80;\">Wolcome to Avondale Collage</h1> " +
//                                "h2 style=\"color:#fff;\">Please find the attached files.<h2> " +
//                               "label style=\"color:orange;font-size:100px;border:5px dotted;border<label> " +
//                                "</body> " +
//                                "<html> ";

//        string mailTitle = "Attached Demo";
//        string mailSubject = "Email With Attachment";
//        string fromEmail = "your email";
//        string mailPassword = "Your mail password";
//       string toEmail;
//        string fileToAttach;
//        string Getfilename;


//        public IActionResult Index()
//      {
//            return View();
//        }
//        [HttpPost]
//       public IActionResult Index(string toEmail, IFormFile fileToAttach)
//        {
//            return View();
//        }

//        public IActionResult Privacy()
//        {
//           //Mail message
//            MailMessage message = new MailMessage(new MailAddress(fromEmail, mailTitle), new MailAddress(toEmail));

//Mail Content
//            message.Subject = mailSubject;
//            message.Body = MailBody;
//            message.IsBodyHtml = true;

//Attachment
//            message.Attachments.Add(new Attachment(fileToAttach.OpenReadStrseam(), fileToAttach.FileName));
//            //Server details

//Credentials


//           return View();
//        }


//    }
//}
