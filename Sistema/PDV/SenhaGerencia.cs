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
    public partial class SenhaGerencia : Form
    {
        public SenhaGerencia()
        {
            InitializeComponent();
        }
        Conn.Class1 conex = new Class1();
        Class2 acesso = new Class2();
        public bool confirmado;
        private void SenhaGerencia_Load(object sender, EventArgs e)
        {
            this.BackColor = conex.Fundo(); ;

        }
        private void valor_TextChanged(object sender, EventArgs e)
        {

        }
        private void SenhaGerencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (usuario.Text == "")
                {
                    usuario.Focus();
                }
                else if (password.Text == "")
                {
                    password.Focus();
                }
                else
                {
                    if (acesso.verificaacesso(usuario.Text, password.Text))
                    {
                        MessageBox.Show("SENHA CONFIRMADA", "CONFIRMADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        confirmado = true;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("DADOS INCORRETOS", "CONFIRMADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        confirmado = false;
                    }
                }

            }
        }
        private void usuario_Leave(object sender, EventArgs e)
        {
            usuario.BackColor = conex.branco();
        }
        private void usuario_Enter(object sender, EventArgs e)
        {
            usuario.BackColor = conex.amarelo();
        }
        private void password_Leave(object sender, EventArgs e)
        {
            password.BackColor = conex.branco();
        }
        private void password_Enter(object sender, EventArgs e)
        {
            password.BackColor = conex.amarelo();
        }
    }
}
