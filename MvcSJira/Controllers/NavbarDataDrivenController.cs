using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSJira.Models;

namespace MvcSJira.Controllers
{
    public class DataDrivenController : Controller
    {
        public ActionResult DataDriven01()
        {
            PDSAMenuManager1 mgr =
              new PDSAMenuManager1();

            mgr.Load();

            return View(mgr);
        }

        //public ActionResult DataDriven02()
        //{
        //    PDSAMenuManager mgr;
        //    PDSAMenuMock injector = new PDSAMenuMock();

        //    mgr = new PDSAMenuManager(injector);

        //    mgr.Load();

        //    return View(mgr);
        //}

        //public ActionResult DataDriven03()
        //{
        //    PDSAMenuManager mgr;
        //    PDSAMenuXml injector =
        //      new PDSAMenuXml(Server.MapPath("~/Xml/Menus.xml"));

        //    mgr = new PDSAMenuManager(injector);

        //    mgr.Load();

        //    return View(mgr);
        //}

        //public ActionResult DataDriven04()
        //{
        //    PDSAMenuManager mgr;
        //    PDSAMenuDatabase injector =
        //      new PDSAMenuDatabase("Server=Localhost;Database=Sandbox;Integrated Security=Yes");

        //    mgr = new PDSAMenuManager(injector);

        //    mgr.Load();

        //    return View(mgr);
        //}
    }
}