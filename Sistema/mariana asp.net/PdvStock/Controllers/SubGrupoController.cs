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
    public class SubGrupoController : BaseController
    {
        private DbPdvStock db = new DbPdvStock();

        // GET: SubGrupo
        public ActionResult Index()
        {
            var subGrupo = db.SubGrupo.Include(s => s.Grupo);
            return View(subGrupo.ToList());
        }

        // GET: SubGrupo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubGrupo subGrupo = db.SubGrupo.Find(id);
            if (subGrupo == null)
            {
                return HttpNotFound();
            }
            return View(subGrupo);
        }

        public ActionResult _AddSubGrupo()
        {
            ViewBag.GrupoId = new SelectList(db.Grupo, "Id", "Nome");
            return View();
        }

        public ActionResult GetComboSubGrupo()
        {
            var qforn = db.SubGrupo.Select(c => new { c.Id, c.Nome }).OrderBy(c => c.Nome);
            return Json(ViewBag.SubGrupoId = new SelectList(qforn.AsEnumerable(), "Id", "Nome"), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult CreateAjax([Bind(Include = "Id,Nome,Informacoes,DataCadastro,GrupoId")] SubGrupo subGrupo)
        {
            if (ModelState.IsValid)
            {
                subGrupo.DataCadastro = DateTime.Now;
                db.SubGrupo.Add(subGrupo);
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                string messages = string.Join("\n", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                return Json(messages, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: SubGrupo/Create
        public ActionResult Create()
        {
            ViewBag.GrupoId = new SelectList(db.Grupo, "Id", "Nome");
            return View();
        }

        // POST: SubGrupo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Informacoes,DataCadastro,GrupoId")] SubGrupo subGrupo)
        {
            if (ModelState.IsValid)
            {
                subGrupo.DataCadastro = DateTime.Now;
                db.SubGrupo.Add(subGrupo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GrupoId = new SelectList(db.Grupo, "Id", "Nome", subGrupo.GrupoId);
            return View(subGrupo);
        }

        // GET: SubGrupo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubGrupo subGrupo = db.SubGrupo.Find(id);
            if (subGrupo == null)
            {
                return HttpNotFound();
            }
            ViewBag.GrupoId = new SelectList(db.Grupo, "Id", "Nome", subGrupo.GrupoId);
            return View(subGrupo);
        }

        // POST: SubGrupo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Informacoes,DataCadastro,GrupoId")] SubGrupo subGrupo)
        {
            if (ModelState.IsValid)
            {
                subGrupo.DataCadastro = DateTime.Now;
                db.Entry(subGrupo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GrupoId = new SelectList(db.Grupo, "Id", "Nome", subGrupo.GrupoId);
            return View(subGrupo);
        }

        // GET: SubGrupo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubGrupo subGrupo = db.SubGrupo.Find(id);
            if (subGrupo == null)
            {
                return HttpNotFound();
            }
            return View(subGrupo);
        }

        // POST: SubGrupo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubGrupo subGrupo = db.SubGrupo.Find(id);
            db.SubGrupo.Remove(subGrupo);
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
