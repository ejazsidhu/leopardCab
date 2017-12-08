using LepardCab.Models;
using LepardCab.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LepardCab.Controllers
{
    public class RentController : Controller
    {
        private LaperdCabDbContaxt db;
        public RentController()
        {
            db = new LaperdCabDbContaxt();
        }
        // GET: Rent
        public ActionResult Index()
        {
            var rents = db.Rents.ToList();
            return View(rents);
        }

        // GET: Rent/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rent/Create
        [HttpPost]
        public ActionResult Create(RentDTO dto)
        {
            var rent = new Rent();
            rent.Contact = dto.Contact;
            rent.Car = dto.Car;
            rent.Fare = dto.RentTime * 500;
            rent.RentTime = dto.RentTime;
            try
            {

                db.Rents.Add(rent);
                db.SaveChanges();
                if (rent.Id != 0)
                {
                    TempData["UserMessages"] = "You reqyuestn is forwar you will be contacted soon.";
                    //Session["loginUser"] = user;
                    return RedirectToAction("Index", "home");


                }
                else
                {
                    TempData["error"] = "Rent a car request not confirmed. Try again" + "Error Message";
                    return RedirectToAction("Create", "Rent");

                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Rent/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View();
        }

        // POST: Rent/Edit/5
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

        // GET: Rent/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rent/Delete/5
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
