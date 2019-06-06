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
{   [Authorize(Roles ="Admin")]
    public class PurchasesController : Controller
    {
        private InventoryManagementContext db = new InventoryManagementContext();

        // GET: Purchases
        public ActionResult Index()
        {
            var purchases = db.Purchases.Include(p => p.Item);
            return View(purchases.ToList());
        }

        // GET: Purchases/Details/5
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

        // GET: Purchases/Create
        public ActionResult Create()
        {
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName");
            return View();
        }

        // POST: Purchases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchaseID,ItemID,Price,Quantity,UpdateDateTime,UpdateBy")] Purchase purchase)
        {
            purchase.UpdateDateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Purchases.Add(purchase);
                

                int itemId = 0;

                itemId = purchase.ItemID;

                var quantity1 = db.Items.Where(i => i.ItemID == itemId).Select(i => i.Quantity).FirstOrDefault();
                int quantiy2 = purchase.Quantity;
                var total = quantity1 + quantiy2;
                Item item = db.Items.Where(i => i.ItemID == itemId).FirstOrDefault();
                item.Quantity = total;
                db.Entry(item).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName", purchase.ItemID);
                
                
                //var total = int.Parse(quantity1) + quantiy2;

            return View(purchase);
        }

        // GET: Purchases/Edit/5
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
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName", purchase.ItemID);
            return View(purchase);
        }

        // POST: Purchases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseID,ItemID,Price,Quantity,UpdateDateTime,UpdateBy")] Purchase purchase)
        {
            purchase.UpdateDateTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(purchase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName", purchase.ItemID);
            return View(purchase);
        }

        // GET: Purchases/Delete/5
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

        // POST: Purchases/Delete/5
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
