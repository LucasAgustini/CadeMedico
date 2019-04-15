using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace CadeMedico.Controllers
{
    public class EspecialidadeController : Controller
    {
        CadeMedicoEntities db = new CadeMedicoEntities();
               
        // GET: Especialidade
        public ActionResult Index()
        {
            
            var espec = db.Especialidades.ToList();

            return View(espec);
        }

        public ActionResult Adicionar()
        {
            ViewBag.IDespecialidade = new SelectList(db.Especialidades,
                "IDespecialidade", "Nome");

            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Especialidades espec)
        {
            if (ModelState.IsValid)
            {
                db.Especialidades.Add(espec);
                db.SaveChanges();
                return RedirectToAction("/Index");
            }
            ViewBag.IDespecialidade = new SelectList(db.Especialidades, "IDespecialidade", "Nome");

            return View(espec);
        }

        public ActionResult Editar(int? id) //tipo de dado da chave primaria id //passar todos os campos por parametro
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidades espec = db.Especialidades.Find(id);
            if (espec == null)
            {
                return HttpNotFound();
            }

            return View(espec);
        }

        [HttpPost]
        public ActionResult Editar(Especialidades espec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(espec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(espec);
        }

        public ActionResult Excluir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidades espec = db.Especialidades.Find(id);
            if (espec == null)
            {
                return HttpNotFound();
            }
            return View(espec);
        }


        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(int id)
        {
            Especialidades espec = db.Especialidades.Find(id);
            db.Especialidades.Remove(espec);
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