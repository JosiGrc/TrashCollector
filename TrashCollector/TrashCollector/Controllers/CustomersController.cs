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
    public class CustomersController : Controller
        //Variables
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //ctor

        //methods

        // GET: Customers
        public ActionResult Index()
        {
            var customerUserId = User.Identity.GetUserId();
            var customerInfo = db.Customers.Where(c => c.ApplicationId.ToString() == customerUserId);
            return View(customerInfo);
        }

        // GET: Customers/Details/5
        public ActionResult Details()
        {
            var customerId = User.Identity.GetUserId();
            var customerDetails = db.Customers.Where(c => c.ApplicationId.ToString() == customerId).SingleOrDefault();
            return View(customerDetails);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,firstName,lastName,address,zipcode,state,email,pickUpdate,suspendPickup,additionalPickup")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.ApplicationId = User.Identity.GetUserId();
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,firstName,lastName,address,zipcode,state,email,pickUpdate,suspendPickup,additionalPickup,ApplicationId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PickupEditing()
        {
            var customerId = User.Identity.GetUserId();
            var customerDetails = db.Customers.Where(c => c.ApplicationId.ToString() == customerId).SingleOrDefault();
            return RedirectToAction("Edit");
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
