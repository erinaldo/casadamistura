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
    public class PdvController : BaseController
    {
        private DbPdvStock db = new DbPdvStock();

        // GET: Pdv
        public ActionResult Index()
        {
            var pdv = db.Pdv.Include(p => p.Clientes);
            return View(pdv.ToList());
        }

        // GET: Pdv/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pdv pdv = db.Pdv.Find(id);
            if (pdv == null)
            {
                return HttpNotFound();
            }
            return View(pdv);
        }

        public JsonResult SearchProductAjax(string CodiBarras)
        {
            var produto = db.Produtos.Where(x => x.CodBarras==CodiBarras).FirstOrDefault();
            return Json((produto==null?null: produto), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateAjax(
            [Bind(Prefix = "FormaPgtoId[]")] int[] FormaPgtoId,
            [Bind(Prefix = "Valor[]")] double[] Valor,
            [Bind(Prefix = "QtdeParcela[]")] int[] QtdeParcela,
            [Bind(Prefix = "ProdutoId[]")] int[] ProdutoId,
            [Bind(Prefix = "Quantidade[]")] int[] Quantidade,
            [Bind(Prefix = "ValorUnitario[]")] double[] ValorUnitario,
            [Bind(Prefix = "Desconto[]")] double[] Desconto,
            [Bind(Prefix = "SubTotal[]")] double[] SubTotal,
            [Bind(Include = "Id,ClientesId,Cpf,ValorTotal,NumeroVenda,DataVenda")] Pdv pdv)
        {
            if (ModelState.IsValid)
            {

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        //SALVA PDV
                        pdv.Cpf = Request.Form["Cpf"].ToString();
                        pdv.ValorTotal = Convert.ToDouble(Request.Form["totalvenda"].ToString());
                        int max = db.Pdv.Where(p => p != null)
                                                .Select(p => p.Id)
                                                .DefaultIfEmpty()
                                                .Max();
                        pdv.NumeroVenda = max.ToString().PadLeft(10, '0');
                        pdv.DataVenda = DateTime.Now;
                        db.Pdv.Add(pdv);
                        db.SaveChanges();

                        /* ITENS  */
                        for (int i=0;i<=ProdutoId.Count()-1;i++)
                        {
                            PdvItens pdvitens = new PdvItens();
                            pdvitens.PdvId = pdv.Id;
                            pdvitens.ProdutosId = ProdutoId[i];
                            pdvitens.Quantidade = Quantidade[i];
                            pdvitens.ValorUnitario = ValorUnitario[i];
                            pdvitens.Desconto = Desconto[i];
                            pdvitens.SubTotal = SubTotal[i];
                            pdvitens.DataCadastro = DateTime.Now.ToString();
                            db.PdvItens.Add(pdvitens);
                            db.SaveChanges();
                        }

                        /* PAGAMENTO */
                        for (int j = 0; j <= FormaPgtoId.Count()-1; j++)
                        {
                            PdvPagamento pdvpagamento = new PdvPagamento();
                            pdvpagamento.PdvId = pdv.Id;
                            pdvpagamento.FormaPgtoId = FormaPgtoId[j];
                            pdvpagamento.DataCadastro = DateTime.Now;
                            pdvpagamento.Valor = Valor[j];
                            pdvpagamento.Parcelado = (QtdeParcela[j] > 0 ? 1 : 0);
                            pdvpagamento.QtdeParcela = QtdeParcela[j];
                            db.PdvPagamento.Add(pdvpagamento);
                            db.SaveChanges();
                        }
                        
                        transaction.Commit();
                        return Json(new { save = true, errormsg = "" }, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return Json(new { save = false, errormsg = ex.Message }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            else
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                string messages = string.Join("\n", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                return Json(new { save = false, errormsg = messages }, JsonRequestBehavior.AllowGet);
            }
            
        }
        // GET: Pdv/Create
        public ActionResult Create()
        {
            ViewBag.ClientesId = new SelectList(db.Clientes, "Id", "Nome");
            return View();
        }

        // POST: Pdv/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClientesId,Cpf,ValorTotal,NumeroVenda,DataVenda")] Pdv pdv)
        {
            if (ModelState.IsValid)
            {
                db.Pdv.Add(pdv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientesId = new SelectList(db.Clientes, "Id", "Nome", pdv.ClientesId);
            return View(pdv);
        }

        // GET: Pdv/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pdv pdv = db.Pdv.Find(id);
            if (pdv == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientesId = new SelectList(db.Clientes, "Id", "Nome", pdv.ClientesId);
            return View(pdv);
        }

        // POST: Pdv/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClientesId,Cpf,ValorTotal,NumeroVenda,DataVenda")] Pdv pdv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pdv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientesId = new SelectList(db.Clientes, "Id", "Nome", pdv.ClientesId);
            return View(pdv);
        }

        // GET: Pdv/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pdv pdv = db.Pdv.Find(id);
            if (pdv == null)
            {
                return HttpNotFound();
            }
            return View(pdv);
        }

        // POST: Pdv/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pdv pdv = db.Pdv.Find(id);
            db.Pdv.Remove(pdv);
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
