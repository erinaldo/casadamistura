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
    public class PdvSangriaSuprimentoController : BaseController
    {
        private DbPdvStock db = new DbPdvStock();

        // GET: PdvSangriaSuprimento
        public ActionResult Index()
        {
            return View(db.PdvSangriaSuprimento.ToList());
        }

        // GET: PdvSangriaSuprimento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PdvSangriaSuprimento pdvSangriaSuprimento = db.PdvSangriaSuprimento.Find(id);
            if (pdvSangriaSuprimento == null)
            {
                return HttpNotFound();
            }
            return View(pdvSangriaSuprimento);
        }

        // GET: PdvSangriaSuprimento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PdvSangriaSuprimento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ValorUnitario,TipoSangSup,DataCadastro")] PdvSangriaSuprimento pdvSangriaSuprimento)
        {
            if (ModelState.IsValid)
            {
                db.PdvSangriaSuprimento.Add(pdvSangriaSuprimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pdvSangriaSuprimento);
        }

        // GET: PdvSangriaSuprimento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PdvSangriaSuprimento pdvSangriaSuprimento = db.PdvSangriaSuprimento.Find(id);
            if (pdvSangriaSuprimento == null)
            {
                return HttpNotFound();
            }
            return View(pdvSangriaSuprimento);
        }

        // POST: PdvSangriaSuprimento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ValorUnitario,TipoSangSup,DataCadastro")] PdvSangriaSuprimento pdvSangriaSuprimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pdvSangriaSuprimento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pdvSangriaSuprimento);
        }

        // GET: PdvSangriaSuprimento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PdvSangriaSuprimento pdvSangriaSuprimento = db.PdvSangriaSuprimento.Find(id);
            if (pdvSangriaSuprimento == null)
            {
                return HttpNotFound();
            }
            return View(pdvSangriaSuprimento);
        }

        // POST: PdvSangriaSuprimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PdvSangriaSuprimento pdvSangriaSuprimento = db.PdvSangriaSuprimento.Find(id);
            db.PdvSangriaSuprimento.Remove(pdvSangriaSuprimento);
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
