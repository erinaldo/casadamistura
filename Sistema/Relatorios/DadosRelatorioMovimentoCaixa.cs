using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Conn;
namespace Relatorios
{
    class DadosRelatorioMovimentoCaixa
    {
        Conn.Class1 conex = new Conn.Class1();
        private List<relatoriomovimentocaixa> m_employees;
        private List<relatoriomovimentosangriasup> m_employees2;
        public DadosRelatorioMovimentoCaixa()
        {
            m_employees = new List<relatoriomovimentocaixa>();
            m_employees2 = new List<relatoriomovimentosangriasup>();

        }
        public List<relatoriomovimentocaixa> GetEmployees()
        {
            return m_employees;
        }
        public List<relatoriomovimentosangriasup> GetEmployees2()
        {
            return m_employees2;
        }
        public List<relatoriomovimentocaixa> Carregar(string pusuario,string pdatainicial,string pdatafinal)
        {
            string sQuery = null;
            sQuery = sQuery + string.Format(" select  ");
            sQuery = sQuery + string.Format(" c.NOME usuario_caixa, ");
            sQuery = sQuery + string.Format(" a.CAIXA caixa, ");
            sQuery = sQuery + string.Format(" b.DATA_ABERTURA data_abertura_caixa, ");
            sQuery = sQuery + string.Format(" case when b.STATUS = 'A' then 'ABERTO' ");
            sQuery = sQuery + string.Format(" when  b.STATUS = 'F' then 'FECHADO' ");
            sQuery = sQuery + string.Format(" end status, ");
            sQuery = sQuery + string.Format(" a.DATA_CADASTRO data_movimento, ");
            sQuery = sQuery + string.Format(" e.NOME produto, ");
            sQuery = sQuery + string.Format(" d.VALOR, ");
            sQuery = sQuery + string.Format(" f.FORMAPAGAMENTO ");
            sQuery = sQuery + string.Format(" from p_fluxo_caixa a ");
            sQuery = sQuery + string.Format(" join p_abertura_caixa b on a.CAIXA = b.HANDLE ");
            sQuery = sQuery + string.Format(" join p_usuarios c on b.USUARIO = c.HANDLE ");
            sQuery = sQuery + string.Format(" join p_produto_fluxo_caixa d on d.FLUXO_CAIXA = a.HANDLE ");
            sQuery = sQuery + string.Format(" join p_produtos e on d.PRODUTO = e.HANDLE ");
            sQuery = sQuery + string.Format(" join p_pagamento_fluxo_caixa f on f.FLUXO_CAIXA = a.HANDLE ");
            sQuery = sQuery + string.Format("where  (CONVERT(date, a.DATA_CADASTRO) BETWEEN CONVERT(date, '" + FormataData(pdatainicial) + "') AND CONVERT(date, '" + FormataData(pdatafinal) + "')) ");
if (pusuario != "0")
{
    sQuery = sQuery + string.Format(" AND C.HANDLE = "+pusuario+" ");
}
sQuery = sQuery + string.Format("order by a.CAIXA,d.VALOR  ");
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(sQuery, DbConnection);
            OleDbDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                m_employees.Add(new relatoriomovimentocaixa(da.GetValue(0).ToString(), da.GetValue(1).ToString(), da.GetValue(2).ToString(), da.GetValue(3).ToString(), da.GetValue(4).ToString(), da.GetValue(5).ToString(), Convert.ToDouble(da.GetValue(6).ToString()), da.GetValue(7).ToString()));
            }
            DbConnection.Close();
            da.Close();
            return m_employees;
        }
        public List<relatoriomovimentosangriasup> CarregarSagria(string pusuario, string pdatainicial, string pdatafinal)
        {
            string sQuery = null;
            sQuery = sQuery + string.Format(" select  ");
            sQuery = sQuery + string.Format(" c.NOME usuario_caixa, ");
            sQuery = sQuery + string.Format(" a.CAIXA caixa, ");
            sQuery = sQuery + string.Format(" CASE WHEN G.TIPO = '1' THEN 'SANGRIA' ");
            sQuery = sQuery + string.Format(" WHEN G.TIPO = '2' THEN 'SUPRIMENTO' ");
            sQuery = sQuery + string.Format(" END tipo, ");
            sQuery = sQuery + string.Format(" g.valor ");
            sQuery = sQuery + string.Format("  ");
            sQuery = sQuery + string.Format(" from p_fluxo_caixa a ");
            sQuery = sQuery + string.Format(" join p_abertura_caixa b on a.CAIXA = b.HANDLE ");
            sQuery = sQuery + string.Format(" join p_usuarios c on b.USUARIO = c.HANDLE ");
            sQuery = sQuery + string.Format(" join p_sangria_suprimento g on g.caixa = b.HANDLE ");
            sQuery = sQuery + string.Format("where  (CONVERT(date, a.DATA_CADASTRO) BETWEEN CONVERT(date, '" + FormataData(pdatainicial) + "') AND CONVERT(date, '" + FormataData(pdatafinal) + "')) ");
            if (pusuario != "0")
            {
                sQuery = sQuery + string.Format(" AND C.HANDLE = " + pusuario + " ");
            }
            sQuery = sQuery + string.Format("order by a.CAIXA,d.VALOR  ");
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(sQuery, DbConnection);
            OleDbDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                m_employees2.Add(new relatoriomovimentosangriasup(da.GetValue(0).ToString(), da.GetValue(1).ToString(), da.GetValue(2).ToString(), Convert.ToDouble(da.GetValue(3).ToString())));
            }
            DbConnection.Close();
            da.Close();
            return m_employees2;
        }

        public String FormataData(string Date)
        {
            var data = Date.Split('/');
            return data[2]+"-"+data[1]+"-"+data[0];
        }
    }
}
