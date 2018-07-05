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
    public class JogoController : Controller
    {
        private JogoRepositorio _repositorio = new JogoRepositorio();

        // GET: Jogos
        public ActionResult Index()
        {
            return View(_repositorio.BuscarTudo());
        }

        // GET: Jogos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = _repositorio.BuscarPorId((int)id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(jogo);
        }

        // GET: Jogos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jogos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,DataLancamento,Plataforma,Preco")] Jogo jogo)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Adicionar(jogo);
                return RedirectToAction("Index");
            }

            return View(jogo);
        }

        // GET: Jogos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = _repositorio.BuscarPorId((int)id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(jogo);
        }

        // POST: Jogos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,DataLancamento,Plataforma,Preco")] Jogo jogo)
        {
            Jogo jogoEditado = _repositorio.BuscarPorId(jogo.Id);
            jogoEditado.Nome = jogo.Nome;
            jogoEditado.Plataforma = jogo.Plataforma;
            jogoEditado.Preco = jogo.Preco;
            if (ModelState.IsValid)
            {
                _repositorio.Editar(jogoEditado);
                return RedirectToAction("Index");
            }
            return View(jogo);
        }

        // GET: Jogos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = _repositorio.BuscarPorId((int)id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(jogo);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jogo jogo = _repositorio.BuscarPorId(id);
            _repositorio.Deletar(jogo);
            return RedirectToAction("Index");
        }
    }
}
