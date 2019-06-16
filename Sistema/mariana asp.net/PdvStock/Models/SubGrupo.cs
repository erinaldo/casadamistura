using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PdvStock.Models
{
    public class SubGrupo
    {
        public int Id { get; set; }
        public String Nome { get; set; }

        [Display(Name = "Informações")]
        public String Informacoes { get; set; }

        [Display(Name = "Data Cadastro")]
        public DateTime? DataCadastro { get; set; }

        public int GrupoId { get; set; }
        public virtual Grupo Grupo { get; set; }
    }
}