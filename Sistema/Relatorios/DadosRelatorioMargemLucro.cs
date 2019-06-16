using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conn;
using System.Data.OleDb;
namespace Relatorios
{
    class DadosRelatorioMargemLucro
    {
        Conn.Class1 conex = new Conn.Class1();
        private List<relatoriomargemlucro> m_employees;
        public DadosRelatorioMargemLucro()
        {
            m_employees = new List<relatoriomargemlucro>();

        }
        public List<relatoriomargemlucro> GetEmployees()
        {
            return m_employees;
        }
        public List<relatoriomargemlucro> Carregar(string pproduto, string pdatainicial, string pdatafinal)
        {
            string sQuery = null;
            sQuery = sQuery + string.Format(" select  ");
            sQuery = sQuery + string.Format(" b.HANDLE caixa, ");
            sQuery = sQuery + string.Format(" d.DATA_CADASTRO data_venda, ");
            sQuery = sQuery + string.Format(" e.HANDLE codigo_produto, ");
            sQuery = sQuery + string.Format(" e.CODIGO_BARRAS codigo_barras, ");
            sQuery = sQuery + string.Format(" e.NOME produto, ");
            sQuery = sQuery + string.Format(" e.PRECO_CUSTO valor_custo, ");
            sQuery = sQuery + string.Format(" e.PRECO_VENDA valor_venda, ");
            sQuery = sQuery + string.Format(" (e.PRECO_VENDA - e.PRECO_CUSTO) lucro ");
            sQuery = sQuery + string.Format("  ");
            sQuery = sQuery + string.Format(" from p_fluxo_caixa a ");
            sQuery = sQuery + string.Format(" join p_abertura_caixa b on a.CAIXA = b.HANDLE ");
            sQuery = sQuery + string.Format(" join p_usuarios c on b.USUARIO = c.HANDLE ");
            sQuery = sQuery + string.Format(" join p_produto_fluxo_caixa d on d.FLUXO_CAIXA = a.HANDLE ");
            sQuery = sQuery + string.Format(" join p_produtos e on d.PRODUTO = e.HANDLE ");
            

            sQuery = sQuery + string.Format("where  (CONVERT(varchar, d.DATA_CADASTRO, 103) BETWEEN CONVERT(date, '" + pdatainicial + "', 103) AND CONVERT(date, '" + pdatafinal + "', 103)) ");
            if (pproduto != "0")
            {
                sQuery = sQuery + string.Format(" AND e.HANDLE = " + pproduto + " ");
            }
            sQuery = sQuery + string.Format(" order by a.CAIXA,d.DATA_CADASTRO ");
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(sQuery, DbConnection);
            OleDbDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                m_employees.Add(new relatoriomargemlucro(da.GetValue(0).ToString(), da.GetValue(1).ToString(), da.GetValue(2).ToString(), da.GetValue(3).ToString(), da.GetValue(4).ToString(), Convert.ToDouble(da.GetValue(5).ToString()), Convert.ToDouble(da.GetValue(6).ToString()), Convert.ToDouble(da.GetValue(7).ToString())));
            }
            DbConnection.Close();
            da.Close();
            return m_employees;
        }
    }
}
