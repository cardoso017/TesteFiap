using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contatos.Models
{
    public class Emails
    {
        [Key]
        public int IdEmail { get; set; }

        [Required(ErrorMessage = "O email obrigatorio ser informado.!"), EmailAddress(ErrorMessage = "O email não está no formato correto.!")]
        [Display(Name = "Email")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        public Boolean FlAtivo { get; set; }


        public int IdContato { get; set; }

        public virtual Contato Contato
        {
            get; set;
        }
    }
}
