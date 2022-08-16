using Planera.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Planera.Controllers
{
    public class HermanoController : Controller
    {
        // GET: Harmano
        [Route("hermano/repair-maintenance")] 
        public ActionResult HermanoHome()
        {
            //return RedirectToAction("/planera/comingsoon");
            return View();
        }
        [Route("hermano/repair-maintenance/services")]
        public ActionResult HermanoRMService()
        {
            //return RedirectToAction("/planera/comingsoon");
            return View();
        }
        [Route("hermano/repair-maintenance/contact")]
        public ActionResult HermanoRMContact()
        {
            //return RedirectToAction("/planera/comingsoon");
            return View();
        }
        [Route("hermano/repair-maintenance/projects")]
        public ActionResult HermanoRMProjects()
        {
            //return RedirectToAction("/planera/comingsoon");
            return View();
        }
        //old
        //[Route("hermano/contractor")]
        //public ActionResult HermanoContracting()
        //{
        //    return View();
        //}
        [Route("hermano/repair-maintenance/about")]
        public ActionResult HermanoRMAbout()
        {
            return View();
        }
        public JsonResult SendEmailToAdmin(BookNow obj, string Subject)
        {
            try
            {
                ViewBag.Contact = "";
                string ToEmail, SubJect, cc, Bcc;
                cc = "";
                Bcc = "";
                ToEmail = ConfigurationManager.AppSettings["To"].ToString();
                SubJect = obj.Details.ToString();
                string BodyEmail = System.IO.File.ReadAllText(Server.MapPath("~/Template") + "\\" + "contact.txt");
                DateTime dateTime = DateTime.UtcNow.Date;
                BodyEmail = BodyEmail.Replace("#Date#", dateTime.ToString("dd/MMM/yyyy"))
                .Replace("#FName#", obj.FName.ToString())
                .Replace("#LName#", obj.LName.ToString())
                .Replace("#Email#", obj.Email.ToString())
                .Replace("#Phone#", obj.Phone.ToString())
                .Replace("#Service#", obj.Service.ToString())
                .Replace("#Time#", obj.Service.ToString())
                .Replace("#Details#", obj.Details.ToString());


                MailMessage mail = new MailMessage();
                mail.To.Add(ToEmail);


                mail.From = new MailAddress(ConfigurationManager.AppSettings["From"].ToString());
                mail.Subject = Subject;
                string Body = BodyEmail;
                mail.Body = Body;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPort"].ToString());
                smtp.Host = ConfigurationManager.AppSettings["SmtpServer"].ToString(); //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential
                     (ConfigurationManager.AppSettings["From"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());

                smtp.EnableSsl = true;

                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false });
            }

            return Json(new { Success = true });
        }
    }
}