using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PdvStock.Utils
{
    public partial class PerfilService
    {

        /// <remarks/>
        public int Id{get;set;}
        

        /// <remarks/>
        public string Nome { get; set; }

        /// <remarks/>
        public bool Administrador { get; set; }

        /// <remarks/>
        public ModuloService[] Liberacoes { get; set; }
    }
}
