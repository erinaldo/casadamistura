using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Conn;
namespace Relatorios
{
    public partial class Relatorios : Form
    {
        public Relatorios()
        {
            InitializeComponent();
        }
        Conn.Class1 conex = new Conn.Class1();
        System.Drawing.Color back = System.Drawing.ColorTranslator.FromHtml("#CFE8F5");
        private void Relatorios_Load(object sender, EventArgs e)
        {
            this.BackColor = back;
        }

        private void btncaixa_Click(object sender, EventArgs e)
        {
              Relatorio_Caixa caixa = new Relatorio_Caixa();
            caixa.Show();
     
        }
    }
}
