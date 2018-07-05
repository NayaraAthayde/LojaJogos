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
    public class ClienteController : Controller
    {

        private ClienteRepositorio _repositorio = new ClienteRepositorio();

        // GET: Cliente
        public ActionResult Index()
        {
            return View(_repositorio.BuscarTudo());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = _repositorio.BuscarPorId((int)id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Sobrenome,Endereco,Telefone")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Adicionar(cliente);
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = _repositorio.BuscarPorId((int)id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Sobrenome,Endereco,Telefone")] Cliente cliente)
        {
            Cliente clienteEditado = _repositorio.BuscarPorId(cliente.Id);
            clienteEditado.Nome = cliente.Nome;
            clienteEditado.Sobrenome = cliente.Sobrenome;
            clienteEditado.Telefone = cliente.Telefone;
            clienteEditado.Endereco.Bairro = cliente.Endereco.Bairro;
            clienteEditado.Endereco.Cep = cliente.Endereco.Cep;
            clienteEditado.Endereco.Cidade = cliente.Endereco.Cidade;
            clienteEditado.Endereco.Complemento = cliente.Endereco.Complemento;
            clienteEditado.Endereco.Estado = cliente.Endereco.Estado;
            clienteEditado.Endereco.Logradouro = cliente.Endereco.Logradouro;
            clienteEditado.Endereco.Numero = cliente.Endereco.Numero;

            if (ModelState.IsValid)
            {
                _repositorio.Editar(clienteEditado);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = _repositorio.BuscarPorId((int)id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = _repositorio.BuscarPorId(id);
            _repositorio.Deletar(cliente);
            return RedirectToAction("Index");
        }
    }
}
