using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSJira.Filters;

namespace MvcSJira.Controllers
{
    //[Authorize]
 
    public class TesController : Controller
    {
        //
        // GET: /Project/
        [HttpGet]
        
        public ActionResult Search(string name = "french")
        {

            //var controller = RouteData.Values["controller"];
            //var action = RouteData.Values["action"];
            //var manage = RouteData.Values["name"];
            //TempData["manage"] = RouteData.Values["name"];
            //ViewBag.manage = RouteData.Values["name"];

            //throw new Exception("Something terrible has happened");
            var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];
            var name1 = RouteData.Values["name"];
            var message1 = String.Format("{0}::{1} {2}", controller, action, name1);
            var message = Server.HtmlEncode(name);
            return Content(message);
            //return RedirectPermanent("http://microsoft.com");
            //return Redirect("http://microsoft.com");
            //return RedirectToAction("About","Home");
            //return RedirectToRoute("Default", new { controller = "Home", action = "About" });
            //return File(Server.MapPath("~/Content/site.css"),"text/css");
            //return Json(new { Message=message, Name="Aisat"}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Search()
        {
            //throw new Exception("Something terrible has happened");
            var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];
            var name1 = RouteData.Values["name"];
            var message1 = String.Format("{0}::{1} {2}", controller, action, name1);
            
            return Content("search");
            //return RedirectPermanent("http://microsoft.com");
            //return Redirect("http://microsoft.com");
            //return RedirectToAction("About","Home");
            //return RedirectToRoute("Default", new { controller = "Home", action = "About" });
            //return File(Server.MapPath("~/Content/site.css"),"text/css");
            //return Json(new { Message=message, Name="Aisat"}, JsonRequestBehavior.AllowGet);
        }   


    }
}
