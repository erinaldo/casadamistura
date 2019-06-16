using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conn;

using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace Cadastros
{
    class cliente
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
        public string Vinformacoes = null;
        
        public void Cadastra(string pnome,string pemail,string pcpf,string ptelefone,string pcelular1,string pcelular2,string pdatanascimento,string pcep,string pendereco,string pnumero,string pbairro,string pcidade,string pestado,string pinformacoes,string pdatacadastro)
        {
            string SQInsert = null;
            SQInsert += "INSERT INTO p_clientes ";
            SQInsert += "(NOME, EMAIL, CPF, TELEFONE, CELULAR1, CELULAR2, DATA_NASCIMENTO, CEP, ENDERECO, NUMERO, BAIRRO, CIDADE, ESTADO, INFORMACOES,DATA_CADASTRO) ";
            SQInsert += " VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
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
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("GRAVADO COM SUCESSO");
            }
            catch (Exception err)
            {
                MessageBox.Show("ERRO NA GRAVAÇÃO ");
                conex.GeraErro("GravaClliente", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
        }
        public void Altera(string Pid,string pnome, string pemail, string pcpf, string ptelefone, string pcelular1, string pcelular2, string pdatanascimento, string pcep, string pendereco,string pnumero, string pbairro, string pcidade, string pestado, string pinformacoes, string pdatacadastro)
        {
            string SQInsert = null;
            SQInsert += "UPDATE p_clientes SET ";
            SQInsert += " NOME=?, EMAIL=?, CPF=?, TELEFONE=?, CELULAR1=?, CELULAR2=?, DATA_NASCIMENTO=?, CEP=?, ENDERECO=?,NUMERO=?, BAIRRO=?, CIDADE=?, ESTADO=?, INFORMACOES=?,DATA_CADASTRO=?  ";
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
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("ALTERADO COM SUCESSO");
            }
            catch (Exception err)
            {
                MessageBox.Show("ERRO NA GRAVAÇÃO ");
                conex.GeraErro("Alteracliente", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
        }
        public void seleciona(string pid)
        {
            OleDbConnection conexao = conex.Cnncontrol();
            string sql = "select * from p_clientes where handle = " + pid;
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
            }
        }
        public void Deleta(string Pid)
        {
            string SQInsert = null;
            SQInsert += "UPDATE  p_clientes SET DATA_CANCELAMENTO = ? WHERE HANDLE = "+Pid;

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
                conex.GeraErro("deletacliente", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
        }
        public void Carrega_Combos_cliente(ComboBox cbo)
        {
            string sQuery = null;
            sQuery = sQuery + string.Format("select HANDLE, CONVERT(VARCHAR,HANDLE)+ ' - ' +NOME AS NOME  from p_clientes  where DATA_CANCELAMENTO is null ORDER BY Nome");
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
