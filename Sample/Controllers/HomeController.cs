using Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample.Controllers
{
    public class HomeController : Controller
    { 
         
        public ActionResult Index()
        {
            ViewBag.FirstName = "Narendra";
            ViewBag.SecondName = "Dusari";
            ViewBag.Address = "near water plant veerammacolony,konadmodu";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        
       
    }
}