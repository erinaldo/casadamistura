using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Conn;
namespace PDV
{
    public class Class2
    {
        Conn.Class1 conex = new Class1();
        public string usuario { get; set; }
        public string codusuario { get; set; }
        public string perfil { get; set; }
        public string idcaixa { get; set; }
        public string ultimoacesso { get; set; }
        public string ultimaabertura { get; set; }
        public string codcaixaaberto { get; set; }

        public bool verificaacesso(string pusuario, string psenha)
        {
            bool acessou = false;
            string sQuery = null;
            sQuery = sQuery + string.Format("SELECT * FROM p_usuarios WHERE LOGIN='" + pusuario + "' AND SENHA = '" + psenha + "' AND FUNCAO = 1 AND DATA_CANCELAMENTO IS NULL");
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(sQuery, DbConnection);
            OleDbDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                acessou = true;
            }
            da.Close();
            return acessou;
        }
        public bool acesso(string pusuario, string psenha, double pfundo)
        {
            bool acessou = false;
            string sQuery = null;
            sQuery = sQuery + string.Format("SELECT * FROM p_usuarios WHERE LOGIN='" + pusuario + "' AND SENHA = '" + psenha + "' AND DATA_CANCELAMENTO IS NULL");
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(sQuery, DbConnection);
            OleDbDataReader da = cmd.ExecuteReader();
            usuario = "";
            codusuario = "";
            perfil = "";
            while (da.Read())
            {
                usuario = da["LOGIN"].ToString();
                codusuario = da["HANDLE"].ToString();
                perfil = da["FUNCAO"].ToString();
                acessou = true;
            }
            da.Close();
            return acessou;
        }
        public string Cadastra(string pnome, double pfundo)
        {
            string SQInsert = null;
            SQInsert += "INSERT INTO p_abertura_caixa ";
            SQInsert += "(USUARIO,DATA_ABERTURA,FUNDO,STATUS) ";
            SQInsert += " VALUES (?,?,?,?)";
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@UAUARIO", OleDbType.VarChar).Value = pnome;
            cmd.Parameters.Add("@DATA_ABERTURA", OleDbType.Date).Value = DateTime.Now;
            cmd.Parameters.Add("@FUNDO", OleDbType.Decimal).Value = pfundo;
            cmd.Parameters.Add("@STATUS", OleDbType.VarChar).Value = "A";

            try
            {
                cmd.ExecuteNonQuery();
                idcaixa = PegaCod();
            }
            catch (Exception err)
            {
                MessageBox.Show("ERRO NA GRAVAÇÃO ");
                conex.GeraErro("gravaaberturacaixa", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
            return idcaixa;
        }
        public void FechaCaixa(int pcaixa)
        {
            string SQInsert = null;
            SQInsert += "UPDATE p_abertura_caixa ";
            SQInsert += " SET STATUS=?, DATA_FECHAMENTO=? ";
            SQInsert += " WHERE HANDLE = "+ pcaixa;
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@STATUS", OleDbType.VarChar).Value = "F";
            cmd.Parameters.Add("@DATA_FECHAMENTO", OleDbType.Date).Value = DateTime.Now;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show("ERRO NA GRAVAÇÃO ");
                conex.GeraErro("FECHACAIXA", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
        }
        private string PegaCod()
        {
            string id = "0";
            string sQuery = null;
            sQuery = sQuery + string.Format(" SELECT TOP 1 HANDLE as id FROM p_abertura_caixa ORDER BY HANDLE DESC ");
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(sQuery, DbConnection);
            OleDbDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                id = da["id"].ToString();
            }
            da.Close();
            return id;
        }
        public bool VerificaAberto(string pusuario)
        {
            bool aberto = false;
            string sQuery = null;
            sQuery = sQuery + string.Format("SELECT * FROM p_abertura_caixa WHERE USUARIO='" + pusuario + "' AND DATA_FECHAMENTO IS NULL");
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(sQuery, DbConnection);
            OleDbDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                ultimaabertura = Convert.ToDateTime(da["DATA_ABERTURA"].ToString()).ToShortDateString();
                idcaixa = da["HANDLE"].ToString();
                aberto = true;
            }
            da.Close();
            return aberto;
        }

        //============== FECHAMENTO =====================

        public int CadastraFluxo(string pcaixa)
        {
            string SQInsert = null;
            int idfluxocaixa=0;
            SQInsert += "INSERT INTO p_fluxo_caixa ";
            SQInsert += "(CAIXA,DATA_CADASTRO) ";
            SQInsert += " VALUES (?,?)";
            string query2 = "Select @@Identity";
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@CAIXA", OleDbType.VarChar).Value = pcaixa;
            cmd.Parameters.Add("@DATA_CADASTRO", OleDbType.Date).Value = DateTime.Now;
            try
            {
                cmd.ExecuteNonQuery();
                cmd.CommandText = query2;
                idfluxocaixa = System.Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception err)
            {
                MessageBox.Show("ERRO NA GRAVAÇÃO ");
                conex.GeraErro("gravafluxocaixa", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
            return idfluxocaixa;
        }
        public void CadastraProdutosFluxo(int pcaixa, string produto, double pvalor, double pdesconto)
        {
            string SQInsert = null;
            SQInsert += "INSERT INTO p_produto_fluxo_caixa ";
            SQInsert += "(FLUXO_CAIXA,PRODUTO,VALOR,DESCONTO,DATA_CADASTRO) ";
            SQInsert += " VALUES (?,?,?,?,?)";
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@FLUXO_CAIXA", OleDbType.VarChar).Value = pcaixa;
            cmd.Parameters.Add("@PRODUTO", OleDbType.VarChar).Value = produto;
            cmd.Parameters.Add("@VALOR", OleDbType.Decimal).Value = pvalor;
            cmd.Parameters.Add("@DESCONTO", OleDbType.Decimal).Value = pdesconto;
            cmd.Parameters.Add("@DATA_CADASTRO", OleDbType.Date).Value = DateTime.Now;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show("ERRO NA GRAVAÇÃO ");
                conex.GeraErro("grava_produto_fluxocaixa", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
        }
        public void CadastraPagementoFluxo(int pcaixa, string pformapagamento, double pvalor,int ppacelas)
        {
            string SQInsert = null;
            SQInsert += "INSERT INTO p_pagamento_fluxo_caixa ";
            SQInsert += "(FLUXO_CAIXA,FORMAPAGAMENTO,VALOR,DATA_CADASTRO) ";
            SQInsert += " VALUES (?,?,?,?)";
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@FLUXO_CAIXA", OleDbType.VarChar).Value = pcaixa;
            cmd.Parameters.Add("@PRODUTO", OleDbType.VarChar).Value = pformapagamento;
            cmd.Parameters.Add("@VALOR", OleDbType.Decimal).Value = pvalor;
            cmd.Parameters.Add("@DATA_CADASTRO", OleDbType.Date).Value = DateTime.Now;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show("ERRO NA GRAVAÇÃO ");
                conex.GeraErro("grava_pagamento_fluxocaixa", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
        }
        public void deleteComanda(string pcodbarras)
        {
            string SQInsert = null;
            SQInsert += "DELETE FROM p_comanda  WHERE CODIGO_BARRAS = " + pcodbarras + " ";
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@p1", OleDbType.VarChar).Value = pcodbarras;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                conex.GeraErro("dELETA_comanda_CLASS2.cs", err.Message.ToString() + " " + SQInsert, DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
        }

        public double CalculaImposto(int pcodproduto)
        {
            double valorimposto = 0;
            string Sql = null;
            Sql += "SELECT (ICMS+ISS+IPI+IOF+PIS_PASEP+COFINS+CIDE+CLL) totalimposto FROM p_produtos  ";
            Sql += " WHERE HANDLE=" + pcodproduto;
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(Sql, DbConnection);
            OleDbDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                valorimposto = Convert.ToDouble((da["totalimposto"].ToString() != "0" ? da["totalimposto"].ToString() : "0"));
            }
            da.Close();
            return valorimposto;
        }
        //============== SANGRIA E SUPRIMENTO =====================

        public void CadastraSangriaSuprimento(string ptipo,double pvalor,string pcaixa)
        {
            string SQInsert = null;
            SQInsert += "INSERT INTO p_sangria_suprimento ";
            SQInsert += "(TIPO,VALOR,CAIXA,DATA_CADASTRO) ";
            SQInsert += " VALUES (?,?,?,?)";
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@TIPO", OleDbType.VarChar).Value = ptipo;
            cmd.Parameters.Add("@VALOR", OleDbType.Decimal).Value = pvalor;
            cmd.Parameters.Add("@CAIXA", OleDbType.VarChar).Value = pcaixa;
            cmd.Parameters.Add("@DATA_CADASTRO", OleDbType.Date).Value = DateTime.Now;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show("ERRO NA GRAVAÇÃO ");
                conex.GeraErro("CadastraSangriaSuprimento", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
        }


    }
}
