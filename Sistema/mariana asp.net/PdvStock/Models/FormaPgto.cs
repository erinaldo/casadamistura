using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PdvStock.Models
{
    public class FormaPgto
    {
        public int Id { get; set; }

        public String Nome { get; set; }

        [Display(Name = "Máximo Parcelamento")]
        public int MaxParcela { get; set; }

        [Display(Name = "Juros Acrescidos")]
        public double JurosAcrescidos { get; set; }

        [Display(Name = "Data Cadastro")]
        public DateTime? DataCadastro { get; set; }

    }
}