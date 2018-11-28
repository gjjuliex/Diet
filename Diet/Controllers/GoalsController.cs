using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Diet.Models;

namespace Diet.Controllers
{
    public class GoalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Goals
        public ActionResult Index()
        {
            return View(db.Goals.ToList());
        }

        // GET: Goals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goals goals = db.Goals.Find(id);
            if (goals == null)
            {
                return HttpNotFound();
            }
            return View(goals);
        }

        // GET: Goals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Goals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GoalId,LittleGoals,Goal")] Goals goals)
        {
            if (ModelState.IsValid)
            {
                db.Goals.Add(goals);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(goals);
        }

        // GET: Goals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goals goals = db.Goals.Find(id);
            if (goals == null)
            {
                return HttpNotFound();
            }
            return View(goals);
        }

        // POST: Goals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GoalId,LittleGoals,Goal")] Goals goals)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goals).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(goals);
        }

        // GET: Goals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goals goals = db.Goals.Find(id);
            if (goals == null)
            {
                return HttpNotFound();
            }
            return View(goals);
        }

        // POST: Goals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Goals goals = db.Goals.Find(id);
            db.Goals.Remove(goals);
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
        
        public ActionResult Progress ()
        {
            return View();
        }
    }
}
