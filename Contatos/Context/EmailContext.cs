using Contatos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace Contatos.Context
{
    public class emailContext : DbContext
    {
        readonly DataContext _dataContext;

        public emailContext(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Adicionar(Emails email)
        {
            _dataContext.Email.Add(email);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<Emails>> ListarEmail()
        {
            return await _dataContext.Email.Include(e => e.Contato).Where(x => x.FlAtivo == true).ToListAsync();
        }

        public async Task<Emails> ListarEmail(int id)
        {
            return await _dataContext.Email.FindAsync(id);


        }

        public async Task Atualizar(Emails email)
        {
            _dataContext.Email.Update(email);
            await _dataContext.SaveChangesAsync();
        }



    }
}
