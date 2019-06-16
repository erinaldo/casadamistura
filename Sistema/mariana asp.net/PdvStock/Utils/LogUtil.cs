using PdvStock.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace PdvStock.Utils
{
    
    public class AdHelper
    {
        public static DadosDoUsuario GetDebugAd()
        {
            var resultado = new DadosDoUsuario();
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
            return resultado;
        }

    }
    
    public class LogObject
    {
        public String NomeDoArquivo { get; set; }
        public String Caminho { get; set; }
        public String Extensao { get; set; }
        public Boolean GravarData { get; set; }
        public Boolean SobreescreverArquivo { get; set; }
        public Boolean EmNovoArquivo { get; set; }

        public static LogObject GetInstance()
        {
            return new LogObject()
            {
                Extensao = ".txt",
                Caminho = "" + AppDomain.CurrentDomain.BaseDirectory + "Logs",
                NomeDoArquivo = "Logs",
                GravarData = true,
                SobreescreverArquivo = false,
                EmNovoArquivo = false,
            };
        }
       
        public static LogObject GetInstance(String NomeDoArquivo)
        {
            var logobj = LogObject.GetInstance();
            logobj.NomeDoArquivo = NomeDoArquivo;
            return logobj;
        }

        public static LogObject GetInstance(String NomeDoArquivo, String Pasta)
        {
            var logobj = LogObject.GetInstance();
            logobj.NomeDoArquivo = NomeDoArquivo;
            logobj.Caminho = AppDomain.CurrentDomain.BaseDirectory + Pasta;
            return logobj;
        }
       
        public static LogObject GetInstance(String NomeDoArquivo, String Pasta, String Extensao)
        {
            var logobj = LogObject.GetInstance();
            logobj.NomeDoArquivo = NomeDoArquivo;
            logobj.Caminho = AppDomain.CurrentDomain.BaseDirectory + Pasta;
            logobj.Extensao = Extensao;
            return logobj;
        }
     
        public static LogObject GetInstance(String NomeDoArquivo, String Pasta, String Extensao, bool GravarData)
        {
            var logobj = LogObject.GetInstance();
            logobj.NomeDoArquivo = NomeDoArquivo;
            logobj.Caminho = AppDomain.CurrentDomain.BaseDirectory + Pasta;
            logobj.Extensao = Extensao;
            logobj.GravarData = GravarData;
            return logobj;
        }
    
        public static LogObject GetInstance(String NomeDoArquivo, String Pasta, String Extensao, bool GravarData, bool Sobreescrever)
        {
            var logobj = LogObject.GetInstance();
            logobj.NomeDoArquivo = NomeDoArquivo;
            logobj.Caminho = AppDomain.CurrentDomain.BaseDirectory + Pasta;
            logobj.Extensao = Extensao;
            logobj.GravarData = GravarData;
            logobj.SobreescreverArquivo = Sobreescrever;
            return logobj;
        }
     
        public static LogObject GetInstance(String NomeDoArquivo, String Pasta, String Extensao, bool GravarData, bool Sobreescrever, bool EmNovoArquivo)
        {
            var logobj = LogObject.GetInstance();
            logobj.NomeDoArquivo = NomeDoArquivo;
            logobj.Caminho = AppDomain.CurrentDomain.BaseDirectory + Pasta;
            logobj.Extensao = Extensao;
            logobj.GravarData = GravarData;
            logobj.SobreescreverArquivo = Sobreescrever;
            logobj.EmNovoArquivo = EmNovoArquivo;
            return logobj;
        }

        public string GetCaminhoArquivo()
        {
            if (Extensao != null)
            {
                if (!Extensao.StartsWith("."))
                {
                    Extensao = "." + Extensao;
                }
            }
            if (EmNovoArquivo)
            {
                //Aplica data no arquivo
                String novo = DateTime.Now.ToString();
                novo = novo.Replace('/', '_').Replace(' ', '_').Replace(':', '_').Replace('-', '_');
                NomeDoArquivo += "_" + novo;

                if (ServerUtil.LocalFileExists(Caminho + "\\" + NomeDoArquivo + (Extensao)))
                {
                    do
                    {
                        novo = DateTime.Now.AddMinutes(1).ToString();
                        novo = novo.Replace('/', '_').Replace(' ', '_').Replace(':', '_').Replace('-', '_');
                        NomeDoArquivo += "_" + novo;
                    } while (ServerUtil.LocalFileExists(Caminho + "\\" + NomeDoArquivo + (Extensao)));
                }
                EmNovoArquivo = false;
            }

            return Caminho + "\\" + NomeDoArquivo + (Extensao);
        }
      
        public bool GravarLinha(String linha, bool? DatarLinha = null)
        {
            if (DatarLinha == null) DatarLinha = this.GravarData;

            bool resultado = false;
            Directory.CreateDirectory(Path.GetDirectoryName(GetCaminhoArquivo()));
            StreamWriter sw = null;
            try
            {
                sw = new System.IO.StreamWriter(GetCaminhoArquivo(), (!SobreescreverArquivo));
                if (DatarLinha.Value)
                {
                    sw.WriteLine("|-- " + DateTime.Now.ToString() + " --| # " + linha);
                }
                else
                {
                    sw.WriteLine(linha);
                }
                resultado = true;
            }
            catch (Exception e)
            {
                var log = LogObject.GetInstance("Exceptions", "Logs", ".log", true);
                log.GravarLinha("\n" + e.Message + "\n" + e.StackTrace + "\n", true);
                resultado = false;
            }
            finally
            {
                if (sw != null) sw.Close();
            }
            SobreescreverArquivo = false;
            return resultado;
        }
     
        public bool GravarTexto(String texto, bool? DatarTexto = null)
        {

            if (DatarTexto == null) DatarTexto = this.GravarData;

            bool resultado = false;
            Directory.CreateDirectory(Path.GetDirectoryName(GetCaminhoArquivo()));
            StreamWriter sw = null;
            try
            {
                sw = new System.IO.StreamWriter(GetCaminhoArquivo(), (!SobreescreverArquivo));
                if (DatarTexto.Value)
                {
                    sw.WriteLine("|-- " + DateTime.Now.ToString() + " --| # ");
                    sw.Write(texto);
                }
                else
                {
                    sw.Write(texto);
                }
                resultado = true;
            }
            catch (Exception e)
            {
                resultado = false;
                var log = LogObject.GetInstance("Exceptions", "Logs", ".log", true);
                log.GravarLinha("\n" + e.Message + "\n" + e.StackTrace + "\n", true);
            }
            finally
            {
                if (sw != null) sw.Close();
            }
            SobreescreverArquivo = false;
            return resultado;
        }

        public void EndHtml()
        {
            GravarTexto(
                "<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js'></script>"
                + "</div></body>"
                + "<html>", false);
        }

        public void Html()
        {
            SobreescreverArquivo = true;
            GravarTexto(
                "<!DOCTYPE html>"
                + "<head>"
                    + "<link href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css' type=\"text/css\" rel='stylesheet' />"
                    + "<meta charset='UTF-8' />"
                + "</head>"
                + "<html>"
                    + "<body>"
                           + "<div class='container'>", false);
        }

        public bool LinhaData()
        {
            bool resultado = false;
            Directory.CreateDirectory(Path.GetDirectoryName(GetCaminhoArquivo()));
            StreamWriter sw = null;
            try
            {
                sw = new System.IO.StreamWriter(GetCaminhoArquivo(), (!SobreescreverArquivo));
                sw.WriteLine("|-- " + DateTime.Now.ToString() + " --|");
                resultado = true;
            }
            catch (Exception e)
            {
                resultado = false;
                var log = LogObject.GetInstance("Exceptions", "Logs", ".log", true);
                log.GravarLinha("\n" + e.Message + "\n" + e.StackTrace + "\n", true);
            }
            finally
            {
                if (sw != null) sw.Close();
            }
            SobreescreverArquivo = false;
            return resultado;
        }
    }

}