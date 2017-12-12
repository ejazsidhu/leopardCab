using LepardCab.Models;
using LepardCab.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LepardCab.Controllers
{
    public class DriverController : Controller
    {
        private LaperdCabDbContaxt db;
        public DriverController()
        {
            db = new LaperdCabDbContaxt();
        }
        // GET: Driver
        public ActionResult Index()
        {
            var driver = db.Drivers.ToList();
            return View(driver);
        }

        // GET: Driver/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Driver/Create
        public ActionResult Create()
        {
            if (Session["login"] == null)
            {
                TempData["NoUser"] = "You are not authorised for this route";
                return RedirectToAction("index", "User");
            }
            else
            {
                return View();

            }
        }

        // POST: Driver/Create
        [HttpPost]
        public ActionResult Create(DriverDTO dto)
        {
            var driver = new Driver();

            driver.Contact = dto.Contact;
            driver.CNIC = dto.CNIC;
            driver.Email = dto.Email;
            driver.Address = dto.Address;
            driver.Name = dto.Name;
            driver.LicenseNumber = dto.LicenseNumber;
            driver.CabNumber = dto.CabNumber;

            try
            {
                db.Drivers.Add(driver);
                db.SaveChanges();
                if (driver.Id != 0)
                {
                    TempData["UserMessages"] = "Driver Succesfully Created.";
                    return RedirectToAction("Index", "driver");


                }
                else
                {
                    TempData["error"] = "Driver Succesfully Created." + "Error Message" ;
                    return RedirectToAction("Create", "Driver");

                }
            }
            catch(Exception e)
            {
                TempData["error"] = "Driver Succesfully Created."+"Error Message"+e;

            }
            return RedirectToAction("Create", "Driver");

        }

        // GET: Driver/Edit/5
        public ActionResult Edit(int id)
        {
            var driver = db.Drivers.First(d=>d.Id==id);
            return View(driver);
        }

        // POST: Driver/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Driver dto)
        {

            var driver = db.Drivers.Find(id);

            
            try
            {
                driver.Contact = dto.Contact;
                driver.CNIC = dto.CNIC;
                driver.Email = dto.Email;
                driver.Address = dto.Address;
                driver.Name = dto.Name;
                driver.LicenseNumber = dto.LicenseNumber;
                driver.CabNumber = dto.CabNumber;
                db.SaveChanges();

                TempData["UserMessages"] = "User is updated";

                return RedirectToAction("AllDrivers","Admin");
            }
            catch(Exception e)
            {
                TempData["error"] = "User is not saved Error Message: "+e;

                return RedirectToAction("AllDrivers", "Admin");
            }
        }

        // GET: Driver/Delete/5
        public ActionResult Delete(int id)
        {
            var driver = db.Drivers.Find(id);
            db.Drivers.Remove(driver);
            db.SaveChanges();


            TempData["UserMessages"] = "User is Deleted";

            return RedirectToAction("AllDrivers", "Admin");
        }

        // POST: Driver/Delete/5
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
