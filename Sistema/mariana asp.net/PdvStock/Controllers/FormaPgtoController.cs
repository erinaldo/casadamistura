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
    public class FormaPgtoController : BaseController
    {
        private DbPdvStock db = new DbPdvStock();

        // GET: FormaPgto
        public ActionResult Index()
        {
            return View(db.FormaPgto.ToList());
        }

        // GET: FormaPgto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaPgto formaPgto = db.FormaPgto.Find(id);
            if (formaPgto == null)
            {
                return HttpNotFound();
            }
            return View(formaPgto);
        }

        // GET: FormaPgto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormaPgto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,MaxParcela,JurosAcrescidos,DataCadastro")] FormaPgto formaPgto)
        {
            if (ModelState.IsValid)
            {
                //formaPgto.JurosAcrescidos = Convert.ToDouble(formaPgto.JurosAcrescidos.ToString().Replace(".", "").Replace(",", "."));
                formaPgto.DataCadastro = DateTime.Now;
                db.FormaPgto.Add(formaPgto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formaPgto);
        }

        // GET: FormaPgto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaPgto formaPgto = db.FormaPgto.Find(id);
            if (formaPgto == null)
            {
                return HttpNotFound();
            }
            return View(formaPgto);
        }

        // POST: FormaPgto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,MaxParcela,JurosAcrescidos,DataCadastro")] FormaPgto formaPgto)
        {
            if (ModelState.IsValid)
            {
                //formaPgto.JurosAcrescidos = Convert.ToDouble(formaPgto.JurosAcrescidos.ToString().Replace(",", "."));
                formaPgto.DataCadastro = DateTime.Now;
                db.Entry(formaPgto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formaPgto);
        }

        // GET: FormaPgto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaPgto formaPgto = db.FormaPgto.Find(id);
            if (formaPgto == null)
            {
                return HttpNotFound();
            }
            return View(formaPgto);
        }

        // POST: FormaPgto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormaPgto formaPgto = db.FormaPgto.Find(id);
            db.FormaPgto.Remove(formaPgto);
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
