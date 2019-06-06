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
using Microsoft.AspNet.Identity;

namespace InventoryManagement.Controllers
{   [Authorize]
    public class RequestsController : Controller
    {
        private InventoryManagementContext db = new InventoryManagementContext();

        // GET: Requests
        public ActionResult Index()
        {
            var requests = db.Requests.Include(r => r.Employee).Include(r => r.Item);
            ViewBag.Alert = TempData["Alert"];
            return View(requests.ToList());
        }

        // GET: Requests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // GET: Requests/Create
        public ActionResult Create()
        {
           
            
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName","LastName");

            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName");
             
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestID,EmployeeID,ItemID,Quantity,UpdateDateTime,UpdatedBy")] Request request)
        {
            var userid = User.Identity.GetUserName();
            var employeeid = db.Employees.Where(i => i.Email == userid).Select(i => i.EmployeeID).FirstOrDefault();
            request.EmployeeID = employeeid;
            request.UpdateDateTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", request.Employee.Firstname);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName", request.ItemID);
            return View(request);
        }

        // GET: Requests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Title", request.EmployeeID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName", request.ItemID);
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestID,EmployeeID,ItemID,Quantity,UpdateDateTime,UpdatedBy")] Request request)
        {
            request.UpdateDateTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "Title", request.EmployeeID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName", request.ItemID);
            return View(request);
        }

        // GET: Requests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Request request = db.Requests.Find(id);
            db.Requests.Remove(request);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Allotment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
           
            return View(request);
        }

        [HttpPost]
        public ActionResult Allotment([Bind(Include = "RequestID,EmployeeID,ItemID,Quantity,UpdateDateTime,UpdatedBy")] Request request)
        {
            Request query = db.Requests.Find(request.RequestID);

            Allotment allotment= new Allotment();
            allotment.EmployeeID = query.EmployeeID;
            allotment.ItemID = query.ItemID;
            allotment.Quantity = query.Quantity;
            allotment.UpdateDateTime = DateTime.Now;
            allotment.UpdatedBy = query.EmployeeID;
            if (ModelState.IsValid)
            {
               
                var quantity = db.Items.Where(i => i.ItemID == allotment.ItemID).Select(i => i.Quantity).FirstOrDefault();
                int quantity2 = allotment.Quantity;
                if (quantity >= quantity2)
                {
                   

                    db.Allotments.Add(allotment);

                    int total = quantity - quantity2;
                    Item item = db.Items.Where(i => i.ItemID == allotment.ItemID).FirstOrDefault();
                    item.Quantity = total;
                    db.Entry(item).State = EntityState.Modified;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Alert"] = "The required amount of supplies are not available";
                    return RedirectToAction("Index");

                }
                
            }
            return View(request);
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
