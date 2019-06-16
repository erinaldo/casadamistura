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
using Agenda;
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
            Agendas abertura = new Agendas();
            abertura.ShowDialog();
            Close();
            top1.Image = Image.FromFile(Application.StartupPath + "\\img\\top1.png");
            manutencaousuario.Parent = top1;
            relatoriosfiscais.Parent = top1;
            produtos.Image = Image.FromFile(Application.StartupPath + "\\img\\btnproduto.png");
            clientes.Image = Image.FromFile(Application.StartupPath + "\\img\\btnclientes.png");
            animal.Image = Image.FromFile(Application.StartupPath + "\\img\\btnanimal.png");
            caixa.Image = Image.FromFile(Application.StartupPath + "\\img\\btncaixa.png");
            agenda.Image = Image.FromFile(Application.StartupPath + "\\img\\btnagenda.png");
            fornecedor.Image = Image.FromFile(Application.StartupPath + "\\img\\btnfornecedor.png");
            pagar.Image = Image.FromFile(Application.StartupPath + "\\img\\btnapagar.png");
            receber.Image = Image.FromFile(Application.StartupPath + "\\img\\btnreceber.png");
            relatorios.Image = Image.FromFile(Application.StartupPath + "\\img\\btnrelatorios.png");

        }
  
  
    
  
        private void f7USUÁRIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastros.FormUsuario user = new FormUsuario();
            user.ShowDialog();

        }

        private void arquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void relatorios_Click(object sender, EventArgs e)
        {
            Relatorios.Relatorios rpt = new Relatorios.Relatorios();
            rpt.Show();
        }

        private void produtos_Click(object sender, EventArgs e)
        {
            CadastroProduto cadastroproduto = new CadastroProduto();
            cadastroproduto.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void caixa_Click(object sender, EventArgs e)
        {
            AberturaCaixa abertura = new AberturaCaixa();
            abertura.ShowDialog();
        }

        private void clientes_Click(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();
            cliente.ShowDialog();
        }

        private void pagar_Click(object sender, EventArgs e)
        {
            ContasPagar cp = new ContasPagar();
            cp.ShowDialog();
        }

        private void fornecedor_Click(object sender, EventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.ShowDialog();
        }

        private void receber_Click(object sender, EventArgs e)
        {
            ContasaReceber recebe = new ContasaReceber();
            recebe.ShowDialog();
        }

        private void manutencaousuario_Click(object sender, EventArgs e)
        {
            FormUsuario user = new FormUsuario();
            user.ShowDialog();
        }

        private void animal_Click(object sender, EventArgs e)
        {
            Animais animal = new Animais();
            animal.ShowDialog();
        }

        private void agenda_Click(object sender, EventArgs e)
        {

        }



  

  



    }
}
