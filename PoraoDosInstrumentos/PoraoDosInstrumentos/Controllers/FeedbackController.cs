using PoraoDosInstrumentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PoraoDosInstrumentos.Controllers
{

    public class FeedbackController : Controller
    {
        AnuncioDBContext db;
        public FeedbackController()
        {
            db = new AnuncioDBContext();
        }
        // GET: FeedBack
        public ActionResult Index()
        {
            return View(db.Feedbacks.ToList());
        }
        public ActionResult Create()
        {
            FeedbackViewModels model = new FeedbackViewModels();
            model.Respondas = Geral.GetRespostas();
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Create(FeedbackViewModels model)
        {
            if (ModelState.IsValid)
            {
                db.Feedbacks.Add(new FeedBack() { Responda = model.Select, Comente = model.Comente, Email = model.Email, Nome = model.Nome });
                await db.SaveChangesAsync();
                return RedirectToAction("index");
            }
            model.Respondas = Geral.GetRespostas();
            return View(model);
        }
        // GET: Anuncio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedBack Feedback = db.Feedbacks.Find(id);
            if (Feedback == null)
            {
                return HttpNotFound();
            }
            return View(Feedback);
        }

        // POST: Feed/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FeedBack Feedback = db.Feedbacks.Find(id);
            db.Feedbacks.Remove(Feedback); 
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Anuncio/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedBack feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }
    }
}