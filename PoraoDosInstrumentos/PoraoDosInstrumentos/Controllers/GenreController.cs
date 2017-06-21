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
    public class GenreController : Controller
    {
        private AnuncioDBContext db = new AnuncioDBContext();

        // GET: Genre
        public ActionResult Index()
        {
            var anuncios = db.Anuncios.Include(a => a.Categoria).Include(a => a.Local).Include(a => a.Vendedor);
            return View(anuncios.ToList());
        }

        // GET: Genre/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anuncio anuncio = db.Anuncios.Find(id);
            if (anuncio == null)
            {
                return HttpNotFound();
            }
            return View(anuncio);
        }

        // GET: Genre/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nome");
            ViewBag.LocalID = new SelectList(db.Locais, "LocalID", "Nome");
            ViewBag.VendedorID = new SelectList(db.Vendedores, "VendedorID", "ImageUrl");
            return View();
        }

        // POST: Genre/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titulo,Descricao,Valor,usuario,ReleaseDate,ImageFile,ImageMimeType,ImageUrl,CategoriaID,LocalID,VendedorID")] Anuncio anuncio)
        {
            if (ModelState.IsValid)
            {
                db.Anuncios.Add(anuncio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nome", anuncio.CategoriaID);
            ViewBag.LocalID = new SelectList(db.Locais, "LocalID", "Nome", anuncio.LocalID);
            ViewBag.VendedorID = new SelectList(db.Vendedores, "VendedorID", "ImageUrl", anuncio.VendedorID);
            return View(anuncio);
        }

        // GET: Genre/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anuncio anuncio = db.Anuncios.Find(id);
            if (anuncio == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nome", anuncio.CategoriaID);
            ViewBag.LocalID = new SelectList(db.Locais, "LocalID", "Nome", anuncio.LocalID);
            ViewBag.VendedorID = new SelectList(db.Vendedores, "VendedorID", "ImageUrl", anuncio.VendedorID);
            return View(anuncio);
        }

        // POST: Genre/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Titulo,Descricao,Valor,usuario,ReleaseDate,ImageFile,ImageMimeType,ImageUrl,CategoriaID,LocalID,VendedorID")] Anuncio anuncio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anuncio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nome", anuncio.CategoriaID);
            ViewBag.LocalID = new SelectList(db.Locais, "LocalID", "Nome", anuncio.LocalID);
            ViewBag.VendedorID = new SelectList(db.Vendedores, "VendedorID", "ImageUrl", anuncio.VendedorID);
            return View(anuncio);
        }

        // GET: Genre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anuncio anuncio = db.Anuncios.Find(id);
            if (anuncio == null)
            {
                return HttpNotFound();
            }
            return View(anuncio);
        }

        // POST: Genre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anuncio anuncio = db.Anuncios.Find(id);
            db.Anuncios.Remove(anuncio);
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
