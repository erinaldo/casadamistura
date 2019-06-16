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
    public partial class Clientes : Form
    {
        public Clientes()
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

            datacadastro.Text = DateTime.Now.ToShortDateString();
            this.BackColor = conex.Fundo();
            groupBox1.BackColor = conex.FundoGrupo();
            groupBox2.BackColor = conex.FundoGrupo();
            groupBox3.BackColor = conex.FundoGrupo();
            groupBox4.BackColor = conex.FundoGrupo();
            codcliente.Text = "";

        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

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
        private void cep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Grava();
            
        }
        private void cpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
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
        private void datanascimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                conex.Formada_data(datanascimento);
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
                cliente cliente = new cliente();
                if (codcliente.Text == "")
                {
                    cliente.Cadastra(nome.Text, email.Text, cpf.Text, telefone.Text, celular1.Text, celular2.Text, datanascimento.Text, cep.Text, endereco.Text,numero.Text, bairro.Text, cidade.Text, cboestado.Text, informacoes.Text, datacadastro.Text);
                    conex.LimpaTextBoxes(this.Controls);
                    codcliente.Text = "";
                }
                else
                {
                    cliente.Altera(codcliente.Text,nome.Text, email.Text, cpf.Text, telefone.Text, celular1.Text, celular2.Text, datanascimento.Text, cep.Text, endereco.Text,numero.Text, bairro.Text, cidade.Text, cboestado.Text, informacoes.Text, datacadastro.Text);
                    conex.LimpaTextBoxes(this.Controls);
                    codcliente.Text = "";
                }

            }            
        }
        private bool ValidaCampos()
        {
            bool grava;
            if (!conex.Checadata(datacadastro))
            {
                MessageBox.Show("Data Cadastro inválida", "ATENÇÃO", MessageBoxButtons.OK,MessageBoxIcon.Error);
                datacadastro.Focus();
                grava = false;
            }
            else if (!conex.Checadata(datanascimento))
            {
                MessageBox.Show("Data nascimento inválida", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                datanascimento.Focus();
                grava = false;
            }
            else if (nome.TextLength < 3)
            {
                MessageBox.Show("Nome muito curto", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nome.Focus();
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
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            EditarCliente editar = new EditarCliente(this);
            editar.ShowDialog();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            EditarCliente editar = new EditarCliente(this);
            editar.ShowDialog();
        }
        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Grava();
            conex.LimpaTextBoxes(this.Controls);
        }

        #region AMARELO_FOCUS
        private void datacadastro_Enter(object sender, EventArgs e)
        {
            datacadastro.BackColor = conex.amarelo();
        }
        private void datacadastro_Leave(object sender, EventArgs e)
        {
            datacadastro.BackColor = conex.branco();;
        }
        private void nome_Leave(object sender, EventArgs e)
        {
            nome.BackColor = conex.branco();;
        }
        private void nome_Enter(object sender, EventArgs e)
        {
            nome.BackColor = conex.amarelo();;
        }
        private void email_Enter(object sender, EventArgs e)
        {
            email.BackColor = conex.amarelo();;
        }
        private void email_Leave(object sender, EventArgs e)
        {
            email.BackColor = conex.branco();;
        }
        private void cpf_Leave(object sender, EventArgs e)
        {
            cpf.Text = conex.MascaraCnpjCpf(cpf.Text);
            cpf.BackColor = conex.branco();;
        }
        private void cpf_Enter(object sender, EventArgs e)
        {
            cpf.BackColor = conex.amarelo();;
        }
        private void telefone_Enter(object sender, EventArgs e)
        {
            telefone.BackColor = conex.amarelo();;
        }
        private void telefone_Leave(object sender, EventArgs e)
        {
            telefone.BackColor = conex.branco();;
        }
        private void celular1_Leave(object sender, EventArgs e)
        {
            celular1.BackColor = conex.branco();;
        }
        private void celular1_Enter(object sender, EventArgs e)
        {
            celular1.BackColor = conex.amarelo();;
        }
        private void celular2_Leave(object sender, EventArgs e)
        {
            celular2.BackColor = conex.branco();;
        }
        private void celular2_Enter(object sender, EventArgs e)
        {
            celular2.BackColor = conex.amarelo();;
        }
        private void datanascimento_Leave(object sender, EventArgs e)
        {
            datanascimento.BackColor = conex.branco();;
        }
        private void datanascimento_Enter(object sender, EventArgs e)
        {
            datanascimento.BackColor = conex.amarelo();;
        }
        private void cep_Leave(object sender, EventArgs e)
        {
            cep.BackColor = conex.branco();;
        }
        private void cep_Enter(object sender, EventArgs e)
        {
            cep.BackColor = conex.amarelo();;
        }
        private void endereco_Leave(object sender, EventArgs e)
        {
            endereco.BackColor = conex.branco();;
        }
        private void endereco_Enter(object sender, EventArgs e)
        {
            endereco.BackColor = conex.amarelo();;
        }
        private void numero_Leave(object sender, EventArgs e)
        {
            numero.BackColor = conex.branco();;
        }
        private void numero_Enter(object sender, EventArgs e)
        {
            numero.BackColor = conex.amarelo();;
        }
        private void bairro_Leave(object sender, EventArgs e)
        {
            bairro.BackColor = conex.branco();;
        }
        private void bairro_Enter(object sender, EventArgs e)
        {
            bairro.BackColor = conex.amarelo();;
        }
        private void cidade_Enter(object sender, EventArgs e)
        {
            cidade.BackColor = conex.amarelo();;
        }
        private void cidade_Leave(object sender, EventArgs e)
        {
            cidade.BackColor = conex.branco();;
        }
        private void cboestado_Leave(object sender, EventArgs e)
        {
            cboestado.BackColor = conex.branco();;
        }
        private void cboestado_Enter(object sender, EventArgs e)
        {
            cboestado.BackColor = conex.amarelo();;
        }
        private void informacoes_Enter(object sender, EventArgs e)
        {
            informacoes.BackColor = conex.amarelo();;
        }
        private void informacoes_Leave(object sender, EventArgs e)
        {
            informacoes.BackColor = conex.branco();;
        }
        #endregion

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void cep_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (button1.Text == "Carregar IMG")
                {
                    minhaWebCamComp1.Start();
                    button1.Text = "OK";
                }
                else
                {
                    minhaWebCamComp1.Stop();
                    button1.Text = "Carregar IMG";
                }

            }
            else
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "jpg|*.jpg";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    minhaWebCamComp1.ImgWebCam.ImageLocation = file.FileName;
                    minhaWebCamComp1.ImgWebCam.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    minhaWebCamComp1.Stop();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            minhaWebCamComp1.ImgWebCam.Image = null;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }


    }
}
