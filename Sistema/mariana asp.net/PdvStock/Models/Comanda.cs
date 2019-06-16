using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PdvStock.Models
{
    public class Comanda
    {
        public int Id { get; set; }

        [Display(Name = "CÓDIGO COMANDA")]
        public String CodigoBarrasComanda { get; set; }

        [Display(Name = "CODIGO FUNCIONÁRIO")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        [Display(Name = "CÓDIGO PRODUTO")]
        public int ProdutosId { get; set; }
        public virtual Produtos Produtos { get; set; }

        [Display(Name = "QUANTIDADE")]
        public double Quantidade { get; set; }


        [Display(Name = "Data Cadastro")]
        public DateTime? DataCadastro { get; set; }

    }
}