using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using RocketWorkflow.Models;
using RocketWorkflow.Models.ViewModels;

namespace RocketWorkflow.Controllers
{
    public class TasksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tasks
        public ActionResult Index()
        {
            MainViewModel TasksInfo = new MainViewModel()
            {
                TasksList = new List<Task>(),
                Task = new Task()
            };
            TasksInfo.TasksList = db.Tasks.ToList();
            
            return View(TasksInfo);
        }

        [ChildActionOnly]
        public virtual PartialViewResult ProjectTasks(int id)
        {
            MainViewModel TasksInfo = new MainViewModel()
            {
                TasksList = new List<Task>(),
                Task = new Task(),
                Job = new Job()
            };
            TasksInfo.TasksList = db.Tasks.Where(t => t.JobId == id).ToList();
            TasksInfo.Job = db.Jobs.Where(j => j.JobId == id).SingleOrDefault();

            return PartialView("_ProjectTasks", TasksInfo);
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: Tasks/Create
        public ActionResult Create(int id)
        {
            Task task = new Task();
            task.JobId = id;
            return View(task);
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaskId,JobId,Job,TaskName,AssignedEmployee,DueDate,CompleteTime,IsComplete")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();

                var id = task.JobId;
                return RedirectToAction("ProjectView", "Jobs", id);
            }

        
            return View(task);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaskId,AssignedEmployee,DueDate,CompleteTime,IsComplete")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Task task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
            db.SaveChanges();
            return RedirectToAction("ProjectView", "Jobs", task.JobId);
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
