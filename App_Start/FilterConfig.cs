using System;
using System.Web;
using System.Web.Mvc;

namespace Planera
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new MyCookieFilter());
            filters.Add(new HandleErrorAttribute());
        }
       
    }
    public class MyCookieFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var chkcookie=filterContext.HttpContext.Request.Cookies.Get("lang");
            if (chkcookie == null)
            {
                HttpCookie cookie =new HttpCookie("lang");
                cookie.Value = "en";
                cookie.Expires = DateTime.Now.AddDays(365);
                filterContext.HttpContext.Response.SetCookie(cookie);
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // Put anything here you want to run after the action method (or leave empty)
        }
    }
}
