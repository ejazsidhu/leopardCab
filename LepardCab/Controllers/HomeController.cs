using LepardCab.Models;
using LepardCab.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LepardCab.Controllers
{
    public class HomeController : Controller
    {
        private LaperdCabDbContaxt db;
        public HomeController()
        {
            db = new LaperdCabDbContaxt();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Ride(FormCollection form)
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

        public ActionResult FareCalculater()
        {
            //var drivers = db.Drivers.ToList();
            //var viewModel = new RideViewModel
            //{
            //    Ride = new Ride(),
            //    DriverList = drivers
            //};
            return View();
            
        }

        [HttpPost]
        public ActionResult FareCalculater(Ride ride)
        {
            return View();
        }
    }
}