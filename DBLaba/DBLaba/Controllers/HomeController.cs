using DbWarehouse.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DbWarehouse.Controllers
{
    public class HomeController : Controller
    {
       WarehouseContext db = new WarehouseContext();

        public ActionResult Index()
        {

            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}