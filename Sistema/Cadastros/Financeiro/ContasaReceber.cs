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
namespace Cadastros
{
    public partial class ContasaReceber : Form
    {
        public ContasaReceber()
        {
            InitializeComponent();
        }
        cliente cli = new cliente();
        Financeiro finan = new Financeiro();
        Conn.Class1 conex = new Class1();
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void ContasaReceber_Load(object sender, EventArgs e)
        {
            #region CarregaGrid
           // dg.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dg.DefaultCellStyle.ForeColor = Color.AliceBlue;
            dg.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //dg.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dg.Columns.Add("cod", "Código");
            dg.Columns.Add("cliente", "Cliente");
            dg.Columns.Add("datavenda", "Data Venda");
            dg.Columns.Add("datavencimento", "Data Vencimento");
            dg.Columns.Add("pago", "Pago");
            dg.Columns.Add("datapagamento", "Data Pagamento");
            dg.Columns.Add("parcela", "Parcela");
            dg.Columns.Add("valor", "Valor");
            dg.Columns.Add("juros", "Juros");
            dg.Columns.Add("total", "Total");
            dg.Columns[1].Width = 140;
            dg.Columns[4].Width = 40;
            dg.Columns[8].Width = 40;
            dg.Columns[0].Visible = false;
            dg.Columns[0].ReadOnly = true;
            dg.Columns[1].ReadOnly = true;
            dg.Columns[3].ReadOnly = true;
            dg.Columns[4].ReadOnly = true;
            dg.Columns[5].ReadOnly = true;
            dg.Columns[6].ReadOnly = true;
            dg.Columns[7].ReadOnly = true;
            dg.Columns[8].ReadOnly = true;
            dg.Columns[9].ReadOnly = true;

            #endregion
            cli.Carrega_Combos_cliente(cbocliente);
            codigo.Text = "";
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (codigo.Text == "")
            {
                if (finan.CadastraContasReceber(cbocliente.SelectedValue.ToString(), tipodoc.Text, numdoc.Text, datainicial.Text, datafinal.Text, "Aberto", totaldevedor.Text, totalliquidado.Text))
                {

                }
            }
            else
            {

            }
        }
        private void CarregaGrid(string pcodigo)
        {
            dg.Rows.Clear();
            OleDbConnection conexao = conex.Cnncontrol();
            string sql = "select * from p_contasreceber where DATA_CANCELAMENTO is null ";
            if (pcodigo != "")
            {
                sql += "and  cliente like '" + pcodigo + "%'";
            }
            sql += " order by NOME";
            OleDbCommand commS = new OleDbCommand(sql, conexao);
            OleDbDataReader da = commS.ExecuteReader();
            while (da.Read())
            {
                dg.Rows.Add(da["HANDLE"].ToString(), da["NOME"].ToString());
            }

        }
        private void totalselecionado_TextChanged(object sender, EventArgs e)
        {
            conex.FormataModeda(totalselecionado);
        }
        private void totaldevedor_TextChanged(object sender, EventArgs e)
        {
            conex.FormataModeda(totaldevedor);
        }
        private void totalliquidado_Validated(object sender, EventArgs e)
        {

        }
        private void totalliquidado_TextChanged(object sender, EventArgs e)
        {
            conex.FormataModeda(totalliquidado);
        }
        private void totalgeral_TextChanged(object sender, EventArgs e)
        {
            conex.FormataModeda(totalgeral);
        }
    }
}
