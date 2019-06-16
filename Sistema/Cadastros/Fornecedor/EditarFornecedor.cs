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
    public partial class EditarFornecedor : Form
    {
        Fornecedor forn;
        public EditarFornecedor(Fornecedor form1)
        {
            InitializeComponent();
            forn = form1;
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
            this.BackColor = back;
            #region CarregaGrid
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridView1.Columns.Add("cod", "Código");
            dataGridView1.Columns.Add("nome", "Nome");
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 440;
            //  gridfilacliente.Columns[3].Visible = false;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            img.Image = Properties.Resources.pesquisa;
            img.HeaderText = "Alterar";
            img.Name = "Alterar";
            img1.Image = Properties.Resources.minidel;
            img1.HeaderText = "Remover";
            img1.Name = "Remover";
            dataGridView1.Columns.Add(img);
            dataGridView1.Columns.Add(img1);   
            #endregion
            CarregaGrid(nome.Text);
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void CarregaGrid(string pnome)
        {
            dataGridView1.Rows.Clear();
            OleDbConnection conexao = conex.Cnncontrol();
            string sql = "select * from p_fornecedor where DATA_CANCELAMENTO is null ";
            if (pnome != "")
            {
                sql += "and NOME like '" + pnome + "%'";
            }
            sql += " order by NOME";
            OleDbCommand commS = new OleDbCommand(sql, conexao);
            OleDbDataReader da = commS.ExecuteReader();
            while (da.Read())
            {
                dataGridView1.Rows.Add(da["HANDLE"].ToString(), da["NOME"].ToString());
            }
        
        }
        private void nome_TextChanged(object sender, EventArgs e)
        {
            CarregaGrid(nome.Text);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fornecedores a = new fornecedores();
            if ((e.ColumnIndex == 2)&&(e.RowIndex > -1))
            {

               a.seleciona(dataGridView1[0, e.RowIndex].Value.ToString());
               forn.nome.Text = a.vnome;
               forn.responsavel1.Text = a.vresponsavel1;
               forn.responsavel2text.Text = a.vresponsavel2;
               forn.email.Text = a.vemail;
               forn.cpf.Text = a.vcpf;
               forn.telefone.Text = a.vtelefone;
               forn.celular1.Text = a.vcelular1;
               forn.celular2.Text = a.vcelular2;
               forn.cep.Text = a.vcep;
               forn.endereco.Text = a.vendereco;
               forn.numero.Text = a.vnumero;
               forn.bairro.Text = a.vbairro;
               forn.cidade.Text = a.vcidade;
               forn.cboestado.SelectedItem = a.vestado;
               forn.informacoes.Text = a.vinformacoes;
               forn.codfornecedor.Text = dataGridView1[0, e.RowIndex].Value.ToString();
               this.Close();
                this.Close();
            }
            else if ((e.ColumnIndex == 3)&&(e.RowIndex > -1))
            {
                if (MessageBox.Show("CONFIRMA A EXCLUSAO DE " + dataGridView1[1, e.RowIndex].Value.ToString() + "?", "EXCLUSAO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    a.Deleta(dataGridView1[0, e.RowIndex].Value.ToString());
                    this.Close();
                    
                }
            }
            
        }
    }
}
