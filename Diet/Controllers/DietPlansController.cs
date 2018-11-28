using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Diet.Models;
using Nutritionix;
using Json;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;

namespace Diet.Controllers
{
    public class DietPlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private const string myApiId = "33b34225";
        private const string myApiKey = "c9a2e6a2b61c0ada42aed49f7b72c3d3";

        // GET: DietPlans
        public ActionResult Index()
        {
            NutritionixSearchResult("Chocolate");
            //return View(db.DietPlan.ToList());
            var dietPlan = db.DietPlan.ToList();
            return View(dietPlan);
        }

        // GET: DietPlans/Details/5
        //public ActionResult Details()
        //{
        //    //if (id == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}
        //    //DietPlan dietPlan = db.DietPlan.Find(id);
        //    //if (dietPlan == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    //return View(dietPlan);
        //    var currentPlan = User.Identity.GetUserId();
        //    var dietP = db.DietPlan.Where(d => d.)

        //}

        // GET: DietPlans/Create
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CalorieLimit,PotentialFood,Food,Calories,MaxCal,MinCal")] DietPlan dietPlan)
        {

            if (ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();
                dietPlan.ApplicationUserId = currentUserId;
                db.DietPlan.Add(dietPlan);
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            ViewBag.nutrionalKey = ApiKeys.nutritionKey;
            return View(dietPlan);
        }

        // GET: DietPlans/Edit/5
        public ActionResult Edit(int id)
        {
            DietPlan plan = db.DietPlan.Find(id);
            return View(plan);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CalorieLimit,PotentialFood,Food,Calories,MaxCal,MinCal")] DietPlan dietPlan)
        {
            dietPlan.ApplicationUserId = User.Identity.GetUserId();
            var editPlan = db.DietPlan.Where(p => p.ApplicationUserId == dietPlan.ApplicationUserId).SingleOrDefault();
            editPlan.CalorieLimit = dietPlan.CalorieLimit;
            editPlan.Calories = dietPlan.Calories;
            editPlan.PotentialFood = dietPlan.PotentialFood;
            editPlan.Food = dietPlan.Food;
            editPlan.MaxCal = dietPlan.MaxCal;
            editPlan.MinCal = dietPlan.MinCal;
            db.SaveChanges();
            return RedirectToAction("Details");
        }

        // GET: DietPlans/Delete/5
        public ActionResult Delete(string id)
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

        //Make the counter
        //public int? CalorieCount(string Calories)
        //{
        //    var calorieCounter = db.DietPlan.Where(c => c.Calories == Calories).Select()

        //}


        //TEST NUTRITIONIX
        public SearchResult[] NutritionixSearchResult(string searchInput)
        {
            var nutritionix = new NutritionixClient();
            nutritionix.Initialize(myApiId, myApiKey);
            var request = new SearchRequest { Query = searchInput };
            SearchResponse response = nutritionix.SearchItems(request);
            return response.Results;
        }

        //public ActionResult NutritionixItemRetrieve(string id)
        //{
        //    var nutritionix = new NutritionixClient();
        //    nutritionix.Initialize(myApiId, myApiKey);

        //    return nutritionix.RetrieveItem(id);
        //}
        //TODO: Get the value of the results
        //Store the results into the viewbag for IndexNutri.cshtml page
        //ViewBag.SearchResults = myResults;

        ////Go to IndexNutri.cshtml View Search Results page
        //return View();
        public ActionResult IndexNutri()
        {
            return View();
        }
    }
}
