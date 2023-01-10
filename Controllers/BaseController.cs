using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Planera.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            // cookie();
        }
        //public void cookie()
        //{
        //    HttpCookie lang = new HttpCookie("lang");
        //    lang.Value = "en";
        //    lang.Expires = DateTime.Now.AddHours(1);
        //    Response.Cookies.Add(lang);
        //}
        public HttpCookie CreateStudentCookie()
        {
            HttpCookie StudentCookies = new HttpCookie("lang");
            StudentCookies.Value = "en";
            StudentCookies.Expires = DateTime.Now.AddDays(365);
            return StudentCookies;
        }
        // GET: Base
        public ActionResult Index()
        {
            return View();
        }
    }
}