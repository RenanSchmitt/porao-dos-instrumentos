using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PoraoDosInstrumentos.Models;

namespace PoraoDosInstrumentos.Controllers
{
    public class StatusItemController : Controller
    {
        private AnuncioDBContext db = new AnuncioDBContext();

        // GET: StatusItem
        public ActionResult Index()
        {
            return View(db.StatusItems.ToList());
        }

        // GET: StatusItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusItem statusItem = db.StatusItems.Find(id);
            if (statusItem == null)
            {
                return HttpNotFound();
            }
            return View(statusItem);
        }

        // GET: StatusItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StatusItemID,status")] StatusItem statusItem)
        {
            if (ModelState.IsValid)
            {
                db.StatusItems.Add(statusItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statusItem);
        }

        // GET: StatusItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusItem statusItem = db.StatusItems.Find(id);
            if (statusItem == null)
            {
                return HttpNotFound();
            }
            return View(statusItem);
        }

        // POST: StatusItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatusItemID,status")] StatusItem statusItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusItem);
        }

        // GET: StatusItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusItem statusItem = db.StatusItems.Find(id);
            if (statusItem == null)
            {
                return HttpNotFound();
            }
            return View(statusItem);
        }

        // POST: StatusItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatusItem statusItem = db.StatusItems.Find(id);
            db.StatusItems.Remove(statusItem);
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
