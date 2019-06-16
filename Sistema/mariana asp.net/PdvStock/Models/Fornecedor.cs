using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PdvStock.Models
{
    public class Fornecedor
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public String Nome { get; set; }


        public String Cpf { get; set; }

        public String Cnpj { get; set; }

        public enum StatusEnum
        {
            Ativo = 1,
            Inativo = 2,
        }

        [Display(Name = "Status")]
        [Required]
        public StatusEnum Status { get; set; }

        [Required]
        public String Cep { get; set; }

        [Required]
        [Display(Name = "Endereço")]
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
        [Display(Name = "E-mail")]
        public String Email { get; set; }

        [Display(Name="Data Cadastro")]
        public DateTime? DataCadastro { get; set; }

        [NotMapped]
        public virtual Produtos Produtos { get; set; }
    }
}