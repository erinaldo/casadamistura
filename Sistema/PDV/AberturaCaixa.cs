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
    public partial class AberturaCaixa : Form
    {
        public AberturaCaixa()
        {
            InitializeComponent();
        }
        Conn.Class1 conex = new Class1();
        System.Drawing.Color back = System.Drawing.ColorTranslator.FromHtml("#CFE8F5");

        private void AberturaCaixa_Load(object sender, EventArgs e)
        {
            this.BackColor = back;
        }
        private void AberturaCaixa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                Class2 acesso = new Class2();
                PDV.PontoVenda pdv = new PDV.PontoVenda();
                //pdv.MinimizeBox = false;
                pdv.MaximizeBox = false;
                if (acesso.acesso(usuariotext.Text, senhatext.Text, Convert.ToDouble(fundotext.Text)))
                {
                    if (acesso.VerificaAberto(acesso.codusuario))
                    {
                        if (MessageBox.Show("JA EXISTE UM CAIXA ABERTO DESDE " + acesso.ultimaabertura + " DESEJA MANTER O MESMO CAIXA?", "PDV", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            pdv.lcaixa.Text = acesso.idcaixa;
                            pdv.loperador.Text = acesso.usuario.ToUpper();
                            pdv.lcodoperador.Text = acesso.codusuario;
                            pdv.Show();
                            pdv.Focus();
                            pdv.BringToFront();
                            this.Close();

                        }
                        else
                        {
                            acesso.FechaCaixa(Convert.ToInt32(acesso.idcaixa));
                            acesso.Cadastra(acesso.codusuario, Convert.ToDouble(fundotext.Text));
                            MessageBox.Show("CAIXA ABERTO COM SUCESSO", "CAIXA ABERTO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            pdv.lcaixa.Text = acesso.idcaixa;
                            pdv.loperador.Text = acesso.usuario.ToUpper();
                            pdv.lcodoperador.Text = acesso.codusuario;
                            pdv.Show();
                            pdv.Focus();
                            pdv.BringToFront();
                            this.Close();

                        }

                    }
                    else
                    {
                        acesso.Cadastra(acesso.codusuario, Convert.ToDouble(fundotext.Text));
                        MessageBox.Show("CAIXA ABERTO COM SUCESSO", "CAIXA ABERTO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        pdv.lcaixa.Text = acesso.idcaixa;
                        pdv.loperador.Text = acesso.usuario.ToUpper();
                        pdv.lcodoperador.Text = acesso.codusuario;
                        pdv.Show();
                        pdv.Focus();
                        pdv.BringToFront();
                        this.Close();

                    }

                }
                else
                {
                    MessageBox.Show("ERRO NA VALIDAÇÃO", "CAIXA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            conex.FormataModeda(fundotext);
        }
    }
}
