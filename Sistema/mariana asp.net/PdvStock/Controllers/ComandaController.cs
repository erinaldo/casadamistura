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
    public class ComandaController : BaseController
    {
        private DbPdvStock db = new DbPdvStock();

        // GET: Comanda
        public ActionResult Index()
        {
            var comanda = db.Comanda.Include(c => c.Produtos).Include(c => c.Usuario);
            return View(comanda.ToList());
        }

        // GET: Comanda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comanda comanda = db.Comanda.Find(id);
            if (comanda == null)
            {
                return HttpNotFound();
            }
            return View(comanda);
        }

        public ActionResult Stations()
        {
            ViewBag.ProdutosId = new SelectList(db.Produtos, "Id", "CodBarras");
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Stations([Bind(Include = "Id,CodigoBarrasComanda,UsuarioId,ProdutosId,Quantidade,DataCadastro")] Comanda comanda)
        {
            
            if (ModelState.IsValid)
            {
                comanda.DataCadastro = DateTime.Now;
                db.Comanda.Add(comanda);
                if (db.SaveChanges() > 0)
                {
                    TempData["SuccessMsg"] = "DADOS INSERIDOS NA COMANDA";
                }
                else
                {
                    TempData["ErrorMsg"] = "OCORREU UM ERRO AO CADASTRAR POR FAVOR CONTATE O ADMINISTRADOR DO SISTEMA";
                }
                
            }

            ViewBag.ProdutosId = new SelectList(db.Produtos, "Id", "CodBarras", comanda.ProdutosId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Id", comanda.UsuarioId);
            return View(comanda);
        }

        public ActionResult Create()
        {
            ViewBag.ProdutosId = new SelectList(db.Produtos, "Id", "CodBarras");
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome");
            return View();
        }

        // POST: Comanda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodigoBarrasComanda,UsuarioId,ProdutosId,Quantidade,DataCadastro")] Comanda comanda)
        {
            if (ModelState.IsValid)
            {
                comanda.DataCadastro = DateTime.Now;
                db.Comanda.Add(comanda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdutosId = new SelectList(db.Produtos, "Id", "CodBarras", comanda.ProdutosId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome", comanda.UsuarioId);
            return View(comanda);
        }

        // GET: Comanda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comanda comanda = db.Comanda.Find(id);
            if (comanda == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdutosId = new SelectList(db.Produtos, "Id", "CodBarras", comanda.ProdutosId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome", comanda.UsuarioId);
            return View(comanda);
        }

        // POST: Comanda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodigoBarrasComanda,UsuarioId,ProdutosId,Quantidade,DataCadastro")] Comanda comanda)
        {
            if (ModelState.IsValid)
            {
                comanda.DataCadastro = DateTime.Now;
                db.Entry(comanda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdutosId = new SelectList(db.Produtos, "Id", "CodBarras", comanda.ProdutosId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome", comanda.UsuarioId);
            return View(comanda);
        }

        // GET: Comanda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comanda comanda = db.Comanda.Find(id);
            if (comanda == null)
            {
                return HttpNotFound();
            }
            return View(comanda);
        }

        // POST: Comanda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comanda comanda = db.Comanda.Find(id);
            db.Comanda.Remove(comanda);
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
