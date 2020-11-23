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
    public class ContatosController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ContatoContext _contextCont;
        private readonly TelefoneContext _contextTel;
        private readonly emailContext _contextEmail;
        public ContatosController(ContatoContext context, TelefoneContext tel, emailContext Email)
        {
            _contextCont = context;
            _contextEmail = Email;
            _contextTel = tel;
        }

        // GET: Contatoes
        public async Task<IActionResult> Index(Consulta Contato)
        {
       
           if (Contato.Nome == null)
            Contato.contatos = await _contextCont.Listar();
           else
                Contato.contatos = await _contextCont.BuscarNome(Contato.Nome);

            return View(Contato);
           
        }

    

        // POST: Contatoes/Create

        [HttpPost]

        public async Task<IActionResult> Create(EntradaContrato entrada)
        {


            if (ModelState.IsValid)
            {

                entrada.Contato.FlAtivo = true;
                await _contextCont.Adicionar(entrada.Contato);
                ViewBag.IdContato = entrada.Contato.IdContato;


            }

           
            return Json(new { entrada.Contato.IdContato });
        }

        public IActionResult Create()
        {
            return View();
        }





        // GET: Contatoes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
           

            var contato = await _contextCont.ListarId(id);
            if (contato == null)
            {
                return NotFound();
            }
            ViewBag.IdContato = contato.IdContato; 
            return View(contato);
        }


        [HttpPost]
       
        public async Task<IActionResult> Edit( Contato contato)
        {
        

            if (ModelState.IsValid)
            {
                try
                {
                    contato.FlAtivo = true;
                 await  _contextCont.Atualizar(contato);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                  
                        throw;
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

      
        // POST: Contatoes/Delete/5
        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contato = await _contextCont.ListarId(id);
            contato.FlAtivo = false;

            await _contextCont.Atualizar(contato);
   
            return RedirectToAction(nameof(Index));
        }

        //private bool ContatoExists(int id)
        //{
        //    return _context.Contato.Any(e => e.IdContato == id);
        //}
    }
}
