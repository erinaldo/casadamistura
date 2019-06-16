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
    public class FornecedorController : BaseController
    {
        private DbPdvStock db = new DbPdvStock();

        // GET: Fornecedor
        public ActionResult Index()
        {
            return View(db.Fornecedor.ToList());
        }

        // GET: Fornecedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = db.Fornecedor.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // GET: Fornecedor/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult _AddFornecedor()
        {
            return View();
        }

        public ActionResult GetComboFornecedor()
        {
            var qforn = db.Fornecedor.Select(c => new { c.Id, c.Nome }).OrderBy(c => c.Nome);
            return Json(ViewBag.FornecedoresId = new SelectList(qforn.AsEnumerable(), "Id", "Nome"), JsonRequestBehavior.AllowGet);
        }
        // POST: Fornecedor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult CreateAjax([Bind(Include = "Id,Nome,Cpf,Cnpj,Status,Cep,Endereco,Numero,Complemento,Bairro,Cidade,UF,Telefone,Celular,Email,DataCadastro")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                fornecedor.Status = fornecedor.Status == 0 ? Fornecedor.StatusEnum.Ativo : fornecedor.Status;
                fornecedor.DataCadastro = DateTime.Now;
                db.Fornecedor.Add(fornecedor);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Cpf,Cnpj,Status,Cep,Endereco,Numero,Complemento,Bairro,Cidade,UF,Telefone,Celular,Email,DataCadastro")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                fornecedor.DataCadastro = DateTime.Now;
                db.Fornecedor.Add(fornecedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fornecedor);
        }

        // GET: Fornecedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = db.Fornecedor.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Cpf,Cnpj,Status,Cep,Endereco,Numero,Complemento,Bairro,Cidade,UF,Telefone,Celular,Email,DataCadastro")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                fornecedor.DataCadastro = DateTime.Now;
                db.Entry(fornecedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fornecedor);
        }

        // GET: Fornecedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = db.Fornecedor.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fornecedor fornecedor = db.Fornecedor.Find(id);
            db.Fornecedor.Remove(fornecedor);
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
