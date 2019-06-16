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
    public partial class InserirItemManual : Form
    {
        PontoVenda Pdv;
        public InserirItemManual(PontoVenda frm1)
        {
            InitializeComponent();
            item.Text = "DIVERSOS";
            Pdv = frm1;
        }
        Conn.Class1 conex = new Class1();
        string codigo = null;
        string nome = null;
        double valor;
        bool existeitem;
        string itemextorno { get; set; }

        private void txtvalor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13 && !char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }

        private void InserirItemManual_Load(object sender, EventArgs e)
        {
            this.BackColor = conex.Fundo();
            txtvalor.Focus();
        }

        private void InserirItemManual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtvalor.Text != "" && item.Text != "")
            {
                //if (MessageBox.Show("DESEJA ADICIONAR O ITEM " + item.Text + "", "INSERIR ITEM", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //{
                    //DEVO LANÇAR O MESMO ITEM POREM COMO NEGATIVO
                    Pdv.dataGridView1.Rows.Add(Pdv.dataGridView1.Rows.Count + 1, "9999", "1", item.Text, txtvalor.Text, txtvalor.Text, "1", "0");
                    //Pdv.dataGridView1.Rows.RemoveAt(linha.Index);
                    Pdv.CalculaTotal();

                    Close();
                //}
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void txtvalor_TextChanged(object sender, EventArgs e)
        {
            conex.FormataModeda(txtvalor);
        }
    }
}
