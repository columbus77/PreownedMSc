using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PreOwned268.Models;

namespace PreOwned268.Controllers
{
    public class PursController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Purs
        public ActionResult Index()
        {
            return View(db.Purs.ToList());
        }

        // GET: Purs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pur pur = db.Purs.Find(id);
            if (pur == null)
            {
                return HttpNotFound();
            }
            return View(pur);
        }

        // GET: Purs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Purs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurID,Date,Cost,Quantity,VAT")] Pur pur)
        {
            if (ModelState.IsValid)
            {
                db.Purs.Add(pur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pur);
        }

        // GET: Purs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pur pur = db.Purs.Find(id);
            if (pur == null)
            {
                return HttpNotFound();
            }
            return View(pur);
        }

        // POST: Purs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurID,Date,Cost,Quantity,VAT")] Pur pur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pur);
        }

        // GET: Purs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pur pur = db.Purs.Find(id);
            if (pur == null)
            {
                return HttpNotFound();
            }
            return View(pur);
        }

        // POST: Purs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pur pur = db.Purs.Find(id);
            db.Purs.Remove(pur);
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
