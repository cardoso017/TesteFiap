using Contatos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contatos.Context
{
    public class ContatoContext : DbContext
    {
        readonly DataContext _dataContext;

        public ContatoContext(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Adicionar(Contato contato)
        {
            _dataContext.Contato.Add(contato);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<Contato>> Listar() {
          return await _dataContext.Contato.Where(x => x.FlAtivo == true).ToListAsync();
            }

        public async Task<List<Contato>> BuscarNome(string nome)
        {
            return await _dataContext.Contato.Where(x => x.FlAtivo == true && x.Nome == nome).ToListAsync();
        }

        public async Task<Contato> ListarId(int id)
        {
            return await _dataContext.Contato.FirstOrDefaultAsync(m => m.IdContato == id);
        }


        public async Task Atualizar(Contato contato)
        {
            _dataContext.Contato.Update(contato);
            await _dataContext.SaveChangesAsync();
        }




    }
}
