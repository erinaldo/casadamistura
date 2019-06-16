using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PdvStock.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        
        [Required]
        public String Nome { get; set; }


        public String Cpf { get; set; }

        public String Cnpj { get; set; }

        public enum StatusUsuariosEnum
        {
            Ativo = 1,
            Inativo = 2,
        }

        [Display(Name = "Status")]
        [Required]
        public StatusUsuariosEnum Status { get; set; }

        [Required]
        public String Cep { get; set; }

        [Required]
        public String Endereco { get; set; }

        [Required]
        public String Numero { get; set; }

        public String Complemento { get; set; }

        public String Bairro { get; set; }

        public String Cidade { get; set; }

        public String UF { get; set; }

        public String Telefone { get; set; }

        [Required]
        public String Celular { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public String Email { get; set; }

        public DateTime? DataCadastro { get; set; }

        //public virtual Grupo Grupo { get; set; }
    }
}