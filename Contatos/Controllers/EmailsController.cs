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
    public class EmailsController : Controller
    {
        private readonly emailContext _context;
    

        public EmailsController(emailContext context)
        {
            _context = context;
        }

        // GET: Emails
        public async Task<IActionResult> Index(int? id)
        {
            EntradaContrato entrada = new EntradaContrato();


             entrada.ListarEmails = await _context.ListarEmail();
            if (id.HasValue && id != 0)
            { 
                entrada.ListarEmails = entrada.ListarEmails.Where(x => x.IdContato == id).ToList();
                ViewBag.IdContato = id;


            }


            entrada.ListarEmails.Where(x => x.Contato.FlAtivo == true).ToList();

            
                return PartialView(entrada);
          
           

            
        }


    
        // POST: Emails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public async Task<IActionResult> Create(Emails emails)
        {
            if (ModelState.IsValid)
            {
                emails.FlAtivo = true;

               await _context.Adicionar(emails);
            }
            
            return  Json(new { emails.IdContato });
        }

        // GET: Emails/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var emails = await _context.ListarEmail(id);
            if (emails == null)
            {
                return NotFound();
            }
            ViewBag.IdEmail = id;
            ViewBag.IdContato = emails.IdContato;

            return PartialView(emails);
        }

        // POST: Emails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public async Task<IActionResult> Edit(Emails emails)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    emails.FlAtivo = true;
                  await  _context.Atualizar(emails);
          
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }

            }
            return Json(new { emails.IdContato });

        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emails = await _context.ListarEmail(id);
            emails.FlAtivo = false;

            await _context.Atualizar(emails);

            return Json(new { emails.IdContato });
        }


        public async Task<IActionResult> Editar(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emails = await _context.ListarEmail(id);
            if (emails == null)
            {
                return NotFound();
            }
            
            return View(emails);
        }

        public async Task<IActionResult> ListaEmail(int? id)
        {
            EntradaContrato entrada = new EntradaContrato();


            entrada.ListarEmails = await _context.ListarEmail();
            if (id.HasValue && id != 0)
            {
                entrada.ListarEmails = entrada.ListarEmails.Where(x => x.IdContato == id).ToList();
                ViewBag.IdContato = id;


            }


            entrada.ListarEmails.Where(x => x.Contato.FlAtivo == true).ToList();


            return View(entrada);
        }
        }
}
