using System.Web.Mvc;
using StoreFront.UI.MVC.Models;
using System.Net.Mail;
using System.Net;
using System; // Exception Handling (try/catch)

namespace StoreFront.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                string message = $"You have recieved an email from {cvm.Name} with the subject of {cvm.Subject}.  Please respond to {cvm.Email} with your response to the following message: <br/> {cvm.Message}";

                MailMessage mm = new MailMessage("admin@davidsee.net", "engr317@gmail.com", cvm.Subject, message);

                mm.IsBodyHtml = true;
                mm.Priority = MailPriority.High;
                mm.ReplyToList.Add(cvm.Email);

                //this is the info from the host that allows this message to be sent
                SmtpClient client = new SmtpClient("mail.davidsee.net");

                client.Credentials = new NetworkCredential("admin@davidsee.net", "767902Ks!");

                //set the port
                client.Port = 8889;

                try
                {
                    client.Send(mm);
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "We're sorry, you suck!";
                    return View(cvm);
                }

                return View("EmailConfirmation", cvm);

            }
            else //if model state is not valid
            {
                //send back the form with the completed inputs so the user can try again.
                return View(cvm);
            }
        }
    }
}
