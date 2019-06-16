using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PdvStock.Models
{
    public class Grupo
    {
        public int Id { get; set; }
        public String Nome { get; set; }

        [Display(Name = "Informações")]
        public String Informacoes { get; set; }

        [Display(Name = "Data Cadastro")]
        public DateTime? DataCadastro { get; set; }

        [NotMapped]
        public virtual SubGrupo SubGrupo { get; set; }
    }
}