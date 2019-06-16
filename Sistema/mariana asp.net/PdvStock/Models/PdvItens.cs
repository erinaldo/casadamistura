using PdvStock.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PdvStock.Models
{
    public class PdvItens
    {
        public int Id { get; set; }

        public int PdvId { get; set; }
        public virtual Pdv Pdv { get; set; }

        public Nullable<int> ProdutosId { get; set; }
        public virtual Produtos Produtos { get; set; }

        public double Comissao { get; set; }

        public int Quantidade { get; set; }

        public double ValorUnitario { get; set; }

        public double Desconto { get; set; }

        public double SubTotal { get; set; }

        public string DataCadastro { get; set; }

        public virtual DadosDoUsuario DadosDoUsuario { get; set; }
    }
}