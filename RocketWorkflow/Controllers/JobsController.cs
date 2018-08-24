using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RocketWorkflow.Models;
using RocketWorkflow.Models.ViewModels;

namespace RocketWorkflow.Controllers
{
    public class JobsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jobs
        public ActionResult Index()
        {
            MainViewModel JobInfo = new MainViewModel()
            { 
                JobsList = new List<Job>(),
            };
            JobInfo.JobsList = db.Jobs.ToList();
        
            return View(JobInfo);
        }

        public ActionResult ProjectView(int? id)
        {
            var job = db.Jobs.Where(j => j.JobId == id).SingleOrDefault();
            return View(job);
        }
        
        // GET: Jobs/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        //public List<Client> FormatClientNames()
        //{

        //    List<Client> ClientsList = new List<Client>();
        //    foreach (var client in db.Clients)
        //    {
        //        var name = (client.FirstName + " " + client.LastName);
        //        client.FullName = name;
        //        ClientsList.Add(client);
        //    }
        //    return ClientsList;
        //}

        //public List<Client> ClientsList()
        //{
        //    List<Client> ClientsList = new List<Client>();
        //    foreach (var client in db.Clients)
        //    {
        //    ClientsList.Add(client);
        //    }
        //    return ClientsList;
        //}

        //public List<string> ClientNamesList()
        //{
        //    List<string> ClientNamesList = new List<string>();
        //    foreach (var client in db.Clients)
        //    {
        //        ClientNamesList.Add(client.FullName);
        //    }
        //    return ClientNamesList;
        //}



        // GET: Jobs/Create
        public ActionResult Create()
        {
           
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobId,JobName,AssignedEmployee,DueDate,CompleteTime,Fee,IsComplete,IsArchived,BillingComplete,,ClientId")] Job job)
        {
            if (ModelState.IsValid)
            {
                
                db.Jobs.Add(job);
                try
                { 
                db.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
                return RedirectToAction("Index");
            }

            return View(job);
            //ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "ApplicationUserId", job.ClientId);
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", job.ClientId);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobId,ClientId,JobName,AssignedEmployee,DueDate,CompleteTime,Fee,IsComplete,IsArchived,BillingComplete,SomeProp")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "ApplicationUserId", job.ClientId);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
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
