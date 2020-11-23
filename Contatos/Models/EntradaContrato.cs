using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contatos.Models
{
    public class EntradaContrato
    {
        public int? Id { get; set; }

        public Contato Contato { get; set; }

        public List<Telefone> ListarTelefones { get; set; }

        public Telefone Telefone { get; set; }

        public Emails emails { get; set; }


        public List<Emails> ListarEmails { get; set; }



    }
}
