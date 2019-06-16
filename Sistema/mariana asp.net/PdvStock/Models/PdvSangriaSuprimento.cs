using PdvStock.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PdvStock.Models
{
    public class PdvSangriaSuprimento
    {
        public int Id { get; set; }
       
        public virtual Pdv Pdv { get; set; }

        public double ValorUnitario { get; set; }

        public enum TipoSangSupEnum
        {
            Sangria = 1,
            Suprimento = 2,
        }

        [Display(Name = "Status")]
        [Required]
        public TipoSangSupEnum TipoSangSup { get; set; }

        public string DataCadastro { get; set; }

        public virtual DadosDoUsuario DadosDoUsuario { get; set; }
    }
}