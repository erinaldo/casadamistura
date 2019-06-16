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
using System.IO;

namespace PDV
{
    public partial class EditarProduto : Form
    {
        PontoVenda venda;
        public EditarProduto(PontoVenda form1)
        {
            InitializeComponent();
            venda = form1;
        }
        public string vbuscaproduto;
        System.Drawing.Color back = System.Drawing.ColorTranslator.FromHtml("#CFE8F5");
        System.Drawing.Color backgroup = System.Drawing.ColorTranslator.FromHtml("#E3E9D2");
        Conn.Class1 conex = new Class1();
        private void EditarProduto_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            panel1.Width = w - 20;
            panel1.Height = h - 20;
            this.BackColor = back;
            #region CarregaGrid
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridView1.Columns.Add("cod", "Código");
            dataGridView1.Columns.Add("nome", "Nome");
            dataGridView1.Columns.Add("Valor", "Valor");
            dataGridView1.Columns.Add("codbarras", "Código Barras");
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 440;
            //  gridfilacliente.Columns[3].Visible = false;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            #endregion
            
            CarregaGrid(nome.Text);
            nome.Focus();
            nome.Select();

        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void CarregaGrid(string pnome)
        {
            dataGridView1.Rows.Clear();
            OleDbConnection conexao = conex.Cnncontrol();
            string sql = "select * from p_produtos where DATA_CANCELAMENTO is null ";
            if (pnome != "")
            {
                sql += " and NOME like '" + pnome + "%'";
            }
            sql += " order by NOME";
            OleDbCommand commS = new OleDbCommand(sql, conexao);
            OleDbDataReader da = commS.ExecuteReader();
            while (da.Read())
            {
                dataGridView1.Rows.Add(da["HANDLE"].ToString(), da["NOME"].ToString(), da["PRECO_VENDA"].ToString(), da["CODIGO_BARRAS"].ToString());
            }
            nome.Focus();
        }
        private void nome_TextChanged(object sender, EventArgs e)
        {
            CarregaGrid(nome.Text);
        }
        private void EditarProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                int linha;
                int coluna;
                string valor;
                coluna = dataGridView1.CurrentCell.ColumnIndex;
                linha = dataGridView1.CurrentCell.RowIndex;
                if (linha > 0)
                {
                    valor = dataGridView1[3, linha-1].Value.ToString(); //dataGridView1.Rows[linha - 1].Cells[3].Value.ToString();
                }
                else
                {
                    valor = dataGridView1[3, linha].Value.ToString(); //dataGridView1.Rows[linha - 1].Cells[3].Value.ToString();
                }
                
                vbuscaproduto = valor;
                Close();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            vbuscaproduto = dataGridView1[3, e.RowIndex].Value.ToString();
            Close();
        }
    }
}
