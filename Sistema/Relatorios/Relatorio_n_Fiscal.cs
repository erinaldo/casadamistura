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
    public partial class Relatorio_n_Fiscal : Form
    {
        public Relatorio_n_Fiscal()
        {
            InitializeComponent();
        }

        private void Relatorio_n_Fiscal_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Print(object sender, Microsoft.Reporting.WinForms.ReportPrintEventArgs e)
        {

        }
    }
}
