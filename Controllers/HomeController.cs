using planera.Models.Service;
using Planera.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Planera.Controllers
{
    public class HomeController : BaseController
    {
        homeService _service;
        newsalertService _nservice;
        public HomeController()
        {

            _service = new homeService();
            _nservice = new newsalertService();


        }
        public ActionResult Main()
        {
            return View();
        }


        [Route("planera/homeold")]
        public ActionResult Home()
        {
            return View();
        }

        [Route("")]
        [Route("planera/home")]
        public ActionResult Homev2()
        {
            //HttpCookie lang = new HttpCookie("lang");
            //lang.Value = "en";
            //lang.Expires = DateTime.Now.AddHours(1);
            //Response.Cookies.Add(lang);
            //Response.Flush();
            ViewBag.NewsAlert = _nservice.GetAll();
            return View();
        }


        [Route("planera/contact")]
        public ActionResult ContactPlaneraGroup()
        {
            //return RedirectToAction("comingsoon");
            return View();
        }

        [Route("activardubai/home/OLD")]
        public ActionResult ActivarDubai()
        {
            //return RedirectToAction("comingsoon");
            return View();
        }

        [Route("planera/activarbahrainold")]
        public ActionResult ActivarBH()
        {
            //return RedirectToAction("comingsoon");
            return View();
        }

        [Route("planera/activarbahrain")]
        public ActionResult ActivarBHV2()
        {
            ViewBag.Home = HomePageBLL.GetACBH();
            ViewBag.Gallery = GalleryBLL.GetGalleryAcBah();
            //return RedirectToAction("comingsoon");
            return View();
        }
        [Route("planera/activarbahrain/about")]
        public ActionResult ActivarBHAbout()
        {
            return View();
        }

        [Route("planera/activarbahrain/service")]
        public ActionResult ActivarBHService()
        {
            return View();
        }
        [Route("planera/activarbahrain/contact")]
        public ActionResult ActivarBHContact()
        {
            return View();
        }
        [Route("planera/activarbahrain/gallery")]
        public ActionResult ActivarBHGallery()
        {
            ViewBag.Gallery = GalleryBLL.GetGalleryAcBah();
            return View();
        }
        [Route("planera/hermano-contracting")]
        public ActionResult HermanoCHome()
        {
            ViewBag.ContHome = HomePageBLL.GetCont();
            //return RedirectToAction("comingsoon");
            return View();
        }
        [Route("hermano-contracting/about")]
        public ActionResult HermanoCAbout()
        {
            //return RedirectToAction("comingsoon");
            return View();
        }
        [Route("hermano-contracting/contact")]
        public ActionResult HermanoCContact()
        {
            //return RedirectToAction("comingsoon");
            return View();
        }
        [Route("hermano-contracting/projects")]
        public ActionResult HermanoCProject()
        {
            ViewBag.Gallery = GalleryBLL.GetGalleryHrCnt();
            //return RedirectToAction("comingsoon");
            return View();
        }
        [Route("hermano-contracting/services")]
        public ActionResult HermanoCService()
        {
            //return RedirectToAction("comingsoon");
            return View();
        }
        [Route("planera/interiorv2")]
        public ActionResult PlaneraInterior()
        {
            //return RedirectToAction("comingsoon");
            return View();
        }

        [Route("planera/interior")]
        // [HttpGet("all/{brandid}")]
        public ActionResult PlaneraInteriorv2()
        {
            ViewBag.InteriorHome = HomePageBLL.GetAll();
            ViewBag.Gallery = GalleryBLL.GetAll();
            return View();
        }

        //public ActionResult PlaneraInteriorv2()
        //{
        //    //return RedirectToAction("comingsoon");
        //    return View();
        //}

        [Route("planera/general-trading")]
        public ActionResult PlaneraGeneralTrading()
        {
            return RedirectToAction("comingsoon");
            //return View();
        }

        [Route("planera/career")]
        public ActionResult PlaneraCareer()
        {
            //return RedirectToAction("comingsoon");
            return View();
        }

        [Route("planera/newsevents")]
        public ActionResult NewsEvents()
        {
            ViewBag.News = _nservice.GetNews();
            ViewBag.Event = _nservice.GetEvents();
            return View();
        }

        [Route("planera/ourbusiness1")]
        public ActionResult OurBusinesses()
        {
            //return RedirectToAction("comingsoon");
            return View();
        }
        [Route("planera/ourbusiness")]
        public ActionResult OurBusinessesV2()
        {
            //return RedirectToAction("comingsoon");
            return View();
        }

        [Route("planera/comingsoon")]
        public ActionResult ComingSoon()
        {
            return View();
        }
        [Route("interior/comingsoon")]
        public ActionResult ComingSoonInterior()
        {
            return View();
        }
        [Route("planera/overview")]
        public ActionResult CompanyOverview()
        {
            return View();
        }

        public JsonResult SendEmailToAdmin(ContactBLL obj, string Subject)
        {
            try
            {
                ViewBag.Contact = "";
                string ToEmail, SubJect, cc, Bcc;
                cc = "";
                Bcc = "";
                ToEmail = ConfigurationManager.AppSettings["To"].ToString();
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

        [HttpPost]
        public JsonResult SendEmailAdmin(ContactBLL obj, string Subject)
        {
            try
            {
                ViewBag.Contact = "";
                string ToEmail, SubJect, cc, Bcc;
                cc = "";
                Bcc = "";
                ToEmail = ConfigurationManager.AppSettings["To"].ToString();
                SubJect = obj.Subject.ToString();
                string BodyEmail = System.IO.File.ReadAllText(Server.MapPath("~/Template") + "\\" + "contact.txt");
                DateTime dateTime = DateTime.UtcNow.Date;
                BodyEmail = BodyEmail.Replace("#Date#", dateTime.ToString("dd/MMM/yyyy"))

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

                //System.Net.Mail.Attachment attachment;
                //string filename = System.IO.Path.GetFileName(FileName);

                //string filepathtoattach = "Images/" + filename;
                //attachment = new System.Net.Mail.Attachment(Server.MapPath(filepathtoattach));
                //mail.Attachments.Add(attachment);



                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPort"].ToString());
                smtp.Host = ConfigurationManager.AppSettings["SmtpServer"].ToString(); //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential
                     (ConfigurationManager.AppSettings["FromPG"].ToString(), ConfigurationManager.AppSettings["PasswordPG"].ToString());

                smtp.EnableSsl = true;

                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false });
            }

            return Json(new { Success = true });
        }

        public JsonResult uploadFile()
        {
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;

                    HttpPostedFileBase file = files[0];
                    string fileName = file.FileName;

                    return Json("File uploaded successfully");
                }

                catch (Exception e)
                {
                    return Json("error" + e.Message);
                }
            }

            return Json("no files were selected !");
        }

        [Route("interior/about")]
        public ActionResult AboutInterior()
        {
            return View();
        }

        [Route("interior/services")]
        public ActionResult InteriorService()
        {
            ViewBag.Service = ServiceBLL.GetAll();
            return View();
        }
        [Route("interior/Contact")]
        public ActionResult ContactInterior()
        {
            return View();
        }
        [Route("interior/project")]
        public ActionResult ProjectInterior()
        {
            ViewBag.Project = GalleryBLL.GetAll();
            return View();
        }
        public ActionResult HomenewsAlert()
        {
            ViewBag.NewsAlert = new newsalertService().GetAll();
            return View();
        }
    }
}