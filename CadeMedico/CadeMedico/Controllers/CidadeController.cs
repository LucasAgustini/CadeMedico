using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CadeMedico.Controllers
{
    public class CidadeController : Controller
    {
        // GET: Cidade
        CadeMedicoEntities db = new CadeMedicoEntities();

        // GET: Especialidade
        public ActionResult Index()
        {

            var cidade = db.Cidades.ToList();

            return View(cidade);
        }

        public ActionResult Adicionar()
        {
            ViewBag.IDcidade = new SelectList(db.Cidades,
                "IDcidade", "Nome");

            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Cidades cidade)
        {
            if (ModelState.IsValid)
            {
                db.Cidades.Add(cidade);
                db.SaveChanges();
                return RedirectToAction("/Index");
            }
            ViewBag.IDcidade = new SelectList(db.Cidades, "IDcidade", "Nome");

            return View(cidade);
        }

        public ActionResult Editar(int? id) //tipo de dado da chave primaria id //passar todos os campos por parametro
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidades cidade = db.Cidades.Find(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }

            return View(cidade);
        }

        [HttpPost]
        public ActionResult Editar(Cidades cidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cidade);
        }

        public ActionResult Excluir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidades cidade = db.Cidades.Find(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }


        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(int id)
        {
            Cidades cidade = db.Cidades.Find(id);
            db.Cidades.Remove(cidade);
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
