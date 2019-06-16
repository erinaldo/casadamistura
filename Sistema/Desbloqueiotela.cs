using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace SISTEMA
{
    public partial class Desbloqueiotela : Form
    {
        public Desbloqueiotela()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            //StreamWriter teste = new StreamWriter("C:\\arq.txt");
            //teste.Write(Criptografar(data).Replace("-", ""));
            //teste.Close();

            //MessageBox.Show(Criptografar(data).Replace("-", ""));
            if (textBox1.Text.Equals(Criptografar(data).Replace("-", "")))
            {
                MessageBox.Show("DESBLOQUEADO COM SUCESSO");
                SessaoSistema.Desbloqueado = true;
                this.Close();
            }
            else
            {
                SessaoSistema.Desbloqueado = false;
                MessageBox.Show("ERRO NA CHAVE DE ACESSO, FAVOR ENTRAR EM CONTATO COM ADMINISTRADOR");
            }

        }
        public string Criptografar(string entrada)
        {
            string txtResultado = "";
            byte[] txtMensagem = System.Text.Encoding.Default.GetBytes(entrada);// Criar o Hash Code
            System.Security.Cryptography.MD5CryptoServiceProvider txtMD5provider = new MD5CryptoServiceProvider();
            //Hash Code
            byte[] txthashcode = txtMD5provider.ComputeHash(txtMensagem);

            return BitConverter.ToString(txthashcode);
        }


    }
}
