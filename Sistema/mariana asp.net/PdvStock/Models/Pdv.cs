using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PdvStock.Models
{
    public class Pdv
    {
        public int Id { get; set; }

        public Nullable<int> ClientesId { get; set; }
        public Clientes Clientes { get; set; }

        public String Cpf { get; set; }

        public double ValorTotal { get; set; }

        public String NumeroVenda { get; set; }

        public DateTime DataVenda { get; set; }

        public Pdv()
        {
            PdvItem = new List<PdvItens>();
            PdvPgto = new List<PdvPagamento>();
            PdvSangriaSuprimentos = new List<PdvSangriaSuprimento>();
        }
        public virtual ICollection<PdvItens> PdvItem { get; set; }
        public virtual ICollection<PdvPagamento> PdvPgto { get; set; }
        public virtual ICollection<PdvSangriaSuprimento> PdvSangriaSuprimentos { get; set; }
    }
}