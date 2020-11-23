using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Contatos.Models;
using Contatos.Context;

namespace Contatos.Controllers
{
    public class TelefonesController : Controller
    {
        private readonly TelefoneContext _context;

        public TelefonesController(TelefoneContext context)
        {
            _context = context;
        }

        // GET: Telefones
        public async Task<IActionResult> Index(int? id)
        {
            EntradaContrato entrada = new EntradaContrato();
            var retorno = await _context.ListarTelefone();
            if (id.HasValue && id != 0)
            {

                retorno =  retorno.Where(x => x.IdContato == id).ToList();
                ViewBag.IdContato = id;


            }


            entrada.ListarTelefones =  retorno.Where(x => x.Contato.FlAtivo == true).ToList();


            return PartialView(entrada);
        }


     

        // POST: Telefones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public async Task<IActionResult> Create(Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                telefone.FlAtivo = true;

               await _context.Adicionar(telefone);

            }

            return Json(new { telefone.IdContato });
        }

        // GET: Telefones/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
          
            var Tel = await _context.ListarTelefone(id);
            if (Tel == null)
            {
                return NotFound();
            }
            ViewBag.IdEmail = id;
            ViewBag.IdContato = Tel.IdContato;

            return PartialView(Tel);
        }

     
        [HttpPost]
       
        public async Task<IActionResult> Edit( Telefone telefone)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    telefone.FlAtivo = true;
                  await  _context.Atualizar(telefone);
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }

            }
            return Json(new { telefone.IdContato });
        }

        // POST: Telefones/Delete/5
        [HttpPost, ActionName("Delete")]
       
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contato = await _context.ListarTelefone(id);
            contato.FlAtivo = false;

            await _context.Atualizar(contato);

            return Json(new { contato.IdContato });
        }

    }
}
