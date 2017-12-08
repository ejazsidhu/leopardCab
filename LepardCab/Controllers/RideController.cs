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
            return View();
        }

        // POST: Ride/Create
        [HttpPost]
        public ActionResult Create(FormCollection ride)
        {

            var r = new Ride();
            //r.DriverId = ride.DriverId;
            
            try
            {
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
