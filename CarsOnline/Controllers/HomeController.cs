using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsOnline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["login"] != null)
                return View();
            else
                return Redirect("~/User/Signup");
        }


      
        public ActionResult Home1()
        {
            if (Session["login1"] != null)
                return View("Index");
            else
                return Redirect("~/User/Login");
        }

        public ActionResult Signup()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Specials()
        {
            return View();
        }

        //public RedirectToRouteResult Specials()
        //{
        //    return RedirectToAction("Sepcials","Home");
        //}

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult View1()
        {
            return View();
        }

      
    }
}
