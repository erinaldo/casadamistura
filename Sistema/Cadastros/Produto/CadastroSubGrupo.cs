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
    public partial class CadastroSubGrupo : Form
    {
        public CadastroSubGrupo()
        {
            InitializeComponent();
        }

        DataGridViewImageColumn img = new DataGridViewImageColumn();
        DataGridViewImageColumn img1 = new DataGridViewImageColumn();
        System.Drawing.Color back = System.Drawing.ColorTranslator.FromHtml("#CFE8F5");
        System.Drawing.Color backgroup = System.Drawing.ColorTranslator.FromHtml("#E3E9D2");
        Conn.Class1 conex = new Class1();
        private void CadastroGrupo_Load(object sender, EventArgs e)
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
            this.BackColor = back;
            groupBox1.BackColor = backgroup;
            #region CarregaGrid
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridView1.Columns.Add("cod", "Código");
            dataGridView1.Columns.Add("nome", "Nome");
            dataGridView1.Columns.Add("grupo", "Grupo");
            img.Image = Properties.Resources.pesquisa;
            img.HeaderText = "Alterar";
            img.Name = "Alterar";
            img1.Image = Properties.Resources.minidel;
            img1.HeaderText = "Remover";
            img1.Name = "Remover";
            dataGridView1.Columns.Add(img);
            dataGridView1.Columns.Add(img1);
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 240;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 80;
            //  gridfilacliente.Columns[3].Visible = false;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            #endregion
            Carregagrupo();
            CarregaGrid();
            datacadastro.Text = DateTime.Now.ToShortDateString();
            codsubgrupo.Text = "";
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Grava();
        }
        #region FOCUS AMARELO
        private void datacadastro_Leave(object sender, EventArgs e)
        {
            datacadastro.BackColor = conex.branco();
        }
        private void datacadastro_Enter(object sender, EventArgs e)
        {
            datacadastro.BackColor = conex.amarelo();
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.BackColor = conex.branco();
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.BackColor = conex.amarelo();
        }
        private void cbogrupo_Leave(object sender, EventArgs e)
        {
            cbogrupo.BackColor = conex.branco();
        }
        private void cbogrupo_Enter(object sender, EventArgs e)
        {
            cbogrupo.BackColor = conex.amarelo();
        }
        private void informacoes_Leave(object sender, EventArgs e)
        {
            informacoes.BackColor = conex.branco();
        }
        private void informacoes_Enter(object sender, EventArgs e)
        {
            informacoes.BackColor = conex.amarelo();
        }
        #endregion

        private void Carregagrupo()
        {
            string sQuery = null;
            sQuery = sQuery + string.Format("SELECT HANDLE,NOME,CONVERT(varchar,HANDLE) +' - '+ NOME tipos FROM p_grupo ORDER BY HANDLE");

            OleDbConnection DbConnection = conex.Cnncontrol();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(sQuery, DbConnection);
            da.Fill(dt);
            cbogrupo.DataSource = dt;
            cbogrupo.DisplayMember = "tipos";
            cbogrupo.ValueMember = "HANDLE";
            DbConnection.Close();
        }
        private void CarregaGrid()
        {
            dataGridView1.Rows.Clear();
            OleDbConnection conexao = conex.Cnncontrol();
            string sql = "select A.HANDLE HANDLE,A.NOME NOME ,B.NOME GRUPO from p_subgrupo a ";
            sql += " join p_grupo b on a.grupo = b.handle where a.DATA_CANCELAMENTO is null ";
            sql += " order by a.NOME";
            OleDbCommand commS = new OleDbCommand(sql, conexao);
            OleDbDataReader da = commS.ExecuteReader();
            while (da.Read())
            {
                dataGridView1.Rows.Add(da["HANDLE"].ToString(), da["NOME"].ToString(), da["GRUPO"].ToString());
            }

        }
        private void datacadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                conex.Formada_data(datacadastro);
            }
            else
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void Grava()
        {
            if (ValidaCampos())
            {

                subgrupo subgrupo = new subgrupo();
                if(codsubgrupo.Text == "")
                {
                    if (subgrupo.Cadastra(textBox2.Text, informacoes.Text, Convert.ToInt32(cbogrupo.SelectedValue), datacadastro.Text))
                    {
                        CarregaGrid();
                        codsubgrupo.Text = "";
                        conex.LimpaTextBoxes(this.Controls);
                    }
                }
                else
                {
                    if (subgrupo.Altera(codsubgrupo.Text,textBox2.Text, informacoes.Text, Convert.ToInt32(cbogrupo.SelectedValue), datacadastro.Text))
                {
                    CarregaGrid();
                    codsubgrupo.Text = "";
                    conex.LimpaTextBoxes(this.Controls);
                }
                }
            }
        }
        private bool ValidaCampos()
        {
            bool grava;
            if (!conex.Checadata(datacadastro))
            {
                MessageBox.Show("Data Cadastro inválida", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                datacadastro.Focus();
                grava = false;
            }
            else if (textBox2.TextLength < 3)
            {
                MessageBox.Show("Nome muito curto", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
                grava = false;
            }
            else
            {
                grava = true;
            }
            return grava;

        }
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            conex.LimpaTextBoxes(this.Controls);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            subgrupo a = new subgrupo();
            if ((e.ColumnIndex == 3) && (e.RowIndex > -1))
            {

                a.Seleciona(dataGridView1[0, e.RowIndex].Value.ToString());

                datacadastro.Text = a.Vdatacadastro;
                textBox2.Text = a.Vnome;
                informacoes.Text = a.Vinformacoes;
                cbogrupo.SelectedValue = a.Vgrupo;
                codsubgrupo.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            }
            else if ((e.ColumnIndex == 4) && (e.RowIndex > -1))
            {
                if(!a.ConsultaAntes_Deletar(dataGridView1[0, e.RowIndex].Value.ToString()))
                {
                    if (MessageBox.Show("CONFIRMA A EXCLUSAO DE " + dataGridView1[1, e.RowIndex].Value.ToString() + "?", "EXCLUSAO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        a.Deleta(dataGridView1[0, e.RowIndex].Value.ToString());
                        CarregaGrid();

                    }
                }
            }
        }
    }
}
