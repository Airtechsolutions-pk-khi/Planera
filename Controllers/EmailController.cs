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
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SendEmailAdminPlaneraGroup(ContactBLL obj, string Subject)
        {
            try
            {
                ViewBag.Contact = "";
                string ToEmail, SubJect, cc, Bcc;
                cc = "";
                Bcc = "";
                ToEmail = ConfigurationManager.AppSettings["ToPG"].ToString();
                SubJect = obj.Subject.ToString();
                string BodyEmail = System.IO.File.ReadAllText(Server.MapPath("~/Template") + "\\" + "contact.txt");
                DateTime dateTime = DateTime.UtcNow.Date;
                BodyEmail = BodyEmail
                .Replace("#Date#", dateTime.ToString("dd/MMM/yyyy"))
                .Replace("#Name#", obj.Name.ToString())
                .Replace("#Email#", obj.Email.ToString())
                .Replace("#Subject#", obj.Subject.ToString())
                .Replace("#Message#", obj.Message.ToString());


                MailMessage mail = new MailMessage();
                mail.To.Add(ToEmail);


                mail.From = new MailAddress(ConfigurationManager.AppSettings["FromPG"].ToString());
                mail.Subject = Subject;
                string Body = BodyEmail;
                mail.Body = Body;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPort"].ToString());
                smtp.Host = ConfigurationManager.AppSettings["SmtpServer"].ToString(); //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential
                     (ConfigurationManager.AppSettings["FromPG"].ToString(), ConfigurationManager.AppSettings["PasswordPG"].ToString());

                smtp.EnableSsl = false;

                smtp.Send(mail);

                sendemailcustomer(obj.Email.ToString(),"Planera Group | Inquiry","PG");
            }
            catch (Exception ex)
            {
                return Json(new { Success = false });
            }

            return Json(new { Success = true });
        }

        [HttpPost]
        public JsonResult SendEmailAdminInterior(ContactBLL obj, string Subject)
        {
            try
            {
                ViewBag.Contact = "";
                string ToEmail, SubJect, cc, Bcc;
                cc = "";
                Bcc = "";
                ToEmail = ConfigurationManager.AppSettings["ToI"].ToString();
                SubJect = obj.Subject.ToString();
                string BodyEmail = System.IO.File.ReadAllText(Server.MapPath("~/Template") + "\\" + "contact.txt");
                DateTime dateTime = DateTime.UtcNow.Date;
                BodyEmail = BodyEmail
                .Replace("#Date#", dateTime.ToString("dd/MMM/yyyy"))
                .Replace("#Name#", obj.Name.ToString())
                .Replace("#Email#", obj.Email.ToString())
                .Replace("#Subject#", obj.Subject.ToString())
                .Replace("#Message#", obj.Message.ToString());


                MailMessage mail = new MailMessage();
                mail.To.Add(ToEmail);


                mail.From = new MailAddress(ConfigurationManager.AppSettings["FromI"].ToString());
                mail.Subject = Subject;
                string Body = BodyEmail;
                mail.Body = Body;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPort"].ToString());
                smtp.Host = ConfigurationManager.AppSettings["SmtpServer"].ToString(); //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential
                     (ConfigurationManager.AppSettings["FromI"].ToString(), ConfigurationManager.AppSettings["PasswordI"].ToString());

                smtp.EnableSsl = false;

                smtp.Send(mail);

                sendemailcustomer(obj.Email.ToString(), "Planera Interior | Inquiry", "I");
            }
            catch (Exception ex)
            {
                return Json(new { Success = false });
            }

            return Json(new { Success = true });
        }

        [HttpPost]
        public JsonResult SendEmailAdminAB(ContactBLL obj, string Subject)
        {
            try
            {
                ViewBag.Contact = "";
                string ToEmail, SubJect, cc, Bcc;
                cc = "";
                Bcc = "";
                ToEmail = ConfigurationManager.AppSettings["ToA"].ToString();
                SubJect = obj.Subject.ToString();
                string BodyEmail = System.IO.File.ReadAllText(Server.MapPath("~/Template") + "\\" + "contact.txt");
                DateTime dateTime = DateTime.UtcNow.Date;
                BodyEmail = BodyEmail
                .Replace("#Date#", dateTime.ToString("dd/MMM/yyyy"))
                .Replace("#Name#", obj.Name.ToString())
                .Replace("#Email#", obj.Email.ToString())
                .Replace("#Subject#", obj.Subject.ToString())
                .Replace("#Message#", obj.Message.ToString());


                MailMessage mail = new MailMessage();
                mail.To.Add(ToEmail);


                mail.From = new MailAddress(ConfigurationManager.AppSettings["FromA"].ToString());
                mail.Subject = Subject;
                string Body = BodyEmail;
                mail.Body = Body;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPort"].ToString());
                smtp.Host = ConfigurationManager.AppSettings["SmtpServer"].ToString(); //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential
                     (ConfigurationManager.AppSettings["FromA"].ToString(), ConfigurationManager.AppSettings["PasswordA"].ToString());

                smtp.EnableSsl = false;

                smtp.Send(mail);

                sendemailcustomer(obj.Email.ToString(), "Planera Group | Activar | Inquiry", "A");
            }
            catch (Exception ex)
            {
                return Json(new { Success = false });
            }

            return Json(new { Success = true });
        }
        [HttpPost]
        public JsonResult SendEmailAdminHermano(ContactBLL obj, string Subject)
        {
            try
            {
                ViewBag.Contact = "";
                string ToEmail, SubJect, cc, Bcc;
                cc = "";
                Bcc = "";
                ToEmail = ConfigurationManager.AppSettings["ToH"].ToString();
                SubJect = obj.Subject.ToString();
                string BodyEmail = System.IO.File.ReadAllText(Server.MapPath("~/Template") + "\\" + "contacthermano.txt");
                DateTime dateTime = DateTime.UtcNow.Date;
                BodyEmail = BodyEmail
                .Replace("#Date#", dateTime.ToString("dd/MMM/yyyy"))
                .Replace("#Name#", obj.Name.ToString())
                .Replace("#Phone#", obj.Phone.ToString())
                .Replace("#Email#", obj.Email.ToString())
                .Replace("#Subject#", obj.Subject.ToString())
                .Replace("#Message#", obj.Message.ToString());


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

                sendemailcustomer(obj.Email.ToString(), "Planera Group | Hermano | Inquiry", "H");
            }
            catch (Exception ex)
            {
                return Json(new { Success = false });
            }

            return Json(new { Success = true });
        }

        [HttpPost]
        public JsonResult SendEmailPGCareer(ContactBLL obj, string Subject)
        {
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }
                        ViewBag.Contact = "";
                        string ToEmail, SubJect, cc, Bcc;
                        cc = "";
                        Bcc = "";

                        ToEmail = ConfigurationManager.AppSettings["ToPGC"].ToString();
                        SubJect = obj.Subject.ToString();
                        string BodyEmail = System.IO.File.ReadAllText(Server.MapPath("~/Template") + "\\" + "contact.txt");
                        DateTime dateTime = DateTime.UtcNow.Date;
                        BodyEmail = BodyEmail.Replace("#Date#", dateTime.ToString("dd/MMM/yyyy"))

                        .Replace("#Name#", obj.Name.ToString())
                        .Replace("#Email#", obj.Email.ToString())
                        .Replace("#Subject#", "JOB APPLICATION".ToString())
                        .Replace("#Message#", obj.Message.ToString());

                        MailMessage mail = new MailMessage();
                        mail.To.Add(ToEmail);

                        mail.From = new MailAddress(ConfigurationManager.AppSettings["FromPGC"].ToString());
                        mail.Subject = Subject;
                        string Body = BodyEmail;
                        mail.Body = Body;
                        mail.IsBodyHtml = true;
                        if (file != null)
                        {
                            mail.Attachments.Add(new Attachment(file.InputStream, file.FileName));
                        }
                        SmtpClient smtp = new SmtpClient();
                        smtp.UseDefaultCredentials = false;
                        smtp.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPort"].ToString());
                        smtp.Host = ConfigurationManager.AppSettings["SmtpServer"].ToString(); //Or Your SMTP Server Address
                        smtp.Credentials = new System.Net.NetworkCredential
                             (ConfigurationManager.AppSettings["FromPGC"].ToString(), ConfigurationManager.AppSettings["PasswordPGC"].ToString());

                        smtp.EnableSsl = false;

                        smtp.Send(mail);

                        sendemailcustomer(obj.Email.ToString(), "Planera Group | Job Application", "PGC");
                    }
                    // Returns message that successfully uploaded  
                    return Json(new { Success = true });
                }
                catch (Exception ex)
                {
                    return Json(new { Success = false });
                }
            }
            else
            {
                return Json(new { Success = false });
            }
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