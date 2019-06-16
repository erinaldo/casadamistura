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
    public partial class Despesas : Form
    {
        ContasPagar Contaspagar;
        public Despesas(ContasPagar Form)
        {
            InitializeComponent();
            Contaspagar = Form;
        }
        Conn.Class1 conex = new Class1();
        Financeiro financ = new Financeiro();
        DataGridViewImageColumn img = new DataGridViewImageColumn();
        DataGridViewImageColumn img1 = new DataGridViewImageColumn();
        private void Despesas_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            panel1.Width = w - 20;
            panel1.Height = h - 20;
            pictureBox1.Width = panel1.Width;
            pictureBox2.BackColor = System.Drawing.Color.Transparent;
            pictureBox2.Parent = pictureBox1;
            pictureBox4.BackColor = System.Drawing.Color.Transparent;
            pictureBox4.Parent = pictureBox1;
            //pictureBox5.BackColor = System.Drawing.Color.Transparent;
            //pictureBox5.Parent = pictureBox1;
            pictureBox6.BackColor = System.Drawing.Color.Transparent;
            pictureBox6.Parent = pictureBox1;
            this.BackColor = conex.Fundo();
            groupBox1.BackColor = conex.FundoGrupo();
            #region CarregaGrid
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridView1.Columns.Add("cod", "Código");
            dataGridView1.Columns.Add("nome", "Nome");
            img.Image = Properties.Resources.pesquisa;
            img.HeaderText = "Alterar";
            img.Name = "Alterar";
            img1.Image = Properties.Resources.minidel;
            img1.HeaderText = "Remover";
            img1.Name = "Remover";
            dataGridView1.Columns.Add(img);
            dataGridView1.Columns.Add(img1);
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 440;
            dataGridView1.Columns[2].Width = 70;
            dataGridView1.Columns[3].Width = 70;
            //  gridfilacliente.Columns[3].Visible = false;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;

            #endregion
            CarregaGrid();
            coddespesa.Text = "";

        }
        private void CarregaGrid()
        {
            dataGridView1.Rows.Clear();
            OleDbConnection conexao = conex.Cnncontrol();
            string sql = "select * from p_despesa where DATA_CANCELAMENTO is null ";
            sql += " order by NOME";
            OleDbCommand commS = new OleDbCommand(sql, conexao);
            OleDbDataReader da = commS.ExecuteReader();
            while (da.Read())
            {
                dataGridView1.Rows.Add(da["HANDLE"].ToString(), da["NOME"].ToString());
            }

        }
        #region AMARELO FOCUS
        private void nome_Enter(object sender, EventArgs e)
        {
            nome.BackColor = conex.amarelo();
        }
        private void nome_Leave(object sender, EventArgs e)
        {
            nome.BackColor = conex.branco();
        }
        #endregion
        private bool ValidaCampos()
        {
            bool grava;
            if (nome.TextLength < 3)
            {
                MessageBox.Show("Nome muito curto", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nome.Focus();
                grava = false;
            }
            else
            {
                grava = true;
            }
            return grava;

        }
        private void Grava()
        {
            if (ValidaCampos())
            {
                
                if (coddespesa.Text == "")
                {
                    if (financ.CadastraDespesa(nome.Text))
                    {
                        CarregaGrid();
                        financ.CarregaComboDespesa(Contaspagar.cbodespesa);
                        conex.LimpaTextBoxes(this.Controls);
                        coddespesa.Text = "";
                    }
                }
                else
                {
                    {
                        if (financ.AlteraDespesa(coddespesa.Text, nome.Text))
                         CarregaGrid();
                        conex.LimpaTextBoxes(this.Controls);
                        coddespesa.Text = "";
                    }
                }

            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 2) && (e.RowIndex > -1))
            {
                financ.SelecionaDespesa(dataGridView1[0, e.RowIndex].Value.ToString());
                nome.Text = financ.vnome;
                coddespesa.Text = financ.vcodigo;
            }
            else if ((e.ColumnIndex == 3) && (e.RowIndex > -1))
            {
                if (MessageBox.Show("CONFIRMA A EXCLUSAO DE " + dataGridView1[1, e.RowIndex].Value.ToString() + "?", "EXCLUSAO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    financ.DeletaDespesa(dataGridView1[0, e.RowIndex].Value.ToString());
                    CarregaGrid();
                }
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Grava();
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
