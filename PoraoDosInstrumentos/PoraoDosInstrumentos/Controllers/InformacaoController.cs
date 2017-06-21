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
    public class InformacaoController : Controller
    {
        private AnuncioDBContext db = new AnuncioDBContext();

        // GET: Informacao
        public ActionResult Index()
        {
            return View(db.Informacoes.ToList());
        }

        // GET: Informacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Informacao informacao = db.Informacoes.Find(id);
            if (informacao == null)
            {
                return HttpNotFound();
            }
            return View(informacao);
        }

        // GET: Informacao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Informacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "ID,Data,Nome,Email")] */Informacao informacao)
        {
            if (ModelState.IsValid)
            {
                db.Informacoes.Add(informacao);
                db.SaveChanges();
                
            }

            return Json(new { Resultado = informacao.ID }, JsonRequestBehavior.AllowGet);
        }

        // GET: Informacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Informacao informacao = db.Informacoes.Find(id);
            if (informacao == null)
            {
                return HttpNotFound();
            }
            return View(informacao);
        }

        // POST: Informacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Data,Nome,Email")] Informacao informacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(informacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(informacao);
        }

        // GET: Informacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Informacao informacao = db.Informacoes.Find(id);
            if (informacao == null)
            {
                return HttpNotFound();
            }
            return View(informacao);
        }

        // POST: Informacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Informacao informacao = db.Informacoes.Find(id);
            db.Informacoes.Remove(informacao);
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
