using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Conn;
using System.Windows.Forms;
using System.Data;

namespace Cadastros
{
    class fornecedores
    {
        Conn.Class1 conex = new Class1();

        public string vdatacadastro = null;
        public string vnome = null;
        public string vresponsavel1 = null;
        public string vresponsavel2 = null;
        public string vemail = null;
        public string vcpf = null;
        public string vtelefone = null;
        public string vcelular1 = null;
        public string vcelular2 = null;
        public string vcep = null;
        public string vendereco = null;
        public string vnumero = null;
        public string vbairro = null;
        public string vcidade = null;
        public string vestado = null;
        public string vinformacoes = null;

        bool deucerto;

        public bool Cadastra(string pData_cadastro,string pNome,string pResponsavel1,string pResponsavel2,string pEmail,string pCpf,string pTelefone,string pCelular1,string pCelular2,string pCep,string pEndereco,string pNumero,string pBairro,string pCidade,string pEstado,string pInformacoes)        
        {
            string SQInsert = null;
            SQInsert += "INSERT INTO p_fornecedor ";
            SQInsert += "(DATA_CADASTRO,NOME,RESPONSAVEL1,RESPONSAVEL2,EMAIL,CPF,TELEFONE,CELULAR1,CELULAR2,CEP,ENDERECO,NUMERO,BAIRRO,CIDADE,ESTADO,INFORMACOES) ";
            SQInsert += " VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@DATA_CADASTRO", OleDbType.Date).Value = DateTime.Now;
            cmd.Parameters.Add("@NOME", OleDbType.VarChar).Value = pNome;
            cmd.Parameters.Add("@RESPONSAVEL1", OleDbType.VarChar).Value = pResponsavel1;
            cmd.Parameters.Add("@RESPONSAVEL2", OleDbType.VarChar).Value = pResponsavel2;
            cmd.Parameters.Add("@EMAIL", OleDbType.VarChar).Value = pEmail;
            cmd.Parameters.Add("@CPF", OleDbType.VarChar).Value = pCpf;
            cmd.Parameters.Add("@TELEFONE", OleDbType.VarChar).Value = pTelefone;
            cmd.Parameters.Add("@CELULAR1", OleDbType.VarChar).Value = pCelular1;
            cmd.Parameters.Add("@CELULAR2", OleDbType.VarChar).Value = pCelular2;
            cmd.Parameters.Add("@CEP", OleDbType.VarChar).Value = pCep;
            cmd.Parameters.Add("@ENDERECO", OleDbType.VarChar).Value = pEndereco;
            cmd.Parameters.Add("@NUMERO", OleDbType.VarChar).Value = pNumero;
            cmd.Parameters.Add("@BAIRRO", OleDbType.VarChar).Value = pBairro;
            cmd.Parameters.Add("@CIDADE", OleDbType.VarChar).Value = pCidade;
            cmd.Parameters.Add("@ESTADO", OleDbType.VarChar).Value = pEstado;
            cmd.Parameters.Add("@INFORMACOES", OleDbType.VarChar).Value = pInformacoes;

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
                conex.GeraErro("GravaFornecedor", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
            return deucerto;
        }
        public bool Altera(string Pid,string pData_cadastro, string pNome, string pResponsavel1, string pResponsavel2, string pEmail, string pCpf, string pTelefone, string pCelular1, string pCelular2, string pCep, string pEndereco, string pNumero, string pBairro, string pCidade, string pEstado, string pInformacoes)
        {
            string SQInsert = null;
            SQInsert += "UPDATE p_fornecedor SET ";
            SQInsert += " DATA_CADASTRO=?,NOME=?,RESPONSAVEL1=?,RESPONSAVEL2=?,EMAIL=?,CPF=?,TELEFONE=?,CELULAR1=?,CELULAR2=?,CEP=?,ENDERECO=?,NUMERO=?,BAIRRO=?,CIDADE=?,ESTADO=?,INFORMACOES=? ";
            SQInsert += " WHERE HANDLE = "+ Pid;
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@DATA_CADASTRO", OleDbType.Date).Value = DateTime.Now;
            cmd.Parameters.Add("@NOME", OleDbType.VarChar).Value = pNome;
            cmd.Parameters.Add("@RESPONSAVEL1", OleDbType.VarChar).Value = pResponsavel1;
            cmd.Parameters.Add("@RESPONSAVEL2", OleDbType.VarChar).Value = pResponsavel2;
            cmd.Parameters.Add("@EMAIL", OleDbType.VarChar).Value = pEmail;
            cmd.Parameters.Add("@CPF", OleDbType.VarChar).Value = pCpf;
            cmd.Parameters.Add("@TELEFONE", OleDbType.VarChar).Value = pTelefone;
            cmd.Parameters.Add("@CELULAR1", OleDbType.VarChar).Value = pCelular1;
            cmd.Parameters.Add("@CELULAR2", OleDbType.VarChar).Value = pCelular2;
            cmd.Parameters.Add("@CEP", OleDbType.VarChar).Value = pCep;
            cmd.Parameters.Add("@ENDERECO", OleDbType.VarChar).Value = pEndereco;
            cmd.Parameters.Add("@NUMERO", OleDbType.VarChar).Value = pNumero;
            cmd.Parameters.Add("@BAIRRO", OleDbType.VarChar).Value = pBairro;
            cmd.Parameters.Add("@CIDADE", OleDbType.VarChar).Value = pCidade;
            cmd.Parameters.Add("@ESTADO", OleDbType.VarChar).Value = pEstado;
            cmd.Parameters.Add("@INFORMACOES", OleDbType.VarChar).Value = pInformacoes;

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
                conex.GeraErro("Alteracaofornecedor", err.Message.ToString(), DateTime.Now.ToString());
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
            string sql = "select * from p_fornecedor where HANDLE =  " + pid;
            sql += " order by NOME";
            OleDbCommand commS = new OleDbCommand(sql, conexao);
            OleDbDataReader da = commS.ExecuteReader();
            while (da.Read())
            {
                vdatacadastro = da["DATA_CADASTRO"].ToString();
                vnome = da["NOME"].ToString();
                vresponsavel1 = da["RESPONSAVEL1"].ToString();
                vresponsavel2 = da["RESPONSAVEL2"].ToString();
                vemail = da["EMAIL"].ToString();
                vcpf = da["CPF"].ToString();
                vtelefone = da["TELEFONE"].ToString();
                vcelular1 = da["CELULAR1"].ToString();
                vcelular2 = da["CELULAR2"].ToString();
                vcep = da["CEP"].ToString();
                vendereco = da["ENDERECO"].ToString();
                vnumero = da["NUMERO"].ToString();
                vbairro = da["BAIRRO"].ToString();
                vcidade = da["CIDADE"].ToString();
                vestado = da["ESTADO"].ToString();
                vinformacoes = da["INFORMACOES"].ToString();
                
            }
        }
        public void Deleta(string Pid)
        {
            string SQInsert = null;
            SQInsert += "UPDATE  dbo.p_fornecedor SET DATA_CANCELAMENTO = ? WHERE HANDLE = " + Pid;

            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@DATA_CANCELAMENTO", OleDbType.Date).Value = DateTime.Now;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("EXCLUIDO COM SUCESSO");
            }
            catch (Exception err)
            {
                MessageBox.Show("ERRO NA EXCLUSÃO ");
                conex.GeraErro("deletafornecedor", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
        }
        public void Carrega_Combos_fornecedor(ComboBox cbo)
        {
            string sQuery = null;
            sQuery = sQuery + string.Format("select HANDLE, CONVERT(VARCHAR,HANDLE)+ ' - ' +NOME AS NOME  from p_fornecedor  where DATA_CANCELAMENTO is null ORDER BY Nome");
            OleDbConnection DbConnection = conex.Cnncontrol();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(sQuery, DbConnection);
            da.Fill(dt);
            cbo.DataSource = dt;
            cbo.DisplayMember = "NOME";
            cbo.ValueMember = "HANDLE";
            DbConnection.Close();
        }
    }
}

