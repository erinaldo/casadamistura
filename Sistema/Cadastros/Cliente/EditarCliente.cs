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
    public partial class EditarCliente : Form
    {
        Clientes client;
        public EditarCliente(Clientes form1)
        {
            InitializeComponent();
            client = form1;
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
            dataGridView1.Columns.Add("nome", "Nome Cliente");
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
            string sql = "select * from p_clientes where DATA_CANCELAMENTO is null ";
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
            cliente cliente = new cliente();
            if ((e.ColumnIndex == 2)&&(e.RowIndex > -1))
            {
               
                cliente.seleciona(dataGridView1[0, e.RowIndex].Value.ToString());
                client.nome.Text = cliente.Vnome;
                client.datacadastro.Text = cliente.Vdatacadastro;
                client.email.Text = cliente.Vemail;
                client.cpf.Text = cliente.Vcpf;
                client.telefone.Text = cliente.Vtelefone;
                client.celular1.Text = cliente.Vcelular1;
                client.celular2.Text = cliente.Vcelular2;
                client.datanascimento.Text = cliente.Vdatanascimento;
                client.cep.Text = cliente.Vcep;
                client.endereco.Text = cliente.Vendereco;
                client.numero.Text = cliente.Vnumero;
                client.bairro.Text = cliente.Vbairro;
                client.cidade.Text = cliente.Vcidade;
                client.cboestado.SelectedItem = cliente.Vestado;
                client.informacoes.Text = cliente.Vinformacoes;
                client.codcliente.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                this.Close();
            }
            else if ((e.ColumnIndex == 3)&&(e.RowIndex > -1))
            {
                if (MessageBox.Show("CONFIRMA A EXCLUSAO DE " + dataGridView1[1, e.RowIndex].Value.ToString() + "?", "EXCLUSAO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    cliente.Deleta(dataGridView1[0, e.RowIndex].Value.ToString());
                    this.Close();
                    
                }
            }
            
        }
    }
}
