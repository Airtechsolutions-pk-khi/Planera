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
            ViewBag.Home = HomePageBLL.GetHarmano();
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
        [Route("hermano/repair-maintenance/gallery")]
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
        public JsonResult SendEmailToAdminBookNow(BookNow obj, string Subject)
        {
            try
            {
                ViewBag.Contact = "";
                string ToEmail, SubJect, cc, Bcc;
                cc = "";
                Bcc = "";
                ToEmail = ConfigurationManager.AppSettings["ToH"].ToString();
                SubJect = obj.Details.ToString();
                string BodyEmail = System.IO.File.ReadAllText(Server.MapPath("~/Template") + "\\" + "booknow.txt");
                DateTime dateTime = DateTime.UtcNow.Date;
                BodyEmail = BodyEmail.Replace("#Date#", dateTime.ToString("dd/MMM/yyyy"))
                .Replace("#FName#", obj.FName.ToString())
                .Replace("#LName#", obj.LName.ToString())
                .Replace("#Email#", obj.Email.ToString())
                .Replace("#Phone#", obj.Phone.ToString())
                .Replace("#Service#", obj.Service.ToString())
                .Replace("#Time#", obj.Time.ToString())
                .Replace("#Details#", obj.Details.ToString());


                MailMessage mail = new MailMessage();
                mail.To.Add(ToEmail);


                mail.From = new MailAddress(ConfigurationManager.AppSettings["FromH"].ToString());
                mail.Subject = Subject;
                string Body = BodyEmail;
                mail.Body = Body;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPort"].ToString());
                smtp.Host = ConfigurationManager.AppSettings["SmtpServer"].ToString(); //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential
                     (ConfigurationManager.AppSettings["FromH"].ToString(), ConfigurationManager.AppSettings["PasswordH"].ToString());

                smtp.EnableSsl = false;

                smtp.Send(mail);

                sendemailcustomer(obj.Email.ToString(), "Planera Group | Hermano | Book Service", "H");
            }
            catch (Exception ex)
            {
                return Json(new { Success = false });
            }

            return Json(new { Success = true });
        }

        public void sendemailcustomer(string toemail, string subject, string key)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(toemail);


                mail.From = new MailAddress(ConfigurationManager.AppSettings["From" + key].ToString());
                mail.Subject = subject;
                string Body = "Thankyou for contacting us, we have received your query. Our team will contact you soon.";
                mail.Body = Body;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPort"].ToString());
                smtp.Host = ConfigurationManager.AppSettings["SmtpServer"].ToString(); //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential
                     (ConfigurationManager.AppSettings["From" + key].ToString(), ConfigurationManager.AppSettings["Password" + key].ToString());

                smtp.EnableSsl = false;

                smtp.Send(mail);

            }
            catch (Exception)
            {
            }
        }
    }
}