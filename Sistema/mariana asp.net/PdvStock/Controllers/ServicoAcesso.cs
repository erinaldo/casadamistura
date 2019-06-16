using PdvStock.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PdvStock.Controllers
{
    public partial class ServicoAcesso
    {
        
        public string UserAgent { get; set; }

        public DadosDoUsuario AutenticarGeral(string Login, string Senha, int SistemaId, string Navegador, string IP, string UrlRequisicao, string UsuarioSimular)
        {
            var resultado = new DadosDoUsuario();
            if (Login == "admin" && Senha == "admin")
            {
                
                resultado.Cpf = "00011122233";
                resultado.Departamento = "Debug/Developement MODE";
                resultado.Email = "debug@debug.com";
                resultado.GestorDesteSistema = true;
                resultado.LogaTudo = true;
                resultado.Telefone = "0000-0000";
                resultado.Nome = "Debug MODE";
                resultado.Usuario = "usuario.teste";
                resultado.ErroCode = 1000;
                resultado.Erro = false;
                resultado.ErroMsg = "Acesso Concedido";
                
            }
            else
            {
                resultado.GestorDesteSistema = false;
                resultado.Erro = true;
                resultado.ErroMsg = "Ocorreu um erro ao Acessar";
            }
            
            return resultado;
        }
    }
}
