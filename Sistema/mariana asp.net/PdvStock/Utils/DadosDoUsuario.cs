using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PdvStock.Utils
{
    public partial class DadosDoUsuario
    {
        public int Id { get; set; }

        
        public string Nome { get; set; }

        public string Senha { get; set; }

        /// <remarks/>
        public string Departamento { get; set; }

        /// <remarks/>
        public string Email { get; set; }

        /// <remarks/>
        public string Telefone { get; set; }

        /// <remarks/>
        public string Usuario { get; set; }

        /// <remarks/>
        public string Cpf { get; set; }

        /// <remarks/>
        public string CentroCusto { get; set; }

        /// <remarks/>
        public bool UsuarioAtivo { get; set; }

        /// <remarks/>
        public bool Erro { get; set; }

        /// <remarks/>
        public string ErroMsg { get; set; }

        /// <remarks/>
        public int ErroCode { get; set; }

        /// <remarks/>
        public bool Gestores { get; set; }

        /// <remarks/>
        public bool GestorDesteSistema { get; set; }
        /// <remarks/>
        public bool AdministradorDesteSistema { get; set; }

        /// <remarks/>
        public bool LogaTudo { get; set; }
        /// <remarks/>
        public int SistemaId { get; set; }

        /// <remarks/>
        public string Informacoes { get; set; }

        /// <remarks/>
        public string Navegador { get; set; }

        /// <remarks/>
        public string IP { get; set; }

        /// <remarks/>
        public string UrlRequisicao { get; set; }

        /// <remarks/>
        public string SimularUsuario { get; set; }

        /// <remarks/>
        public bool Simulacao { get; set; }
        /// <remarks/>
        public string SimuladoPor { get; set; }

        /// <remarks/>
        public PerfilService[] PerfisUsuario { get; set; }
    }
}
