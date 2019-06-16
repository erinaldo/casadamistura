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
    public class PdvItensController : BaseController
    {
        private DbPdvStock db = new DbPdvStock();

        // GET: PdvItens
        public ActionResult Index()
        {
            return View(db.PdvItens.ToList());
        }

        // GET: PdvItens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PdvItens pdvItens = db.PdvItens.Find(id);
            if (pdvItens == null)
            {
                return HttpNotFound();
            }
            return View(pdvItens);
        }

        // GET: PdvItens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PdvItens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Comissao,Quantidade,ValorUnitario,SubTotal,DataCadastro")] PdvItens pdvItens)
        {
            if (ModelState.IsValid)
            {
                db.PdvItens.Add(pdvItens);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pdvItens);
        }

        // GET: PdvItens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PdvItens pdvItens = db.PdvItens.Find(id);
            if (pdvItens == null)
            {
                return HttpNotFound();
            }
            return View(pdvItens);
        }

        // POST: PdvItens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Comissao,Quantidade,ValorUnitario,SubTotal,DataCadastro")] PdvItens pdvItens)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pdvItens).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pdvItens);
        }

        // GET: PdvItens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PdvItens pdvItens = db.PdvItens.Find(id);
            if (pdvItens == null)
            {
                return HttpNotFound();
            }
            return View(pdvItens);
        }

        // POST: PdvItens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PdvItens pdvItens = db.PdvItens.Find(id);
            db.PdvItens.Remove(pdvItens);
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
