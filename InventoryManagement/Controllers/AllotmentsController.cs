using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryManagement.DAL;
using InventoryManagement.Models;

namespace InventoryManagement.Controllers
{   [Authorize]
    public class AllotmentsController : Controller
    {
        private InventoryManagementContext db = new InventoryManagementContext();

        // GET: Allotments
        public ActionResult Index()
        {
            var allotments = db.Allotments.Include(a => a.Employee).Include(a => a.Item);
            return View(allotments.ToList());
        }

        // GET: Allotments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allotment allotment = db.Allotments.Find(id);
            if (allotment == null)
            {
                return HttpNotFound();
            }
            return View(allotment);
        }

        // GET: Allotments/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Title");
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName");
            return View();
        }

        // POST: Allotments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AllotmentID,EmployeeID,ItemID,Quantity,UpdateDateTime,UpdatedBy")] Allotment allotment)
        {
            if (ModelState.IsValid)
            {
                db.Allotments.Add(allotment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Title", allotment.EmployeeID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName", allotment.ItemID);
            return View(allotment);
        }

        // GET: Allotments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allotment allotment = db.Allotments.Find(id);
            if (allotment == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Title", allotment.EmployeeID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName", allotment.ItemID);
            return View(allotment);
        }

        // POST: Allotments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AllotmentID,EmployeeID,ItemID,Quantity,UpdateDateTime,UpdatedBy")] Allotment allotment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allotment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Title", allotment.EmployeeID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName", allotment.ItemID);
            return View(allotment);
        }

        // GET: Allotments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Allotment allotment = db.Allotments.Find(id);
            if (allotment == null)
            {
                return HttpNotFound();
            }
            return View(allotment);
        }

        // POST: Allotments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Allotment allotment = db.Allotments.Find(id);
            db.Allotments.Remove(allotment);
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
