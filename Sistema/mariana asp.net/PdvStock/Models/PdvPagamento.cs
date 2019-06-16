using PdvStock.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PdvStock.Models
{
    public class PdvPagamento
    {
        public int Id { get; set; }

        public int PdvId { get; set; }
        public Pdv Pdv { get; set; }

        public Nullable<int> FormaPgtoId { get; set; }
        public FormaPgto FormaPgto { get; set; }

        public DateTime DataCadastro { get; set; }

        public double Valor { get; set; }

        public int Parcelado { get; set; }

        public int QtdeParcela { get; set; }

    }
}