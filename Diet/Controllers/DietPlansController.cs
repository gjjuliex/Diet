﻿using System;
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
    public class DietPlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DietPlans
        public ActionResult Index()
        {
            return View(db.DietPlan.ToList());
        }

        // GET: DietPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DietPlan dietPlan = db.DietPlan.Find(id);
            if (dietPlan == null)
            {
                return HttpNotFound();
            }
            return View(dietPlan);
        }

        // GET: DietPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DietPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CalorieLimit,PotentialFood,Food,Calories,MaxCal,MinCal")] DietPlan dietPlan)
        {
            if (ModelState.IsValid)
            {
                db.DietPlan.Add(dietPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dietPlan);
        }

        // GET: DietPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DietPlan dietPlan = db.DietPlan.Find(id);
            if (dietPlan == null)
            {
                return HttpNotFound();
            }
            return View(dietPlan);
        }

        // POST: DietPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CalorieLimit,PotentialFood,Food,Calories,MaxCal,MinCal")] DietPlan dietPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dietPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dietPlan);
        }

        // GET: DietPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DietPlan dietPlan = db.DietPlan.Find(id);
            if (dietPlan == null)
            {
                return HttpNotFound();
            }
            return View(dietPlan);
        }

        // POST: DietPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DietPlan dietPlan = db.DietPlan.Find(id);
            db.DietPlan.Remove(dietPlan);
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