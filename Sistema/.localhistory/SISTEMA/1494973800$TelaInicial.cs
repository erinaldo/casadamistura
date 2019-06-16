using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cadastros;
using PDV;
using System.Data.OleDb;
using System.IO;
using Conn;



namespace SISTEMA
{
    public partial class TelaInicial : Form
    {
 
        public TelaInicial()
        {
            InitializeComponent();
        }
        Conn.Class1 conex = new Conn.Class1();
        private int iRetorno;
        private void TelaInicial_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = true;
            this.WindowState = FormWindowState.Maximized;
            ldata.Text = DateTime.Now.ToShortDateString();
            lhora.Text = DateTime.Now.ToShortTimeString();
            lusuario.Text = SessaoSistema.NomeUsuario;
            if (SessaoSistema.perfil != "1")
            {
                menuStrip1.Visible = false;
            }

        }
       
        private void btnprodutos_Click(object sender, EventArgs e)
        {
            CadastroProduto cadastroproduto = new CadastroProduto();
            cadastroproduto.ShowDialog();
        }
        private void btnclientes_Click(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();
            cliente.ShowDialog();
        }
        private void btnfornecedores_Click(object sender, EventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.ShowDialog();
        }
        private void btnvendaspdf_Click(object sender, EventArgs e)
        {
            AberturaCaixa abertura = new AberturaCaixa();
            abertura.ShowDialog();
        }
        private void btnusuario_Click(object sender, EventArgs e)
        {
            FormUsuario user = new FormUsuario();
            user.ShowDialog();
        }
        private void btncontasapagar_Click(object sender, EventArgs e)
        {
            ContasPagar cp = new ContasPagar();
            cp.ShowDialog();
        }
        private void btncontasareceber_Click(object sender, EventArgs e)
        {
            ContasaReceber recebe = new ContasaReceber();
            recebe.ShowDialog();
        }
        private void btnbackup_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string diretorio = folderBrowserDialog1.SelectedPath;
                string Nomebanco = "BANCO_DADOS_CASA_DA_MISTURA" + DateTime.Now.ToShortDateString().Replace('/', '_') + "_" + DateTime.Now.ToLongTimeString().Replace(':', '_') + ".sql";
                string banco = diretorio + "\\" + Nomebanco;
                string sql = "BACKUP DATABASE PwdDb TO DISK = '" + banco + "' WITH COPY_ONLY";
                OleDbConnection DbConnection = conex.Cnncontrol();
                OleDbCommand cmd = new OleDbCommand(sql, DbConnection);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception err)
                {
                    string mensagem = err.Message;
                    conex.GeraErro("GERA_BACKUP_BANCO", mensagem, DateTime.Now.ToString());
                }
                finally
                {
                    DbConnection.Close();
                    
                }
            }
        }
        private void btnmovimentocaixa_Click(object sender, EventArgs e)
        {
            Relatorios.FiltroRptMovimentoCaixa filtromovcaixa = new Relatorios.FiltroRptMovimentoCaixa();
            filtromovcaixa.ShowDialog();
        }
        private void eMITIRLEITURAXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("CONFIRMA A LEITURA X ?", "ATENÇÃO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                
                iRetorno = BemaFI32.Bematech_FI_LeituraX();
            }
        }
        private void eMITIRREDUÇÃOZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("CONFIRMA A REDUÇÃO Z ?\n APÓS ESTE PROCESSO NÃO PODERÁ EFETUAR NENHUMA OPERAÇÃO NA IMPRESSORA!!!", "ATENÇÃO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                iRetorno = BemaFI32.Bematech_FI_ReducaoZ("", "");
            }
        }
        private void btnmargemlucro_Click(object sender, EventArgs e)
        {
            Relatorios.FiltroRptMargemLucro lucro = new Relatorios.FiltroRptMargemLucro();
            lucro.ShowDialog();
        }
        private void btncompras_Click(object sender, EventArgs e)
        {
           
           
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lhora.Text = DateTime.Now.ToLongTimeString();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnsair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
