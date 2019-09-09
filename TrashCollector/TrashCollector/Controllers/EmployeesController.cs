using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeesController : Controller
    {
        //Variables
        private ApplicationDbContext db = new ApplicationDbContext();

        //ctor

        //Methods

        // GET: Employees
        public ActionResult Index()
        {
            var employeeUserId = User.Identity.GetUserId();
            var employeeInfo = db.Employees.Where(c => c.ApplicationId.ToString() == employeeUserId);
            return View(employeeInfo);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,firstName,lastName,zipcode,ApplicationId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.ApplicationId = User.Identity.GetUserId();
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,firstName,lastName,zipcode,ApplicationId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ConfirmPickup(Customer customer)
        {
            var gettingPickups = false;
            var pickupConfirmed = db.Customers.Where(c => c.Id == customer.Id).SingleOrDefault();
            gettingPickups = true;
            ChargingCustomer(true, customer.Id);
            return View("Pickups");
        }

        public void ChargingCustomer(bool? gettingPickups, int? id)
        {
            if (gettingPickups == true)
            {
                Customer customer = db.Customers.Find(id);
                customer.balance += 50.55;
                db.SaveChanges();
            }
            // return RedirectToAction("PickUps");
        }

        public ActionResult PickUps(int? id)
        {
            Employee employee = db.Employees.Find(id);
            employee = db.Employees.Where(e => e.Id == employee.Id).Single();
            List<Customer> customersInArea = db.Customers.Where(c => c.zipcode == employee.zipcode).ToList();//add a day to the filter
            return View (customersInArea);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
