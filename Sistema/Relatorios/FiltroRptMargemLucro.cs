using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Conn;
using System.Data.OleDb;
namespace Relatorios
{
    public partial class FiltroRptMargemLucro : Form
    {
        public FiltroRptMargemLucro()
        {
            InitializeComponent();
        }
        Conn.Class1 conex = new Conn.Class1();
        private void FiltroRptMargemLucro_Load(object sender, EventArgs e)
        {
            this.BackColor = conex.Fundo();
            CarregaComboProduto();
        }
        private void CarregaComboProduto()
        {
            string sQuery = null;
            sQuery = sQuery + string.Format("select a.HANDLE,a.NOME from p_produtos a ");
            sQuery = sQuery + string.Format(" where a.data_cancelamento is null");
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(sQuery, DbConnection);
            OleDbDataReader da = cmd.ExecuteReader();
            List<Preenchecombo> list = new List<Preenchecombo>();
            Preenchecombo caixa = new Preenchecombo();
            caixa.HANDLE = 0;
            caixa.NOME = "TODOS";
            list.Add(caixa);
            while (da.Read())
            {
                Preenchecombo caixas = new Preenchecombo();
                caixas.HANDLE = Convert.ToInt32(da.GetValue(0));
                caixas.NOME = da.GetValue(1).ToString();
                list.Add(caixas);
            }
            cboproduto.DataSource = list;
            cboproduto.DisplayMember = "NOME";
            cboproduto.ValueMember = "HANDLE";
            DbConnection.Close();
            da.Close();
        }

        private void FiltroRptMargemLucro_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (e.KeyChar == (char)13)
            {

                Relatorio_Lucro relatoriolucro = new Relatorio_Lucro();
                relatoriolucro.Vproduto = cboproduto.SelectedValue.ToString();
                relatoriolucro.Vdatainicial = datainicial.Text;
                relatoriolucro.Vdatafinal = datafinal.Text;
                relatoriolucro.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Relatorio_Lucro relatoriolucro = new Relatorio_Lucro();
            relatoriolucro.Vproduto = cboproduto.SelectedValue.ToString();
            relatoriolucro.Vdatainicial = datainicial.Text;
            relatoriolucro.Vdatafinal = datafinal.Text;
            relatoriolucro.ShowDialog();
        }
    }
}
