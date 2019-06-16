using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PdvStock;
using PdvStock.Models;

namespace PdvStock.Controllers
{
    public class PdvPagamentoController : BaseController
    {
        private DbPdvStock db = new DbPdvStock();

        // GET: PdvPagamento
        public ActionResult Index()
        {
            var pdvPagamento = db.PdvPagamento.Include(p => p.FormaPgto);
            return View(pdvPagamento.ToList());
        }

        // GET: PdvPagamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PdvPagamento pdvPagamento = db.PdvPagamento.Find(id);
            if (pdvPagamento == null)
            {
                return HttpNotFound();
            }
            return View(pdvPagamento);
        }

        // GET: PdvPagamento/Create
        public ActionResult Create()
        {
            ViewBag.FormaPgtoId = new SelectList(db.FormaPgto, "Id", "Nome",1);
            return View();
        }

        // POST: PdvPagamento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FormaPgtoId,DataCadastro,Valor,Parcelado,QtdeParcela")] PdvPagamento pdvPagamento)
        {
            if (ModelState.IsValid)
            {
                db.PdvPagamento.Add(pdvPagamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FormaPgtoId = new SelectList(db.FormaPgto, "Id", "Nome", pdvPagamento.FormaPgtoId);
            return View(pdvPagamento);
        }

        // GET: PdvPagamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PdvPagamento pdvPagamento = db.PdvPagamento.Find(id);
            if (pdvPagamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormaPgtoId = new SelectList(db.FormaPgto, "Id", "Nome", pdvPagamento.FormaPgtoId);
            return View(pdvPagamento);
        }

        // POST: PdvPagamento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FormaPgtoId,DataCadastro,Valor,Parcelado,QtdeParcela")] PdvPagamento pdvPagamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pdvPagamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FormaPgtoId = new SelectList(db.FormaPgto, "Id", "Nome", pdvPagamento.FormaPgtoId);
            return View(pdvPagamento);
        }

        // GET: PdvPagamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PdvPagamento pdvPagamento = db.PdvPagamento.Find(id);
            if (pdvPagamento == null)
            {
                return HttpNotFound();
            }
            return View(pdvPagamento);
        }

        // POST: PdvPagamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PdvPagamento pdvPagamento = db.PdvPagamento.Find(id);
            db.PdvPagamento.Remove(pdvPagamento);
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
