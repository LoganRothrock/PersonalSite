using PersonalSite.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;



namespace PersonalSite.UI.MVC.Controllers
{
    public class StronglyTypedDataController : Controller
    {
        // GET: StronglyTypedData
        public ActionResult Index()
        {
            return View();
        }

        //GET
        public ActionResult Contact()
        {
            return View();
        }
        //POST

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel cvm)
        {

            if (!ModelState.IsValid)
            {
                return View(cvm);
            }

            string emailBody = $"You have received an email from {cvm.Name} with a subject {cvm.Subject}. Please respond to {cvm.Email} with your response to the following message: <br /> <br />{cvm.Message}";
            MailMessage msg = new MailMessage("no-reply@loganrothrock.com", "loganrothrock@gmail.com", "Email from loganrothrock.com", emailBody);
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.High;
            msg.CC.Add("email@domain.com"); //can be used to attach other recipients to the message
            SmtpClient client = new SmtpClient("mail.loganrothrock.com");
            client.Credentials = new NetworkCredential("no-reply@loganrothrock.com", "WorstUrchin7539!");

            try
            {
                client.Send(msg);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Sorry, something went wrong. Error message: {ex.Message} <br />{ex.StackTrace}";
                return View(cvm);
            }
            return View("EmailConfirmation", cvm);
        }

    }
}