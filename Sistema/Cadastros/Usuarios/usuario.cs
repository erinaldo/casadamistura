using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conn;

using System.Windows.Forms;
using System.Data.OleDb;

namespace Cadastros
{
    class usuario
    {
        Conn.Class1 conex = new Class1();

        public string Vdatacadastro = null;
        public string Vnome = null;
        public string Vemail = null;
        public string Vcpf = null;
        public string Vtelefone = null;
        public string Vcelular1 = null;
        public string Vcelular2 = null;
        public string Vdatanascimento = null;
        public string Vcep = null;
        public string Vendereco = null;
        public string Vnumero = null;
        public string Vbairro = null;
        public string Vcidade = null;
        public string Vestado = null;
        public string vlogin = null;
        public string vsenha = null;
        public string Vinformacoes = null;
        public string vfuncao = null;
        bool deucerto;
        public bool Cadastra(string pnome,string pemail,string pcpf,string ptelefone,string pcelular1,string pcelular2,string pdatanascimento,string pcep,string pendereco,string pnumero,string pbairro,string pcidade,string pestado,string pinformacoes,string pdatacadastro,string plogin,string psenha,string pfuncao)
        {
            string SQInsert = null;
            SQInsert += "INSERT INTO dbo.p_usuarios ";
            SQInsert += " (NOME,EMAIL,CPF,TELEFONE,CELULAR1,CELULAR2,DATA_NASCIMENTO,CEP,ENDERECO,BAIRRO,CIDADE,ESTADO,INFORMACOES,DATA_CADASTRO,NUMERO,LOGIN,SENHA,FUNCAO) ";
            SQInsert += " VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@NOME", OleDbType.VarChar).Value = pnome;
            cmd.Parameters.Add("@EMAIL", OleDbType.VarChar).Value = pemail;
            cmd.Parameters.Add("@CPF", OleDbType.VarChar).Value = pcpf;
            cmd.Parameters.Add("@TELEFONE", OleDbType.VarChar).Value = ptelefone;
            cmd.Parameters.Add("@CELULAR1", OleDbType.VarChar).Value = pcelular1;
            cmd.Parameters.Add("@CELULAR2", OleDbType.VarChar).Value = pcelular2;
            cmd.Parameters.Add("@DATA_NASCIMENTO", OleDbType.Date).Value = pdatanascimento;
            cmd.Parameters.Add("@CEP", OleDbType.VarChar).Value = pcep;
            cmd.Parameters.Add("@ENDERECO", OleDbType.VarChar).Value = pendereco;
            cmd.Parameters.Add("@NUMERO", OleDbType.VarChar).Value = pnumero;
            cmd.Parameters.Add("@BAIRRO", OleDbType.VarChar).Value = pbairro;
            cmd.Parameters.Add("@CIDADE", OleDbType.VarChar).Value = pcidade;
            cmd.Parameters.Add("@ESTADO", OleDbType.VarChar).Value = pestado;
            cmd.Parameters.Add("@INFORMACOES", OleDbType.VarChar).Value = pinformacoes;
            cmd.Parameters.Add("@DATA_CADASTRO", OleDbType.Date).Value = pdatacadastro;
            cmd.Parameters.Add("@LOGIN", OleDbType.VarChar).Value = plogin;
            cmd.Parameters.Add("@SENHA", OleDbType.VarChar).Value = psenha;
            cmd.Parameters.Add("@FUNCAO", OleDbType.VarChar).Value = pfuncao;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("GRAVADO COM SUCESSO");
                deucerto = true;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERRO NA GRAVAÇÃO ");
                deucerto = false;
                conex.GeraErro("GravaUsuario", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
            return deucerto;
        }
        public bool Altera(string Pid,string pnome, string pemail, string pcpf, string ptelefone, string pcelular1, string pcelular2, string pdatanascimento, string pcep, string pendereco,string pnumero, string pbairro, string pcidade, string pestado, string pinformacoes, string pdatacadastro,string plogin,string psenha,string pfuncao)
        {
            string SQInsert = null;
            SQInsert += "UPDATE p_usuarios SET ";
            SQInsert += " NOME=?, EMAIL=?, CPF=?, TELEFONE=?, CELULAR1=?, CELULAR2=?, DATA_NASCIMENTO=?, CEP=?, ENDERECO=?,NUMERO=?, BAIRRO=?, CIDADE=?, ESTADO=?, INFORMACOES=?,DATA_CADASTRO=?,LOGIN=?,SENHA=?,FUNCAO=?  ";
            SQInsert += " WHERE HANDLE = " + Pid;
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@NOME", OleDbType.VarChar).Value = pnome;
            cmd.Parameters.Add("@EMAIL", OleDbType.VarChar).Value = pemail;
            cmd.Parameters.Add("@CPF", OleDbType.VarChar).Value = pcpf;
            cmd.Parameters.Add("@TELEFONE", OleDbType.VarChar).Value = ptelefone;
            cmd.Parameters.Add("@CELULAR1", OleDbType.VarChar).Value = pcelular1;
            cmd.Parameters.Add("@CELULAR2", OleDbType.VarChar).Value = pcelular2;
            cmd.Parameters.Add("@DATA_NASCIMENTO", OleDbType.Date).Value = pdatanascimento;
            cmd.Parameters.Add("@CEP", OleDbType.VarChar).Value = pcep;
            cmd.Parameters.Add("@ENDERECO", OleDbType.VarChar).Value = pendereco;
            cmd.Parameters.Add("@NUMERO", OleDbType.VarChar).Value = pnumero;
            cmd.Parameters.Add("@BAIRRO", OleDbType.VarChar).Value = pbairro;
            cmd.Parameters.Add("@CIDADE", OleDbType.VarChar).Value = pcidade;
            cmd.Parameters.Add("@ESTADO", OleDbType.VarChar).Value = pestado;
            cmd.Parameters.Add("@INFORMACOES", OleDbType.VarChar).Value = pinformacoes;
            cmd.Parameters.Add("@DATA_CADASTRO", OleDbType.Date).Value = pdatacadastro;
            cmd.Parameters.Add("@LOGIN", OleDbType.VarChar).Value = plogin;
            cmd.Parameters.Add("@SENHA", OleDbType.VarChar).Value = psenha;
            cmd.Parameters.Add("@FUNCAO", OleDbType.VarChar).Value = pfuncao;
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
                conex.GeraErro("Alterausuario", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
            return deucerto;
        }
        public void seleciona(string pid)
        {
            OleDbConnection conexao = conex.Cnncontrol();
            string sql = "select * from dbo.p_usuarios where handle = " + pid;
            OleDbCommand cmd = new OleDbCommand(sql, conexao);
            OleDbDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
               // dataGridView1.Rows.Add(da["HANDLE"].ToString(), da["NOME"].ToString());
                Vdatacadastro = da["DATA_CADASTRO"].ToString();
                Vnome = da["NOME"].ToString();
                Vemail = da["EMAIL"].ToString();
                Vcpf = da["CPF"].ToString();
                Vtelefone = da["TELEFONE"].ToString();
                Vcelular1 = da["CELULAR1"].ToString();
                Vcelular2 = da["CELULAR2"].ToString();
                Vdatanascimento = da["DATA_NASCIMENTO"].ToString();
                Vcep = da["CEP"].ToString();
                Vendereco = da["ENDERECO"].ToString();
                Vnumero = da["NUMERO"].ToString();
                Vbairro = da["BAIRRO"].ToString();
                Vcidade = da["CIDADE"].ToString();
                Vestado = da["ESTADO"].ToString();
                Vinformacoes = da["INFORMACOES"].ToString();
                vlogin = da["LOGIN"].ToString();
                vsenha = da["SENHA"].ToString();
                vfuncao = da["FUNCAO"].ToString();
            }
        }
        public void Deleta(string Pid)
        {
            string SQInsert = null;
            SQInsert += "UPDATE  dbo.p_usuarios SET DATA_CANCELAMENTO = ? WHERE HANDLE = " + Pid;

            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@DATA_CANCELAMENTO", OleDbType.VarChar).Value = DateTime.Now;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("EXCLUIDO COM SUCESSO");
            }
            catch (Exception err)
            {
                MessageBox.Show("ERRO NA EXCLUSÃO ");
                conex.GeraErro("deletausuario", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
        }
    }
}
