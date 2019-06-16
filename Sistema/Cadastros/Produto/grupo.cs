using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Conn;
using System.Windows.Forms;
namespace Cadastros
{
    class grupo
    {
        Conn.Class1 conex = new Class1();
        public string Vdatacadastro = null;
        public string Vnome = null;
        public string Vinformacoes = null;

        bool deucerto;
        
        public bool Cadastra(string pnome, string pinformacoes, string pdatacadastro)
        {
            string SQInsert = null;
            SQInsert += "INSERT INTO p_grupo ";
            SQInsert += "(NOME,INFORMACOES,DATA_CADASTRO) ";
            SQInsert += " VALUES (?,?,?)";
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@NOME", OleDbType.VarChar).Value = pnome;
            cmd.Parameters.Add("@INFORMACOES", OleDbType.VarChar).Value = pinformacoes;
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
                conex.GeraErro("GravaGrupo", err.Message.ToString(), DateTime.Now.ToString());
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
            string sql = "select * from p_grupo where HANDLE =  " + Pid;
            sql += " order by NOME";
            OleDbCommand commS = new OleDbCommand(sql, conexao);
            OleDbDataReader da = commS.ExecuteReader();
            while (da.Read())
            {
                Vdatacadastro = da["DATA_CADASTRO"].ToString();
                Vnome = da["NOME"].ToString();
                Vinformacoes = da["INFORMACOES"].ToString();
            }
        }
        public bool Altera(string Pid, string pnome,string pinformacoes, string pdata_cadastro)
        {
            string SQInsert = null;
            SQInsert += "UPDATE  dbo.p_grupo SET ";
            SQInsert += " NOME=?,DATA_CADASTRO=?,INFORMACOES=? ";
            SQInsert += " WHERE HANDLE = " + Pid;
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@NOME", OleDbType.VarChar).Value = pnome;
            cmd.Parameters.Add("@DATA_CADASTRO", OleDbType.VarChar).Value = pdata_cadastro;
            cmd.Parameters.Add("@INFORMACOES", OleDbType.VarChar).Value = pinformacoes;

            try
            {
                cmd.ExecuteNonQuery();
                deucerto = true;
                MessageBox.Show("ALTERADO COM SUCESSO");
            }
            catch (Exception err)
            {
                MessageBox.Show("ERRO NA GRAVAÇÃO ");
                deucerto = false;
                conex.GeraErro("ALTERAPRODUTO", err.Message.ToString(), DateTime.Now.ToString());
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
                SQInsert += "UPDATE  p_grupo SET DATA_CANCELAMENTO = ? WHERE HANDLE = " + Pid;

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
                    conex.GeraErro("deletaproduto", err.Message.ToString(), DateTime.Now.ToString());
                }
                finally
                {
                    DbConnection.Close();
                }

        }
        public bool ConsultaAntes_Deletar(string Pid)
        {
            bool existe = false;
            string produto = null;
            OleDbConnection conexao = conex.Cnncontrol();
            string sql = "select a.NOME,a.CODIGO_BARRAS from p_produtos a join p_grupo b on a.grupo = b.handle where b.HANDLE =  " + Pid;
            sql += " order by NOME";
            OleDbCommand commS = new OleDbCommand(sql, conexao);
            OleDbDataReader da = commS.ExecuteReader();
            while (da.Read())
            {
                produto += "NOME: " + da["NOME"].ToString() + "  |  COD. BARRAS: " + da["CODIGO_BARRAS"].ToString() + "\n";
            }
            if (produto != null)
            {
                MessageBox.Show("EXISTEM OS SEGUINTES PRODUTOS COM ESTE GRUPO, NÃO SENDO POSSIVEL A REMOÇÃO DESTE GRUPO\n" + produto, "ATENÇÂO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                existe = true;
            }
            else
            {
                existe = false;
            }
            return existe;
        }
    }
}
