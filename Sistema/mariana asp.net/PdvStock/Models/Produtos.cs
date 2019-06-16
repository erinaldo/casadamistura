using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PdvStock.Models
{
    public class Produtos
    {
        
        [Key]
        public int Id { get; set; }

        [Display(Name = "Cód. Barras")]
        public String CodBarras { get; set; }

        [Required]
        public String Nome { get; set; }

        public String Descricao { get; set; }

        [Display(Name = "Data Cadastro")]
        public DateTime? DataCadastro { get; set; }

        [Display(Name = "Fornecedor")]
        public Nullable<int> FornecedorId { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

        [Display(Name = "SubGrupo")]
        public Nullable<int> SubGrupoId { get; set; }
        public virtual SubGrupo SubGrupo { get; set; }

        [Required]
        public double Peso { get; set; }

        [Display(Name = "Preço Custo")]
        public double PrecoCusto { get; set; }

        [Display(Name = "Preço Venda")]
        [Required]
        public double PrecoVenda { get; set; }

        public double Lucro { get; set; }

        [Display(Name = "Desc. Máx.")]
        public double DescontoMaximo { get; set; }

        public enum TipoEnum
        {
            Inteiro = 1,
            Fracionario = 2,
        }

        [Display(Name = "Tipo")]
        [Required]
        public TipoEnum Status { get; set; }

        [Display(Name = "Qt. Estoque")]
        public double QuantidadeEstocada { get; set; }

        [Display(Name = "Qt. Minima")]
        public double QuantidadeMinima { get; set; }

        [Display(Name = "Qt. Máx.")]
        public double QuantidadeMaxima { get; set; }

        public String Foto { get; set; }

    }
}