using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PDV;
using Cadastros;
using Relatorios;
namespace SISTEMA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Width = w;
            this.Height = h;
            groupBox1.Height = h-110;


        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AberturaCaixa abertura = new AberturaCaixa();
            abertura.ShowDialog();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();
            cliente.ShowDialog();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            CadastroProduto cadastroproduto = new CadastroProduto();
            cadastroproduto.ShowDialog();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void f3ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Relatorios.Relatorios rpt = new Relatorios.Relatorios();
            rpt.Show();

        }
        private void f7USUÁRIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastros.FormUsuario user = new FormUsuario();
            user.ShowDialog();

        }



    }
}
