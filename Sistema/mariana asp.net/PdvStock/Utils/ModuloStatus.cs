using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PdvStock.Utils
{
    public partial class ModuloStatus
    {
        public int Id { get; set; }

        /// <remarks/>
        public string Nome { get; set; }

        /// <remarks/>
        public string Url { get; set; }

        /// <remarks/>
        public AcaoService[] Acoes { get; set; }

        /// <remarks/>
        public ModuloStatus Status { get; set; }
    }
}
