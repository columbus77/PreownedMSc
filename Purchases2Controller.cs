using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PreOwned268.Models;
using PagedList;
using PagedList.Mvc;

namespace PreOwned268.Controllers
{
    public class Purchases2Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Purchases2
        public ActionResult Index(string searchBy, string search, int? Page)
        {
            var purchases = db.Purchases.Include(p => p.Cust).Include(p => p.Trans);
            if (searchBy == "Cust.FName")
            {
                //var purchases = db.Purchases.Include(p => p.Cust).Include(p => p.Trans);
                return View(db.Purchases.Where(x => x.Cust.FName == search || search == null).ToList().ToPagedList(Page ?? 1, 4));
            }
            else
            {
                return View(db.Purchases.Where(x => x.Staff.FirstName.StartsWith(search) || search == null).ToList().ToPagedList(Page ?? 1, 4)); ;
            }
        }

        // GET: Purchases2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // GET: Purchases2/Create
        public ActionResult Create()
        {
            ViewBag.CustID = new SelectList(db.Custs, "CustID", "FName");
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "FirstName");
            ViewBag.TransId = new SelectList(db.trans, "TransId", "Make");
            return View();
        }

        // POST: Purchases2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchaseID,StaffId,CustID,TransId,Date,Cost,Quantity,VAT")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Purchases.Add(purchase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustID = new SelectList(db.Custs, "CustID", "FName", purchase.CustID);
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "FirstName", purchase.StaffId);
            ViewBag.TransId = new SelectList(db.trans, "TransId", "Make", purchase.TransId);
            return View(purchase);
        }

        // GET: Purchases2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustID = new SelectList(db.Custs, "CustID", "FName", purchase.CustID);
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "FirstName", purchase.StaffId);
            ViewBag.TransId = new SelectList(db.trans, "TransId", "Make", purchase.TransId);
            return View(purchase);
        }

        // POST: Purchases2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseID,StaffId,CustID,TransId,Date,Cost,Quantity,VAT")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustID = new SelectList(db.Custs, "CustID", "FName", purchase.CustID);
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "FirstName", purchase.StaffId);
            ViewBag.TransId = new SelectList(db.trans, "TransId", "Make", purchase.TransId);
            return View(purchase);
        }

        // GET: Purchases2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // POST: Purchases2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Purchase purchase = db.Purchases.Find(id);
            db.Purchases.Remove(purchase);
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
