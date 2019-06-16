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
    public partial class FormDesconto : Form
    {
        PontoVenda Pdv;
        public FormDesconto(PontoVenda frm1)
        {
            InitializeComponent();
            Pdv = frm1;
        }
        Conn.Class1 conex = new Class1();
        
        public int Item;
        private void Desconto_Load(object sender, EventArgs e)
        {
            label2.Text = Item.ToString();

            this.BackColor = conex.Fundo();
        }
        private void FormDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Close();
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }
        }
        private void desconto_TextChanged(object sender, EventArgs e)
        {
            conex.FormataModeda(desconto);
        }
        private void FormDesconto_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            Pdv.vdesconto =  Convert.ToDouble(desconto.Text);
        }

    }
}
