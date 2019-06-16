using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Conn;
namespace PDV
{
    public partial class SangriaSuprimento : Form
    {
        PontoVenda Pdv;
        public SangriaSuprimento(PontoVenda frm1)
        {
            InitializeComponent();
            Pdv = frm1;
        }
        private int IRetorno;
        System.Drawing.Color back = System.Drawing.ColorTranslator.FromHtml("#CFE8F5");
        Conn.Class1 conex = new Class1();
        private void SangriaSuprimento_Load(object sender, EventArgs e)
        {
            this.BackColor = back;
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.BackColor = conex.branco();
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.BackColor = conex.amarelo();
        }
        private void valor_TextChanged(object sender, EventArgs e)
        {
            conex.FormataModeda(valor);
        }
        private void valor_Leave(object sender, EventArgs e)
        {
            valor.BackColor = conex.branco();
        }
        private void valor_Enter(object sender, EventArgs e)
        {
            valor.BackColor = conex.amarelo();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter)
            {
                conex.ChecaNumero(e);
            }
        }
        private void SangriaSuprimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text == "1")
                {
                    label2.Text = "Sangria";
                    valor.Focus();
                }
                else if (textBox1.Text == "2")
                {
                    valor.Focus();
                    label2.Text = "Suprimento";
                }
                else
                {
                    MessageBox.Show("FAVOR INFORMAR ENTRE 1 OU 2");
                    textBox1.Text = "";
                    textBox1.Focus();
                }
                    
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void valor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if ((textBox1.Text != ""))
                {
                    if (Convert.ToDouble(valor.Text) > 0)
                    {
                        if (MessageBox.Show("DESEJA EFETUAR A " + label2.Text.ToUpper() + " ?", "ATENÇÂO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            SenhaGerencia senha = new SenhaGerencia();
                            senha.ShowDialog();
                            if (senha.confirmado)
                            {
                                Class2 classe = new Class2();
                                classe.CadastraSangriaSuprimento(textBox1.Text, Convert.ToDouble(valor.Text), Pdv.lcaixa.Text);
                                if (label2.Text == "Sangria")
                                {
                                    IRetorno = BemaFI32.Bematech_FI_Sangria(valor.Text);
                                }
                                else if (label2.Text == "Suprimento")
                                {
                                    IRetorno = BemaFI32.Bematech_FI_Suprimento(valor.Text, "Dinheiro");
                                }
                                BemaFI32.Analisa_iRetorno(IRetorno);
                                Pdv.linformacoes.Text = label2.Text.ToUpper() + "EFETUADA COM SUCESSO VALOR DE R$ " + valor.Text;
                                Close();
                            }
                        }
                    }
                }
            }
        }

    }
}
