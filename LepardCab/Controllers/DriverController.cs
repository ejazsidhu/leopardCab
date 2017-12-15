using LepardCab.Models;
using LepardCab.Models.DTOs;
using LepardCab.ViewModels;
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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginDTO login)
        {
            var login_details = db.Drivers.ToList();
            if (login_details != null)
            {
                foreach (var item in login_details)
                {
                    
                    if (login.Contact.Equals(item.Contact) && login.Password.Equals(item.CNIC))
                    {
                        var user = db.Drivers.SingleOrDefault(u => u.Id == item.Id);
                        if (user != null)
                        {
                            Session["loginDriver"] = user;
                            return RedirectToAction("MyJobs", "Driver");
                            
                        }

                    }
                    else
                    {
                        TempData["NoUser"] = "User Does not Exist";
                    }


                }

            }
                return RedirectToAction("index", "User");

            


        }

        public ActionResult MyJobs()
        {
            var driver = Session["loginDriver"] as Driver;
            var jobs = db.Rides.Where(r => r.DriverId == driver.Id).ToList();
            return View(jobs);
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



        public ActionResult FeedBack(int id)
        {
            var ride = db.Rides.Where(r => r.Id == id).FirstOrDefault();
            var viewModel = new FeedBackViewModel
            {
                Ride = ride,
                FeedBack = new Feedback()

            };

            return View(viewModel);
        }

        // POST: Ride/Edit/5
        [HttpPost]
        public ActionResult FeedBack(FormCollection fb)
        {
            var user = Session["loginDriver"] as Driver;
            var rideId = Int32.Parse(fb["Ride.Id"]);
            var ride = db.Rides.Where(r => r.Id == rideId).FirstOrDefault();
            ride.Status = "Completed";
            var feedBack = new Feedback();
            feedBack.DriverId = user.Id;
            feedBack.Feedback1 = fb["FeedBack.FeedBack1"];
            db.Feedbacks.Add(feedBack);
            db.SaveChanges();
            TempData["UserMessages"] = "Thanks for your valuable Feedback!";
            return RedirectToAction("Index", "Home");
        }

        // GET: Ride/Delete/5
        public ActionResult FeedBackDelete(int id)
        {
            var ride = db.Rides.Where(r => r.Id == id).FirstOrDefault();
            var viewModel = new FeedBackViewModel
            {
                Ride = ride,
                FeedBack = new Feedback()

            };
            return View(viewModel);
        }

        // POST: Ride/Delete/5
        [HttpPost]
        public ActionResult FeedBackDelete(FormCollection fb)
        {
            var user = Session["loginDriver"] as Driver;
            var rideId = Int32.Parse(fb["Ride.Id"]);
            var ride = db.Rides.Where(r => r.Id == rideId).FirstOrDefault();
            ride.Status = "Cancled";
            var feedBack = new Feedback();
            feedBack.DriverId = user.Id;
            feedBack.Feedback1 = fb["FeedBack.FeedBack1"];
            db.Feedbacks.Add(feedBack);
            db.SaveChanges();
            TempData["UserMessages"] = "Thanks for your valuable Feedback!";
            return RedirectToAction("Index", "Home");
        }

    }
}
