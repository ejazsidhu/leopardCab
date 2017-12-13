using LepardCab.Models;
using LepardCab.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LepardCab.Controllers
{
    public class RideController : Controller
    {
        private LaperdCabDbContaxt db;
        public RideController()
        {
            db = new LaperdCabDbContaxt();
        }
        // GET: Ride
        public ActionResult Index()
        {
            var drivers = db.Drivers.ToList();
            var viewModel = new RideViewModel
            {
                Ride = new Ride(),
                DriverList = drivers
            };
            return View(viewModel);
        }

        // GET: Ride/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ride/Create
        public ActionResult Create()
        {
            var user = new User();
            if (Session["loginUser"] == null)
            {
                TempData["error"] = "PleaseLogin first";
                return RedirectToAction("index", "Home");
            }
            else
            {
                user = Session["loginUSer"] as User;
                var userInDb = db.Users.First(u => u.Id == user.Id);
                var drivers = db.Drivers.ToList();
                var viewModel = new RideViewModel
                {
                    Ride = new Ride(),
                    DriverList=drivers
                };
                return View(viewModel);

            }


        }

        // POST: Ride/Create
        [HttpPost]
        public ActionResult CreateRide(FormCollection ride)
        {
            User user = Session["loginUser"] as User;
            var userInDb = db.Users.First(u => u.Id == user.Id);

            var start = ride["Ride.RideStart"];
            var end = ride["Ride.RideEnd"];
            var fare = ride["Ride.Fare"];
            var driver = ride["Ride.DriverId"];


            var r = new Ride();
          
            
            try
            {
                r.UserId = userInDb.Id;
                r.DriverId = Int32.Parse(driver);
                r.RideStart = start;
                r.RideEnd = end;
                r.Fare = Convert.ToDecimal(fare);
                r.Date = DateTime.Now;
                db.Rides.Add(r);
                db.SaveChanges();

                TempData["UserMessages"] = "Rider is register";
                

                return RedirectToAction("Index","Home");
            }
            catch
            {
                TempData["error"] = "Rider is register";


                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult MyRides()
        {
            if (Session["loginUser"] != null)
            {
                var user = Session["loginUser"] as User;
                var rides = db.Rides.Where(o=>o.UserId==user.Id).ToList();
                return View(rides);

            }
            else
            {
                return RedirectToAction("Index","Home");

            }
        }

        // GET: Ride/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ride/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ride/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ride/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
