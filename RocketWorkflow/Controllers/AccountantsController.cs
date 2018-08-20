using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RocketWorkflow.Models;

namespace RocketWorkflow.Controllers
{
    public class AccountantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Accountants
        public ActionResult Index()
        {
            return View(db.Accountants.ToList());
        }

        // GET: Accountants/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accountant accountant = db.Accountants.Find(id);
            if (accountant == null)
            {
                return HttpNotFound();
            }
            return View(accountant);
        }

        // GET: Accountants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accountants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountantId,UserId,FirstName,LastName,Email,PhoneNumber,OfficeUserName")] Accountant accountant)
        {
            if (ModelState.IsValid)
            {
                db.Accountants.Add(accountant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accountant);
        }

        // GET: Accountants/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accountant accountant = db.Accountants.Find(id);
            if (accountant == null)
            {
                return HttpNotFound();
            }
            return View(accountant);
        }

        // POST: Accountants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountantId,UserId,FirstName,LastName,Email,PhoneNumber,OfficeUserName")] Accountant accountant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accountant);
        }

        // GET: Accountants/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accountant accountant = db.Accountants.Find(id);
            if (accountant == null)
            {
                return HttpNotFound();
            }
            return View(accountant);
        }

        // POST: Accountants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Accountant accountant = db.Accountants.Find(id);
            db.Accountants.Remove(accountant);
            db.SaveChanges();
            return RedirectToAction("Index");
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
