using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conn;
using System.Data.OleDb;
using System.Windows.Forms;
namespace Cadastros
{
    class subgrupo
    {
        Conn.Class1 conex = new Class1();
        public string Vdatacadastro = null;
         public string Vnome = null;
         public  string Vgrupo = null;
         public string Vinformacoes = null;
        bool deucerto;

        public bool Cadastra(string pnome, string pinformacoes,int pgrupo, string pdatacadastro)
        {
            string SQInsert = null;
            SQInsert += "INSERT INTO p_subgrupo ";
            SQInsert += "(NOME,INFORMACOES,GRUPO,DATA_CADASTRO) ";
            SQInsert += " VALUES (?,?,?,?)";
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@NOME", OleDbType.VarChar).Value = pnome;
            cmd.Parameters.Add("@INFORMACOES", OleDbType.VarChar).Value = pinformacoes;
            cmd.Parameters.Add("@GRUPO", OleDbType.Integer).Value = pgrupo;
            cmd.Parameters.Add("@DATA_CADASTRO", OleDbType.Date).Value = pdatacadastro;
            try
            {
                cmd.ExecuteNonQuery();
                deucerto = true;
                MessageBox.Show("GRAVADO COM SUCESSO");
            }
            catch (Exception err)
            {
                MessageBox.Show("ERRO NA GRAVAÇÃO ");
                deucerto = false;
                conex.GeraErro("GravaSUBGrupo", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
            return deucerto;
        }
        public void Seleciona(string Pid)
        {
            OleDbConnection conexao = conex.Cnncontrol();
            string sql = "select * from p_subgrupo where HANDLE =  " + Pid;
            sql += " order by NOME";
            OleDbCommand commS = new OleDbCommand(sql, conexao);
            OleDbDataReader da = commS.ExecuteReader();
            while (da.Read())
            {
               Vdatacadastro = da["DATA_CADASTRO"].ToString();
                Vnome = da["NOME"].ToString();
                Vgrupo = da["GRUPO"].ToString();
                Vinformacoes = da["INFORMACOES"].ToString();
            }
        }
        public bool Altera(string Pid,string pnome, string pinformacoes,int pgrupo, string pdatacadastro)
        {
            string SQInsert = null;
            SQInsert += "UPDATE  dbo.p_subgrupo SET ";
            SQInsert += " NOME=?,DATA_CADASTRO=?,INFORMACOES=?,GRUPO=? ";
            SQInsert += " WHERE HANDLE = " + Pid;
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@NOME", OleDbType.VarChar).Value = pnome;
            cmd.Parameters.Add("@DATA_CADASTRO", OleDbType.VarChar).Value = pdatacadastro;
            cmd.Parameters.Add("@INFORMACOES", OleDbType.VarChar).Value = pinformacoes;
            cmd.Parameters.Add("@GRUPO", OleDbType.VarChar).Value = pgrupo;

            try
            {
                cmd.ExecuteNonQuery();
                //deucerto = true;
                MessageBox.Show("ALTERADO COM SUCESSO");
            }
            catch (Exception err)
            {
                MessageBox.Show("ERRO NA GRAVAÇÃO ");
                deucerto = false;
                conex.GeraErro("alteragrupo", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
            return deucerto;
        }
        public void Deleta(string Pid)
        {
            string SQInsert = null;
            SQInsert += "UPDATE  p_subgrupo SET DATA_CANCELAMENTO = ? WHERE HANDLE = " + Pid;

            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@DATA_CANCELAMENTO", OleDbType.VarChar).Value = DateTime.Now;

            try
            {
                cmd.ExecuteNonQuery();
                deucerto = true;
                MessageBox.Show("EXCLUIDO COM SUCESSO");
            }
            catch (Exception err)
            {
                MessageBox.Show("ERRO NA EXCLUSÃO ");
                deucerto = false;
                conex.GeraErro("deletagrupo", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
        }
        public bool ConsultaAntes_Deletar(string Pid)
        {
            bool existe = false;
            OleDbConnection conexao = conex.Cnncontrol();
            string sql = "select * from p_grupo a join p_subgrupo b on b.grupo = a.handle where b.HANDLE =  " + Pid;
            OleDbCommand commS = new OleDbCommand(sql, conexao);
            OleDbDataReader da = commS.ExecuteReader();
            while (da.Read())
            {
                existe = true;
            }
            if (existe)
            {
                MessageBox.Show("NÃO É POSSIVEL REMOVER POIS ESTA VINCULADO A UM GRUPO\nREMOVA O GRUPO ANTES", "ATENÇÂO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                existe = false;
            }
            return existe;
        }
    }
}
