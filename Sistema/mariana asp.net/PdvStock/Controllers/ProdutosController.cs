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
using System.IO;

namespace PdvStock.Controllers
{
    public class ProdutosController : BaseController
    {
        private DbPdvStock db = new DbPdvStock();

        // GET: Produtos
        public ActionResult Index()
        {
            var produtos = db.Produtos.Include(p => p.Fornecedor).Include(p => p.SubGrupo);
            return View(produtos.ToList());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtos produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
                return HttpNotFound();
            }
            return View(produtos);
        }

        public ActionResult _SearchProductPdv()
        {
            var produtos = db.Produtos.Include(p => p.Fornecedor).Include(p => p.SubGrupo);
            return View(produtos.ToList());
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.FornecedorId = new SelectList(db.Fornecedor, "Id", "Nome");
            ViewBag.SubGrupoId = new SelectList(db.SubGrupo, "Id", "Nome");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodBarras,Nome,Descricao,DataCadastro,FornecedorId,SubGrupoId,Peso,PrecoCusto,PrecoVenda,Lucro,DescontoMaximo,Status,QuantidadeEstocada,QuantidadeMinima,QuantidadeMaxima,Foto")] Produtos produtos)
        {
            if (ModelState.IsValid)
            {
                string[] alowextension = new string[] { "image/gif", "image/jpeg", "image/jpg", "image/png" };
                var uploadDir = "~/UploadPhoto";
                var imgprincipal = Request.Files["Fotoupload"];
                if (imgprincipal != null && imgprincipal.ContentLength > 0 && alowextension.Contains(imgprincipal.ContentType))
                {
                    var extension = Path.GetExtension(imgprincipal.FileName);
                    var imagename = DateTime.Now.ToShortDateString().Replace("/", "") + DateTime.Now.ToShortTimeString().Replace(":", "") + extension;
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), imagename);
                    var imageUrl = Path.Combine(uploadDir, imagename);
                    imgprincipal.SaveAs(imagePath);
                    produtos.Foto = imageUrl;
                }
                produtos.DataCadastro = DateTime.Now;
                db.Produtos.Add(produtos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FornecedorId = new SelectList(db.Fornecedor, "Id", "Nome", produtos.FornecedorId);
            ViewBag.SubGrupoId = new SelectList(db.SubGrupo, "Id", "Nome", produtos.SubGrupoId);
            return View(produtos);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtos produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
                return HttpNotFound();
            }
            ViewBag.FornecedorId = new SelectList(db.Fornecedor, "Id", "Nome", produtos.FornecedorId);
            ViewBag.SubGrupoId = new SelectList(db.SubGrupo, "Id", "Nome", produtos.SubGrupoId);
            return View(produtos);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodBarras,Nome,Descricao,DataCadastro,FornecedorId,SubGrupoId,Peso,PrecoCusto,PrecoVenda,Lucro,DescontoMaximo,Status,QuantidadeEstocada,QuantidadeMinima,QuantidadeMaxima,Foto")] Produtos produtos)
        {
            if (ModelState.IsValid)
            {
                produtos.DataCadastro = DateTime.Now;
                string[] alowextension = new string[] { "image/gif", "image/jpeg", "image/jpg", "image/png" };
                var uploadDir = "~/UploadPhoto";
                var imgprincipal = Request.Files["Fotoupload"];
                if (imgprincipal != null && imgprincipal.ContentLength > 0 && alowextension.Contains(imgprincipal.ContentType))
                {
                    var extension = Path.GetExtension(imgprincipal.FileName);
                    var imagename = DateTime.Now.ToShortDateString().Replace("/", "") + DateTime.Now.ToShortTimeString().Replace(":", "") + extension;
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), imagename);
                    var imageUrl = Path.Combine(uploadDir, imagename);
                    imgprincipal.SaveAs(imagePath);
                    produtos.Foto = imageUrl;
                }

                db.Entry(produtos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FornecedorId = new SelectList(db.Fornecedor, "Id", "Nome", produtos.FornecedorId);
            ViewBag.SubGrupoId = new SelectList(db.SubGrupo, "Id", "Nome", produtos.SubGrupoId);
            return View(produtos);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtos produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
                return HttpNotFound();
            }
            return View(produtos);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produtos produtos = db.Produtos.Find(id);
            db.Produtos.Remove(produtos);
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
