using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity; //para rodar expressoes lambdas e delegados
using System.Net;

namespace CadeMedico.Controllers
{
    public class CadeMedicoController : Controller
    {

        private CadeMedicoEntities db = new CadeMedicoEntities();
        // GET: CadeMedico
        public ActionResult Index()
        {
            var medico = db.Medicos.Include(m => m.Cidades)
                .Include(m => m.Especialidades).ToList();

            return View(medico);
        }

        public ActionResult Adicionar()
        {
            ViewBag.IDcidade = new SelectList(db.Cidades, "IDcidade", "Nome"); //adiciona em outra tabela
            ViewBag.IDespecialidade = new SelectList(db.Especialidades, 
                "IDespecialidade", "Nome");

            return View ();
        }
        [HttpPost]
        public ActionResult Adicionar(Medicos medico)
        {
            if (ModelState.IsValid)
            {
                db.Medicos.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDcidade = new SelectList(db.Cidades, "IDcidade", "Nome", medico.IDcidade); //adiciona em outra tabela
            ViewBag.IDespecialidade = new SelectList(db.Especialidades,
                "IDespecialidade", "Nome", medico.IDespecialidade);

            return View(medico);

        }

        public ActionResult Editar(int? id) //tipo de dado da chave primaria id //passar todos os campos por parametro
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicos medico = db.Medicos.Find(id);
            if(medico == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.IDcidade = new SelectList(db.Cidades, "IDcidade", "Nome", medico.IDcidade);
            ViewBag.IDespecialidade = new SelectList(db.Especialidades, "IDespecialidade", "Nome", medico.IDespecialidade);

            return View(medico);
        }

        [HttpPost]
        public ActionResult Editar(Medicos medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDcidade = new SelectList(db.Cidades, "IDcidade", "Nome", medico.IDcidade); //adiciona em outra tabela
            ViewBag.IDespecialidade = new SelectList(db.Especialidades,
                "IDespecialidade", "Nome", medico.IDespecialidade);

            return View(medico);
        }

        public ActionResult Excluir(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicos medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(int id)
        {
            Medicos medico = db.Medicos.Find(id);
            db.Medicos.Remove(medico);
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