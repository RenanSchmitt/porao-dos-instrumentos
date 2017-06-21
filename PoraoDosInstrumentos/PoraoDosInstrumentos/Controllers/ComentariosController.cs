using PoraoDosInstrumentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoraoDosInstrumentos.Controllers
{
    public class ComentariosController : Controller
    {
        AnuncioDBContext db = new AnuncioDBContext();
        // GET: Comentarios
        public ActionResult ListarComentarios(int id)
        {
            var lista = db.Comentarios.Where(m => m.Informacoes.ID == id);
            ViewBag.Informacao = id;
            return PartialView(lista);
        }

        public ActionResult SalvarComentario(string assunto, int idInformacao)
        {
            var comentario = new Comentario()
            {
                Assunto = assunto,
                Informacoes = db.Informacoes.Find(idInformacao)
            };
            db.Comentarios.Add(comentario);
            db.SaveChanges();
            return Json(new { Resultado = comentario.ID }, JsonRequestBehavior.AllowGet);
        }
        

    }

}