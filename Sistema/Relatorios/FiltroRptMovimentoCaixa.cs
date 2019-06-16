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
    public partial class FiltroRptMovimentoCaixa : Form
    {
        public FiltroRptMovimentoCaixa()
        {
            InitializeComponent();
        }
        Conn.Class1 conex = new Conn.Class1();
        private void FiltroRptMovimentoCaixa_Load(object sender, EventArgs e)
        {
            this.BackColor = conex.Fundo();
            CarregaComboCaixa();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Relatorio_Caixa relatoriomovicaixa = new Relatorio_Caixa();
            relatoriomovicaixa.Vusuario = cbofuncionario.SelectedValue.ToString();
            relatoriomovicaixa.Vdatainicial = datainicial.Text;
            relatoriomovicaixa.Vdatafinal = datafinal.Text;
            relatoriomovicaixa.ShowDialog();
        }
        private void CarregaComboCaixa()
        {
            string sQuery = null;
            sQuery = sQuery + string.Format("select distinct b.HANDLE,b.NOME from p_abertura_caixa a ");
            sQuery = sQuery + string.Format("join p_usuarios b on a.USUARIO = b.HANDLE ");
            sQuery = sQuery + string.Format(" and b.data_cancelamento is null");
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
            cbofuncionario.DataSource = list;
            cbofuncionario.DisplayMember = "NOME";
            cbofuncionario.ValueMember = "HANDLE";
            DbConnection.Close();
            da.Close();
        }

        private void FiltroRptMovimentoCaixa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Relatorio_Caixa relatoriomovicaixa = new Relatorio_Caixa();
                relatoriomovicaixa.Vusuario = cbofuncionario.SelectedValue.ToString();
                relatoriomovicaixa.Vdatainicial = datainicial.Text;
                relatoriomovicaixa.Vdatafinal = datafinal.Text;
                relatoriomovicaixa.ShowDialog();
            }
        }
    }
}
