using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using PersonalSiteV2.UI.MVC.Models;

namespace PersonalSiteV2.UI.MVC.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                string body = $"{cvm.Name} has sent you a message: <br /> {cvm.Message} <strong> from the email address </strong> {cvm.Email}";

                MailMessage msg = new MailMessage("no-reply@loganrothrock.com", "loganrothrock@gmail.com", "Email from loganrothrock.com", body);

                msg.IsBodyHtml = true;
                msg.Priority = MailPriority.High;

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
            else
            {
                return View(cvm);
            }
        }
    }
}