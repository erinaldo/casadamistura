using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Relatorios
{
    public partial class Relatorio_Caixa : Form
    {
        public Relatorio_Caixa()
        {
            InitializeComponent();
        }
        public string Vdatainicial { get; set; }
        public string Vdatafinal { get; set; }
        public string Vusuario { get; set; }

        private void Relatorio_Caixa_Load(object sender, EventArgs e)
        {
            DadosRelatorioMovimentoCaixa mov = new DadosRelatorioMovimentoCaixa();
            relatoriomovimentocaixaBindingSource.DataSource = mov.Carregar(Vusuario,Vdatainicial,Vdatafinal);
            this.reportViewer1.RefreshReport();
        }

        private void Relatorio_Caixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }


    }
}
