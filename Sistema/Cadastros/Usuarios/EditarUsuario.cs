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
    public partial class EditarUsuario : Form
    {
        FormUsuario Usert;
        public EditarUsuario(FormUsuario form1)
        {
            InitializeComponent();
            Usert = form1;
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
            string sql = "select * from dbo.p_usuarios where DATA_CANCELAMENTO is null ";
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
            usuario a = new usuario();
            if ((e.ColumnIndex == 2)&&(e.RowIndex > -1))
            {
                a.seleciona(dataGridView1[0, e.RowIndex].Value.ToString());
                
                Usert.nome.Text = a.Vnome;
                Usert.datacadastro.Text = a.Vdatacadastro;
                Usert.email.Text = a.Vemail;
                Usert.cpf.Text = a.Vcpf;
                Usert.telefone.Text = a.Vtelefone;
                Usert.celular1.Text = a.Vcelular1;
                Usert.celular2.Text = a.Vcelular2;
                Usert.datanascimento.Text = a.Vdatanascimento;
                Usert.cep.Text = a.Vcep;
                Usert.endereco.Text = a.Vendereco;
                Usert.numero.Text = a.Vnumero;
                Usert.bairro.Text = a.Vbairro;
                Usert.cidade.Text = a.Vcidade;
                Usert.cboestado.SelectedItem = a.Vestado;
                Usert.informacoes.Text = a.Vinformacoes;
                Usert.senha.Text  = a.vsenha;
                Usert.login.Text = a.vlogin;
                Usert.cboperfil.SelectedValue = a.vfuncao;
                Usert.codusuario.Text = dataGridView1[0, e.RowIndex].Value.ToString();
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
