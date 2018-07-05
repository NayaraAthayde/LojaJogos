using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LojaJogos.Dominio.Entidades;
using LojaJogos.Infra.Dados.Contexto;
using LojaJogos.Infra.Dados.Repositorios;

namespace LojaJogos.Web.Controllers
{
    public class CompraController : Controller
    {
        private CompraRepositorio _repositorio = new CompraRepositorio();

        // GET: Compra
        public ActionResult Index()
        {
            return View(_repositorio.BuscarTudo());
        }

        // GET: Compra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = _repositorio.BuscarPorId((int)id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: Compra/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Compra/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FormaPagamento")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Adicionar(compra);
                return RedirectToAction("Index");
            }

            return View(compra);
        }

        // GET: Compra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = _repositorio.BuscarPorId((int)id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compra/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FormaPagamento")] Compra compra)
        {
            Compra compraEditada = _repositorio.BuscarPorId(compra.Id);
            compraEditada.FormaPagamento = compra.FormaPagamento;
            compraEditada.Jogos = compra.Jogos;
            compraEditada.Cliente = compra.Cliente;

            if (ModelState.IsValid)
            {
                _repositorio.Editar(compraEditada);
                return RedirectToAction("Index");
            }
            return View(compra);
        }

        // GET: Compra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = _repositorio.BuscarPorId((int)id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compra compra = _repositorio.BuscarPorId(id);
            _repositorio.Deletar(compra);
            return RedirectToAction("Index");
        }
    }
}
