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
    public partial class Relatorio_Lucro : Form
    {
        public Relatorio_Lucro()
        {
            InitializeComponent();
        }
        public string Vdatainicial { get; set; }
        public string Vdatafinal { get; set; }
        public string Vproduto { get; set; }

        private void Relatorio_Lucro_Load(object sender, EventArgs e)
        {
            DadosRelatorioMargemLucro lucro = new DadosRelatorioMargemLucro();
            relatoriomargemlucroBindingSource.DataSource = lucro.Carregar(Vproduto, Vdatainicial, Vdatafinal);
            this.reportViewer1.RefreshReport();
        }

        private void Relatorio_Lucro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
