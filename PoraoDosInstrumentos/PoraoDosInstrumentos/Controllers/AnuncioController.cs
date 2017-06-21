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
    public class AnuncioController : Controller
    {
        private AnuncioDBContext db = new AnuncioDBContext();

        public ActionResult Index(string searchString, string sortOrder, int? SelectedCategoria)
        {
            var anuncios = db.Anuncios.Include(a => a.Categoria).Include(a => a.Local).Include(a => a.Vendedor);

            if (!String.IsNullOrEmpty(searchString))
            {
                anuncios = anuncios.Where(s => s.Titulo.Contains(searchString) || s.Descricao.Contains(searchString));
            }

            ViewBag.ValorSortParm = sortOrder == "Valor" ? "valor_asc" : "Valor";

            switch (sortOrder)
            {
                case "Valor":
                    anuncios = anuncios.OrderByDescending(s => s.Valor);
                    break;
                case "rating_asc":
                    anuncios = anuncios.OrderBy(s => s.Valor);
                    break;
            }
            return View(anuncios.ToList());
        }
        public ActionResult AnuncioFilter(string term)
        {
            term = term.ToLower();
            var anuncios = from Anuncio in db.Anuncios
                           where (Anuncio.Titulo.ToLower().Contains(term))
                           select Anuncio.Titulo; return Json(anuncios, JsonRequestBehavior.AllowGet);
        }

        // GET: Anuncio/Details/5
        [Authorize]
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

        // GET: Anuncio/Comprar/5
        public ActionResult Comprar(int? id)
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
        [Authorize]
        public ActionResult Send(String message)
        {
            string emailTo = User.Identity.Name;

            SendEmail.CreateMailMessage(emailTo, "nova mensagem", message);
            return View();
        }

        // retorna a imagem associada a um produto
        public ActionResult GetImage(int id)
        {
            Anuncio anuncio = db.Anuncios.Find(id);
            if (anuncio != null && anuncio.ImageFile != null)
            {
                //File used to return a binary content and the contenttype of the returned photo
                return File(anuncio.ImageFile, anuncio.ImageMimeType);
            }
            else
            {
                return new FilePathResult("~/Images/nao-disponivel.jpg", "image/jpeg");
            }
        }

        // GET: Anuncio/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nome");
            ViewBag.LocalID = new SelectList(db.Locais, "LocalID", "Nome");
            ViewBag.VendedorID = new SelectList(db.Vendedores, "VendedorID", "ImageUrl");
            ViewBag.StatusItemID = new SelectList(db.StatusItems, "StatusItemID", "status");



            return View();
        }

        // POST: Anuncio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titulo,Descricao,Valor,ReleaseDate,ImageUrl,CategoriaID,LocalID,VendedorID,StatusItemID")] Anuncio anuncio,
                             HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {

                //if image object is not empty update the photo attribute, using image info.
                if (image != null)
                {
                    anuncio.ImageMimeType = image.ContentType;
                    anuncio.ImageFile = new byte[image.ContentLength];
                    //save the photo file by using image.InputStream.Read method.
                    image.InputStream.Read(anuncio.ImageFile, 0, image.ContentLength);
                }

                anuncio.usuario = User.Identity.Name;
                anuncio.StatusItemID = 1;
                db.Anuncios.Add(anuncio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nome", anuncio.CategoriaID);
            ViewBag.LocalID = new SelectList(db.Locais, "LocalID", "Nome", anuncio.LocalID);
            ViewBag.VendedorID = new SelectList(db.Vendedores, "VendedorID", "ImageUrl", anuncio.VendedorID);
            ViewBag.StatusItemID = new SelectList(db.StatusItems, "StatusItemID", "status", anuncio.StatusItemID);

            return View(anuncio);
        }

        // GET: Anuncio/Edit/5
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
            ViewBag.StatusItemID = new SelectList(db.StatusItems, "StatusItemID", "status", anuncio.StatusItemID);
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nome", anuncio.CategoriaID);
            ViewBag.LocalID = new SelectList(db.Locais, "LocalID", "Nome", anuncio.LocalID);
            ViewBag.VendedorID = new SelectList(db.Vendedores, "VendedorID", "ImageUrl", anuncio.VendedorID);
            return View(anuncio);
        }

        // POST: Anuncio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Titulo,Descricao,Valor,ReleaseDate,ImageUrl,CategoriaID,LocalID,VendedorID,StatusItemID")] Anuncio anuncio,
                                HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {

                //if image object is not empty update the photo attribute, using image info.
                if (image != null)
                {
                    anuncio.ImageMimeType = image.ContentType;
                    anuncio.ImageFile = new byte[image.ContentLength];
                    //save the photo file by using image.InputStream.Read method.
                    image.InputStream.Read(anuncio.ImageFile, 0, image.ContentLength);
                }
                anuncio.usuario = User.Identity.Name;
                anuncio.VendedorID = 1;
                db.Entry(anuncio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Nome", anuncio.CategoriaID);
            ViewBag.LocalID = new SelectList(db.Locais, "LocalID", "Nome", anuncio.LocalID);
            ViewBag.VendedorID = new SelectList(db.Vendedores, "VendedorID", "ImageUrl", anuncio.VendedorID);
            ViewBag.StatusItemID = new SelectList(db.StatusItems, "StatusItemID", "status", anuncio.StatusItemID);
            return View(anuncio);
        }

        // GET: Anuncio/Delete/5
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

        // POST: Anuncio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anuncio anuncio = db.Anuncios.Find(id);
            db.Anuncios.Remove(anuncio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: /Anuncio/CategoriaMenu 
        [ChildActionOnly]
        public ActionResult CategoriaMenu(int num = 5)
        {
            var categorias = db.Categorias.
                OrderByDescending(c => c.Anuncios.Count)
                .Take(num)
                .ToList();
            return this.PartialView(categorias);
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
