﻿using System;
using System.Collections.Generic;
using System.Linq;
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
            //return RedirectToAction("comingsoon");
            return View();
        }
        //old
        //[Route("hermano/contractor")]
        //public ActionResult HermanoContracting()
        //{
        //    return View();
        //}
    }
}