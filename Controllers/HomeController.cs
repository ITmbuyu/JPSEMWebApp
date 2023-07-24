using JPSEMWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace JPSEMWebApp.Controllers
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

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Contact(Home home)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Form is valid, send the email
        //        SendEmail(home);

        //        // Redirect to the ThankYou page
        //        return RedirectToAction("ThankYou");
        //    }

        //    // If the form is not valid, return the view with the entered values
        //    return View(home);
        //    return RedirectToAction("ThankYou");
        //}


        ////method to send email 
        //public void SendEmail(Home home)
        //{
        //    var email = home.Email;
        //    string message = home.Message;
        //    // Sendemail
        //    var senderEmail = new MailAddress("info@jpsemnetworkers.co.za", "JPSEM NETWORKERS");
        //    var recieverMail = new MailAddress(email, "Client");
        //    var password = "Dut980924";
        //    var sub = home.Subject;
        //    var body = message;

        //    var smtp = new SmtpClient
        //    {
        //        Host = "mail.jpsemnetworkers.co.za",
        //        Port = 465,
        //        // EnableSsl = false,
        //        EnableSsl = true,
        //        DeliveryMethod = SmtpDeliveryMethod.Network,
        //        UseDefaultCredentials = false,
        //        Timeout = 5000,
        //        Credentials = new NetworkCredential(senderEmail.Address, password)
        //    };
        //    using (var mess = new MailMessage(senderEmail, recieverMail)
        //    {
        //        Subject = sub,
        //        Body = body
        //    })
        //    {
        //        smtp.Send(mess);
        //    }
        //}





        public IActionResult thankyou()
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