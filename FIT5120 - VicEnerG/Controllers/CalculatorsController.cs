using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5120___VicEnerG.Models;

namespace FIT5120___VicEnerG.Controllers
{
    public class CalculatorsController : Controller
    {
        private VicEnerG_ModelContainer db = new VicEnerG_ModelContainer();

        // GET: Calculators
        public ActionResult Index()
        {
            return View(db.CalculatorSet.ToList());
        }

        // GET: Calculators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calculator calculator = db.CalculatorSet.Find(id);
            if (calculator == null)
            {
                return HttpNotFound();
            }
            return View(calculator);
        }

        // GET: Calculators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Calculators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,address,area,efficiency,energy,performanceRatio,radiation,systemSize")] Calculator calculator)
        {
            if (ModelState.IsValid)
            {
                db.CalculatorSet.Add(calculator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(calculator);
        }

        // GET: Calculators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calculator calculator = db.CalculatorSet.Find(id);
            if (calculator == null)
            {
                return HttpNotFound();
            }
            return View(calculator);
        }

        // POST: Calculators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,address,area,efficiency,energy,performanceRatio,radiation,systemSize")] Calculator calculator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calculator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calculator);
        }

        // GET: Calculators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calculator calculator = db.CalculatorSet.Find(id);
            if (calculator == null)
            {
                return HttpNotFound();
            }
            return View(calculator);
        }

        // POST: Calculators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calculator calculator = db.CalculatorSet.Find(id);
            db.CalculatorSet.Remove(calculator);
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
