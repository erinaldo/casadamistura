using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conn;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace Cadastros
{
    class Financeiro
    {

        Conn.Class1 conex = new Class1();
        bool deucerto;
        public string vcodigo = null;
        public string vnome = null;

//============ DESPESA =============================================
        public bool CadastraDespesa(string pnome)
        {
            string SQInsert = null;
            SQInsert += "INSERT INTO p_despesa ";
            SQInsert += "(NOME,DATA_CADASTRO) ";
            SQInsert += " VALUES (?,?)";
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@NOME", OleDbType.VarChar).Value = pnome;
            cmd.Parameters.Add("@DATA_CADASTRO", OleDbType.Date).Value = DateTime.Now;
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
                conex.GeraErro("GRAVA_DESPESA", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
            return deucerto;
        }
        public bool AlteraDespesa(string pcodigo,string pnome)
        {
            string SQInsert = null;
            SQInsert += "UPDATE p_despesa ";
            SQInsert += "SET NOME=?,DATA_CADASTRO=? ";
            SQInsert += " WHERE HANDLE = " + pcodigo;
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@NOME", OleDbType.VarChar).Value = pnome;
            cmd.Parameters.Add("@DATA_CADASTRO", OleDbType.Date).Value = DateTime.Now;
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
                conex.GeraErro("GRAVA_DESPESA", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
            return deucerto;
        }
        public void SelecionaDespesa(string Pid)
        {
            OleDbConnection conexao = conex.Cnncontrol();
            string sql = "select * from p_despesa where HANDLE =  " + Pid;
            sql += " order by NOME";
            OleDbCommand commS = new OleDbCommand(sql, conexao);
            OleDbDataReader da = commS.ExecuteReader();
            while (da.Read())
            {
                vnome = da["NOME"].ToString();
                vcodigo = da["HANDLE"].ToString();
            }
        }
        public bool DeletaDespesa(string Pid)
        {
            string SQInsert = null;
            SQInsert += "UPDATE  p_despesa SET DATA_CANCELAMENTO = ? WHERE HANDLE = " + Pid;

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
                conex.GeraErro("DELETE_DESPESA", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
            return deucerto;
        }
        public void CarregaComboDespesa(ComboBox cbo)
        {
            string sQuery = null;
            sQuery = sQuery + string.Format("select HANDLE, CONVERT(VARCHAR,HANDLE)+ ' - ' +NOME AS NOME  from p_despesa  where DATA_CANCELAMENTO is null ORDER BY Nome");
            OleDbConnection DbConnection = conex.Cnncontrol();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(sQuery, DbConnection);
            da.Fill(dt);
            cbo.DataSource = dt;
            cbo.DisplayMember = "NOME";
            cbo.ValueMember = "HANDLE";
            DbConnection.Close();
        }

//============ CONTAS PAGAR =========================================
        public bool CadastraContasPagar(string Pfornecedor, string Pdocumento, string Pdata_lancamento, string Pvencimento, string Pvalor, string Ptipo, string Pdespesa, string Pdata_pagamento, string Pacrescimo, string Pdesconto, string Pvalor_pago, string Ptipo_documento, string Psituacao, string Pdata_cadastro, string Pdata_cancelamento, string Pcod_lancamento, string Pproduto)
        {
            string SQInsert = null;
            SQInsert += "INSERT INTO dbo.p_contasapagar ";
            SQInsert += "(FORNECEDOR,DOCUMENTO,DATA_LANCAMENTO,VENCIMENTO,VALOR,TIPO,DESPESA,DATA_PAGAMENTO,ACRESCIMO,DESCONTO,VALOR_PAGO,TIPO_DOCUMENTO,SITUACAO,DATA_CADASTRO,DATA_CANCELAMENTO,COD_LANCAMENTO,PRODUTO) ";
            SQInsert += " VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@FORNECEDOR", OleDbType.VarChar).Value = Pfornecedor;
            cmd.Parameters.Add("@DOCUMENTO", OleDbType.VarChar).Value = Pdocumento;
            cmd.Parameters.Add("@DATA_LANCAMENTO", OleDbType.VarChar).Value = Pdata_lancamento;
            cmd.Parameters.Add("@VENCIMENTO", OleDbType.VarChar).Value = Pvencimento;
            cmd.Parameters.Add("@VALOR", OleDbType.VarChar).Value = Pvalor;
            cmd.Parameters.Add("@TIPO", OleDbType.VarChar).Value = Ptipo;
            cmd.Parameters.Add("@DESPESA", OleDbType.VarChar).Value = Pdespesa;
            cmd.Parameters.Add("@DATA_PAGAMENTO", OleDbType.VarChar).Value = Pdata_pagamento;
            cmd.Parameters.Add("@ACRESCIMO", OleDbType.VarChar).Value = Pacrescimo;
            cmd.Parameters.Add("@DESCONTO", OleDbType.VarChar).Value = Pdesconto;
            cmd.Parameters.Add("@VALOR_PAGO", OleDbType.VarChar).Value = Pfornecedor;
            cmd.Parameters.Add("@TIPO_DOCUMENTO", OleDbType.VarChar).Value = Pvalor_pago;
            cmd.Parameters.Add("@SITUACAO", OleDbType.VarChar).Value = Psituacao;
            cmd.Parameters.Add("@DATA_CADASTRO", OleDbType.VarChar).Value = Pdata_cadastro;
            cmd.Parameters.Add("@COD_LANCAMENTO", OleDbType.VarChar).Value = Pcod_lancamento;
            cmd.Parameters.Add("@PRODUTO", OleDbType.VarChar).Value = Pproduto;
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
                conex.GeraErro("GRAVA_CONTAS_PAGAR", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
            return deucerto;
        }
        public bool AlteraContasPagar(string pcodigo,string Pfornecedor, string Pdocumento, string Pdata_lancamento, string Pvencimento, string Pvalor, string Ptipo, string Pdespesa, string Pdata_pagamento, string Pacrescimo, string Pdesconto, string Pvalor_pago, string Ptipo_documento, string Psituacao, string Pdata_cadastro, string Pdata_cancelamento, string Pcod_lancamento, string Pproduto)
        {
            string SQInsert = null;
            SQInsert += "UPDATE p_contasapagar SET ";
            SQInsert += "FORNECEDOR=?,DOCUMENTO=?,DATA_LANCAMENTO=?,VENCIMENTO=?,VALOR=?,TIPO=?,DESPESA=?,DATA_PAGAMENTO=?,ACRESCIMO=?,DESCONTO=?,VALOR_PAGO=?,TIPO_DOCUMENTO=?,SITUACAO=?,DATA_CADASTRO=?,DATA_CANCELAMENTO=?,COD_LANCAMENTO=?,PRODUTO=? ";
            SQInsert += " WHERE HANDOE = " + pcodigo;
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@FORNECEDOR", OleDbType.VarChar).Value = Pfornecedor;
            cmd.Parameters.Add("@DOCUMENTO", OleDbType.VarChar).Value = Pdocumento;
            cmd.Parameters.Add("@DATA_LANCAMENTO", OleDbType.VarChar).Value = Pdata_lancamento;
            cmd.Parameters.Add("@VENCIMENTO", OleDbType.VarChar).Value = Pvencimento;
            cmd.Parameters.Add("@VALOR", OleDbType.VarChar).Value = Pvalor;
            cmd.Parameters.Add("@TIPO", OleDbType.VarChar).Value = Ptipo;
            cmd.Parameters.Add("@DESPESA", OleDbType.VarChar).Value = Pdespesa;
            cmd.Parameters.Add("@DATA_PAGAMENTO", OleDbType.VarChar).Value = Pdata_pagamento;
            cmd.Parameters.Add("@ACRESCIMO", OleDbType.VarChar).Value = Pacrescimo;
            cmd.Parameters.Add("@DESCONTO", OleDbType.VarChar).Value = Pdesconto;
            cmd.Parameters.Add("@VALOR_PAGO", OleDbType.VarChar).Value = Pfornecedor;
            cmd.Parameters.Add("@TIPO_DOCUMENTO", OleDbType.VarChar).Value = Pvalor_pago;
            cmd.Parameters.Add("@SITUACAO", OleDbType.VarChar).Value = Psituacao;
            cmd.Parameters.Add("@DATA_CADASTRO", OleDbType.VarChar).Value = Pdata_cadastro;
            cmd.Parameters.Add("@COD_LANCAMENTO", OleDbType.VarChar).Value = Pcod_lancamento;
            cmd.Parameters.Add("@PRODUTO", OleDbType.VarChar).Value = Pproduto;
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
                conex.GeraErro("ALTERA_CONTAS_PAGAR", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
            return deucerto;
        }

//============ CONTAS RECEBER =========================================
        public bool CadastraContasReceber(string PCliente,string PTipo_Documento,string PNumero_Documento,string PVencimento_Inicial,string PVencimento_Final,string PSituacao,string PValor_Devedor,string PTotal_Liquidado)
        {
            string SQInsert = null;
            SQInsert += "INSERT INTO dbo.p_contasreceber ";
            SQInsert += "(CLIENTE,TIPO_DOCUMENTO,NUMERO_DOCUMENTO,VENCIMENTO_INICIAL,VENCIMENTO_FINAL,SITUACAO,DATA_CADASTRO,VALOR_DEVEDOR,TOTAL_LIQUIDADO) ";
            SQInsert += " VALUES (?,?,?,?,?,?,?,?,?)";
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@CLIENTE", OleDbType.VarChar).Value = PCliente;
            cmd.Parameters.Add("@TIPO_DOCUMENTO", OleDbType.VarChar).Value = PTipo_Documento;
            cmd.Parameters.Add("@NUMERO_DOCUMENTO", OleDbType.VarChar).Value = PNumero_Documento;
            cmd.Parameters.Add("@VENCIMENTO_INICIAL", OleDbType.VarChar).Value = PVencimento_Inicial;
            cmd.Parameters.Add("@VENCIMENTO_FINAL", OleDbType.VarChar).Value = PVencimento_Final;
            cmd.Parameters.Add("@SITUACAO", OleDbType.VarChar).Value = PSituacao;
            cmd.Parameters.Add("@DATA_CADASTRO", OleDbType.VarChar).Value = DateTime.Now;
            cmd.Parameters.Add("@VALOR_DEVEDOR", OleDbType.VarChar).Value = PValor_Devedor;
            cmd.Parameters.Add("@TOTAL_LIQUIDADO", OleDbType.VarChar).Value = PTotal_Liquidado;

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
                conex.GeraErro("GRAVA_CONTAS_RECEBER", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
            return deucerto;
        }
        public bool AlteraContasReceber(string pcodigo, string PCliente, string PTipo_Documento, string PNumero_Documento, string PVencimento_Inicial, string PVencimento_Final, string PSituacao, string PValor_Devedor, string PTotal_Liquidado)
        {
            string SQInsert = null;
            SQInsert += "UPDATE p_contasreceber SET ";
            SQInsert += "CLIENTE=?,TIPO_DOCUMENTO=?,NUMERO_DOCUMENTO=?,VENCIMENTO_INICIAL=?,VENCIMENTO_FINAL=?,SITUACAO=?,DATA_CADASTRO=?,VALOR_DEVEDOR=?,TOTAL_LIQUIDADO=? ";
            SQInsert += " WHERE HANDOE = " + pcodigo;
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(SQInsert, DbConnection);
            cmd.Parameters.Add("@CLIENTE", OleDbType.VarChar).Value = PCliente;
            cmd.Parameters.Add("@TIPO_DOCUMENTO", OleDbType.VarChar).Value = PTipo_Documento;
            cmd.Parameters.Add("@NUMERO_DOCUMENTO", OleDbType.VarChar).Value = PNumero_Documento;
            cmd.Parameters.Add("@VENCIMENTO_INICIAL", OleDbType.VarChar).Value = PVencimento_Inicial;
            cmd.Parameters.Add("@VENCIMENTO_FINAL", OleDbType.VarChar).Value = PVencimento_Final;
            cmd.Parameters.Add("@SITUACAO", OleDbType.VarChar).Value = PSituacao;
            cmd.Parameters.Add("@DATA_CADASTRO", OleDbType.VarChar).Value = DateTime.Now;
            cmd.Parameters.Add("@VALOR_DEVEDOR", OleDbType.VarChar).Value = PValor_Devedor;
            cmd.Parameters.Add("@TOTAL_LIQUIDADO", OleDbType.VarChar).Value = PTotal_Liquidado;
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
                conex.GeraErro("ALTERA_CONTAS_RECEBER", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }
            return deucerto;
        }
    }
}
