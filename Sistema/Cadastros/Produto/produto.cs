using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Conn;
using System.Windows.Forms;
namespace Cadastros
{
    class produto
    {
        Conn.Class1 conex = new Class1();

        public string vCodigo_barras = null;
        public string vNome = null;
        public string vCod_interno = null;
        public string vData_cadastro = null;
        public int vFornecedor = 0;
        public double vPeso = 0;
        public int vGrupo = 0;
        public int vSubgrupo = 0;
        public string vInformacoes = null;
        public double vPreco_custo = 0;
        public double vPreco_venda = 0;
        public double vLucro = 0;
        public double vDesconto_max = 0;
        public string vTipo_estoque = null;
        public double vQuantidade_atual = 0;
        public double vQuantidade_minima = 0;
        public double vQuantidade_maxima = 0;
        public byte[] vImagem = null;
        public double vicms = 0;
        public double viss = 0;
        public double vipi = 0;
        public double viof = 0;
        public double vpis = 0;
        public double vcofins = 0;
        public double vcide = 0;
        public double vcll = 0;
        bool deucerto;


        public bool Cadastra(string Codigo_barras, string Nome,  string Cod_interno,  string Data_cadastro,  int Fornecedor, double Peso, int Grupo, int Subgrupo,  string Informacoes, double Preco_custo, double Preco_venda, double Lucro, double Desconto_max,  string Tipo_estoque, double Quantidade_atual, double Quantidade_minima,  double Quantidade_maxima, byte[] Imagem, double icms, double iss, double ipi, double iof, double pis, double cofins, double cide, double cll)
        {
            string SQInsert = null;
            SQInsert += "INSERT INTO p_produtos ";
            SQInsert += "(CODIGO_BARRAS,NOME,COD_INTERNO, DATA_CADASTRO, FORNECEDOR, PESO, GRUPO, SUBGRUPO, INFORMACOES, PRECO_CUSTO, PRECO_VENDA, LUCRO, DESCONTO_MAX, TIPO_ESTOQUE, QUANTIDADE_ATUAL, QUANTIDADE_MINIMA, QUANTIDADE_MAXIMA, IMAGEM,ICMS,ISS ,IPI ,IOF ,PIS_PASEP ,COFINS ,CIDE ,CLL) ";
            SQInsert += " VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@CODIGO_BARRAS", OleDbType.VarChar).Value = Codigo_barras;
            cmd.Parameters.Add("@NOME", OleDbType.VarChar).Value = Nome;
            cmd.Parameters.Add("@COD_INTERNO", OleDbType.VarChar).Value = Cod_interno;
            cmd.Parameters.Add("@DATA_CADASTRO", OleDbType.Date).Value = Data_cadastro;
            cmd.Parameters.Add("@FORNECEDOR", OleDbType.Integer).Value = Fornecedor;
            cmd.Parameters.Add("@PESO", OleDbType.Decimal).Value = Peso;
            cmd.Parameters.Add("@GRUPO", OleDbType.VarChar).Value = Grupo;
            cmd.Parameters.Add("@SUBGRUPO", OleDbType.VarChar).Value = Subgrupo;
            cmd.Parameters.Add("@INFORMACOES", OleDbType.VarChar).Value = Informacoes;
            cmd.Parameters.Add("@PRECO_CUSTO", OleDbType.Decimal).Value = Preco_custo;
            cmd.Parameters.Add("@PRECO_VENDA", OleDbType.Decimal).Value = Preco_venda;
            cmd.Parameters.Add("@LUCRO", OleDbType.Decimal).Value = Lucro;
            cmd.Parameters.Add("@DESCONTO_MAX", OleDbType.Decimal).Value = Desconto_max;
            cmd.Parameters.Add("@TIPO_ESTOQUE", OleDbType.VarChar).Value = Tipo_estoque;
            cmd.Parameters.Add("@QUANTIDADE_ATUAL", OleDbType.Decimal).Value = Quantidade_atual;
            cmd.Parameters.Add("@QUANTIDADE_MINIMA", OleDbType.Decimal).Value = Quantidade_minima;
            cmd.Parameters.Add("@QUANTIDADE_MAXIMA", OleDbType.Decimal).Value = Quantidade_maxima;
            cmd.Parameters.Add("@IMAGEM", OleDbType.Binary).Value = Imagem;
            cmd.Parameters.Add("@ICMS", OleDbType.Decimal).Value = icms;
            cmd.Parameters.Add("@ISS", OleDbType.Decimal).Value = iss;
            cmd.Parameters.Add("@IPI", OleDbType.Decimal).Value = ipi;
            cmd.Parameters.Add("@IOF", OleDbType.Decimal).Value = iof;
            cmd.Parameters.Add("@PIS_PASEP", OleDbType.Decimal).Value = pis;
            cmd.Parameters.Add("@COFINS", OleDbType.Decimal).Value = cofins;
            cmd.Parameters.Add("@CIDE", OleDbType.Decimal).Value = cide;
            cmd.Parameters.Add("@CLL", OleDbType.Decimal).Value = cll;

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
                conex.GeraErro("GravaProduto", err.Message.ToString(), DateTime.Now.ToString());
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
            string sql = "select * from p_produtos where HANDLE =  "+Pid;
            sql += " order by NOME";
            OleDbCommand commS = new OleDbCommand(sql, conexao);
            OleDbDataReader da = commS.ExecuteReader();
            while (da.Read())
            {
                vCodigo_barras = da["CODIGO_BARRAS"].ToString();
                vNome = da["NOME"].ToString();
                vCod_interno = da["COD_INTERNO"].ToString();
                vData_cadastro =  String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(da["DATA_CADASTRO"]));;
                vFornecedor = Convert.ToInt32(da["FORNECEDOR"].ToString());
                vPeso = Convert.ToDouble(da["PESO"].ToString());
                vGrupo = Convert.ToInt32(da["GRUPO"].ToString());
                vSubgrupo =  Convert.ToInt32(da["SUBGRUPO"].ToString());
                vInformacoes = da["INFORMACOES"].ToString();
                vPreco_custo = Convert.ToDouble(da["PRECO_CUSTO"].ToString());
                vPreco_venda = Convert.ToDouble(da["PRECO_VENDA"].ToString());
                vLucro = Convert.ToDouble(da["LUCRO"].ToString());
                vDesconto_max = Convert.ToDouble(da["DESCONTO_MAX"].ToString());
                vTipo_estoque = da["TIPO_ESTOQUE"].ToString();
                vQuantidade_atual = Convert.ToDouble(da["QUANTIDADE_ATUAL"].ToString());
                vQuantidade_minima = Convert.ToDouble(da["QUANTIDADE_MINIMA"].ToString());
                vQuantidade_maxima = Convert.ToDouble(da["QUANTIDADE_MAXIMA"].ToString());
                vicms = Convert.ToDouble((da["ICMS"].ToString() == "" ? "0" : da["ICMS"].ToString()));
                viss = Convert.ToDouble((da["ISS"].ToString() == "" ? "0" : da["ISS"].ToString()));
                vipi = Convert.ToDouble((da["IPI"].ToString() == "" ? "0" : da["IPI"].ToString()));
                viof = Convert.ToDouble((da["IOF"].ToString() == "" ? "0" : da["IOF"].ToString()));
                vpis = Convert.ToDouble((da["PIS_PASEP"].ToString() == "" ? "0" : da["PIS_PASEP"].ToString()));
                vcofins = Convert.ToDouble((da["COFINS"].ToString() == "" ? "0" : da["COFINS"].ToString()));
                vcide = Convert.ToDouble((da["CIDE"].ToString() == "" ? "0" : da["CIDE"].ToString()));
                vcll = Convert.ToDouble((da["CLL"].ToString() == "" ? "0" : da["CLL"].ToString()));
            }
        }
        public bool Altera(string Pid,string Codigo_barras, string Nome, string Cod_interno, string Data_cadastro, int pFornecedor, double Peso, int Grupo, int Subgrupo, string Informacoes, double Preco_custo, double Preco_venda, double Lucro, double Desconto_max, string Tipo_estoque, double Quantidade_atual, double Quantidade_minima, double Quantidade_maxima, byte[] Imagem, double icms, double iss, double ipi, double iof, double pis, double cofins, double cide, double cll)
        {
            string SQInsert = null;
            SQInsert += "UPDATE  p_produtos SET ";
            SQInsert += " CODIGO_BARRAS=?,NOME=?,COD_INTERNO=?, DATA_CADASTRO=?, FORNECEDOR=?, PESO=?, GRUPO=?, SUBGRUPO=?, INFORMACOES=?, PRECO_CUSTO=?, PRECO_VENDA=?, LUCRO=?, DESCONTO_MAX=?, TIPO_ESTOQUE=?, QUANTIDADE_ATUAL=?, QUANTIDADE_MINIMA=?, QUANTIDADE_MAXIMA=?, IMAGEM=?,ICMS=?,ISS =?,IPI =?,IOF =?,PIS_PASEP =?,COFINS =?,CIDE =?,CLL=? ";
            SQInsert += " WHERE HANDLE = "+ Pid;
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@CODIGO_BARRAS", OleDbType.VarChar).Value = Codigo_barras;
           cmd.Parameters.Add("@NOME", OleDbType.VarChar).Value = Nome;
            cmd.Parameters.Add("@COD_INTERNO", OleDbType.VarChar).Value = Cod_interno;
            cmd.Parameters.Add("@DATA_CADASTRO", OleDbType.Date).Value = Data_cadastro;
            cmd.Parameters.Add("@FORNECEDOR", OleDbType.Integer).Value = pFornecedor;
            cmd.Parameters.Add("@PESO", OleDbType.Decimal).Value = Peso;
            cmd.Parameters.Add("@GRUPO", OleDbType.VarChar).Value = Grupo;
            cmd.Parameters.Add("@SUBGRUPO", OleDbType.VarChar).Value = Subgrupo;
            cmd.Parameters.Add("@INFORMACOES", OleDbType.VarChar).Value = Informacoes;
            cmd.Parameters.Add("@PRECO_CUSTO", OleDbType.Decimal).Value = Preco_custo;
            cmd.Parameters.Add("@PRECO_VENDA", OleDbType.Decimal).Value = Preco_venda;
            cmd.Parameters.Add("@LUCRO", OleDbType.Decimal).Value = Lucro;
            cmd.Parameters.Add("@DESCONTO_MAX", OleDbType.Decimal).Value = Desconto_max;
            cmd.Parameters.Add("@TIPO_ESTOQUE", OleDbType.VarChar).Value = Tipo_estoque;
            cmd.Parameters.Add("@QUANTIDADE_ATUAL", OleDbType.Decimal).Value = Quantidade_atual;
            cmd.Parameters.Add("@QUANTIDADE_MINIMA", OleDbType.Decimal).Value = Quantidade_minima;
            cmd.Parameters.Add("@QUANTIDADE_MAXIMA", OleDbType.Decimal).Value = Quantidade_maxima;
            cmd.Parameters.Add("@IMAGEM", OleDbType.Binary).Value = Imagem;
            cmd.Parameters.Add("@ICMS", OleDbType.Decimal).Value = icms;
            cmd.Parameters.Add("@ISS", OleDbType.Decimal).Value = iss;
            cmd.Parameters.Add("@IPI", OleDbType.Decimal).Value = ipi;
            cmd.Parameters.Add("@IOF", OleDbType.Decimal).Value = iof;
            cmd.Parameters.Add("@PIS_PASEP", OleDbType.Decimal).Value = pis;
            cmd.Parameters.Add("@COFINS", OleDbType.Decimal).Value = cofins;
            cmd.Parameters.Add("@CIDE", OleDbType.Decimal).Value = cide;
            cmd.Parameters.Add("@CLL", OleDbType.Decimal).Value = cll;

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
            SQInsert += "UPDATE  p_produtos SET DATA_CANCELAMENTO = ? WHERE HANDLE = " + Pid;

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
                conex.GeraErro("deletaproduto", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
        }
    }
}
