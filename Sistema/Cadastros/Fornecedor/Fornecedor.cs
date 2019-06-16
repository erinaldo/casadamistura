using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Conn;
namespace Cadastros
{
    public partial class Fornecedor : Form
    {
        public Fornecedor()
        {
            InitializeComponent();
        }
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
            pictureBox5.BackColor = System.Drawing.Color.Transparent;
            pictureBox5.Parent = pictureBox1;
            pictureBox6.BackColor = System.Drawing.Color.Transparent;
            pictureBox6.Parent = pictureBox1;
            this.BackColor = conex.Fundo();
            groupBox2.BackColor = conex.FundoGrupo();
            groupBox3.BackColor = conex.FundoGrupo();
            groupBox4.BackColor = conex.FundoGrupo();
            codfornecedor.Text = "";

        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (cep.TextLength == 8)
            {
                string[] ende;
                string[] logradouro;
                ende = conex.BuscaCep(cep.Text);
                if (ende != null)
                {
                    logradouro = ende[0].Trim().Split('-');
                    endereco.Text = logradouro[0];
                    bairro.Text = ende[1].Trim();
                    cidade.Text = ende[2].Trim();
                    cboestado.SelectedItem = ende[3].Trim();
                }
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Grava();

        }
        private bool ValidaCampos()
        {
            bool grava;
            if (nome.TextLength < 3)
            {
                MessageBox.Show("Nome muito curto", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nome.Focus();
                grava = false;
            }
            else if (responsavel1.TextLength < 3)
            {
                MessageBox.Show("Responsavel inválido", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                responsavel1.Focus();
                grava = false;
            }
            else if (email.Text.IndexOf("@") < 0)
            {
                MessageBox.Show("E-mail incorreto", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                email.Focus();
                grava = false;
            }
            else if (telefone.TextLength < 8)
            {
                MessageBox.Show("Telefone errado", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                telefone.Focus();
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
                fornecedores fornecedor = new fornecedores();
                if (codfornecedor.Text == "")
                {
                    if(fornecedor.Cadastra(DateTime.Now.ToString(),nome.Text,responsavel1.Text,responsavel2text.Text,email.Text,cpf.Text,telefone.Text,celular1.Text,celular2.Text,cep.Text,endereco.Text,numero.Text,bairro.Text,cidade.Text,cboestado.Text,informacoes.Text)){
                        conex.LimpaTextBoxes(this.Controls);
                        codfornecedor.Text = "";
                    }
                }
                else
                {
                    if(fornecedor.Altera(
                        codfornecedor.Text,
                        DateTime.Now.ToString(),
                        nome.Text,
                        responsavel1.Text,
                        responsavel2text.Text,
                        email.Text,
                        cpf.Text,
                        telefone.Text,
                        celular1.Text,
                        celular2.Text,
                        cep.Text,
                        endereco.Text,
                        numero.Text,
                        bairro.Text,
                        cidade.Text,
                        cboestado.Text,
                        informacoes.Text)){
                            conex.LimpaTextBoxes(this.Controls);
                            codfornecedor.Text = "";
                        }
                }
            }
        }
        private void cep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void cpf_Leave(object sender, EventArgs e)
        {
            cpf.Text = conex.MascaraCnpjCpf(cpf.Text);
        }
        private void cpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            EditarFornecedor edit = new EditarFornecedor(this);
            edit.ShowDialog();
        }
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            conex.LimpaTextBoxes(this.Controls);
            codfornecedor.Text = "";
        }
        private void celular1_TextChanged(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
