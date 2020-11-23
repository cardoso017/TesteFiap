using Contatos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contatos.Context
{
    public class TelefoneContext : DbContext
    {
        readonly DataContext _dataContext;

        public TelefoneContext(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Adicionar(Telefone telefone)
        {
            _dataContext.Telefone.Add(telefone);
            await _dataContext.SaveChangesAsync();
        }



       
        public async Task<List<Telefone>> ListarTelefone()
        {
            return await _dataContext.Telefone.Include(e => e.Contato).Where(x => x.FlAtivo == true).ToListAsync();
        }

        public async Task<Telefone> ListarTelefone(int id)
        {
            return await _dataContext.Telefone.FindAsync(id);


        }

        public async Task Atualizar(Telefone telefone)
        {
            _dataContext.Telefone.Update(telefone);
            await _dataContext.SaveChangesAsync();
        }

    }
}
