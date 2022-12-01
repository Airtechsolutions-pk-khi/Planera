using Planera.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Planera.Controllers
{
    public class ActivarDubaiController : Controller
    {
        // GET: ActivarDubai
        [Route("planera/activardubai")]
        public ActionResult ActivarDubaiHome()
        {
            ViewBag.DubaiHome = HomePageBLL.GetACDB();
            //return RedirectToAction("comingsoon");
            return View();
        }
    }
}