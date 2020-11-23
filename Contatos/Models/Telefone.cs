using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contatos.Models
{
    public class Telefone
    {
        [Key]
        public int IdTelefone { get; set; }

        [Required]
        [Display(Name = "Telefone")]
        [StringLength(50)]
        public string Numero { get; set; }

        [Required]
        public Boolean FlAtivo { get; set; }

        public int IdContato { get; set; }

        public virtual Contato Contato
        {
            get; set;
        }

    }
}
