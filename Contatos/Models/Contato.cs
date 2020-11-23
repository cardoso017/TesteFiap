using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contatos.Models
{
    public class Contato
    {
        [Key]
        public int IdContato { get; set; }

        [Required(ErrorMessage = "O nome é obrigatorio  ser informado.!")]
        [Display(Name = "Nome")]
        [StringLength(50)]
        public string? Nome { get; set; }

        [Required]
        public Boolean FlAtivo { get; set; }


        public ICollection<Emails> Emails { get; set; }


        public ICollection<Telefone> Telefones { get; set; }
    }

}
