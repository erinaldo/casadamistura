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
    public partial class ExtornaItem : Form
    {
        PontoVenda Pdv;
        public ExtornaItem(PontoVenda frm1)
        {
            InitializeComponent();
            Pdv = frm1;
        }
        Conn.Class1 conex = new Class1();
        string codigo = null;
        string nome = null;
        double valor;
        bool existeitem;
        string itemextorno { get; set; }
        private void item_KeyPress(object sender, KeyPressEventArgs e)
        {
            conex.ChecaNumero(e);
        }
        private void desconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            conex.ChecaNumero(e);
        }
        private void ExtornaItem_Load(object sender, EventArgs e)
        {
            this.BackColor = conex.Fundo();
        }
        private void ExtornaItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                itemextorno = item.Text;
                //if (MessageBox.Show("DESEJA EXTORNAR O ITEM N° " + item.Text + "", "EXTORNAR", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //{
                    
                //    //MessageBox.Show(itemextorno);
                //    SenhaGerencia senha = new SenhaGerencia();
                //    senha.ShowDialog();
                //    if (senha.confirmado)
                //    {
                        foreach (DataGridViewRow linha in Pdv.dataGridView1.Rows)
                        {
                            if (Convert.ToString(Pdv.dataGridView1[0, linha.Index].Value) == itemextorno)
                            {
                                //codigo = Pdv.dataGridView1[1, linha.Index].Value.ToString();
                                //nome = Pdv.dataGridView1[3, linha.Index].Value.ToString();
                                //valor = Convert.ToDouble(Pdv.dataGridView1[4, linha.Index].Value.ToString()) * -1;
                                //DEVO LANÇAR O MESMO ITEM POREM COMO NEGATIVO
                                    //Pdv.dataGridView1.Rows.Add(Pdv.dataGridView1.Rows.Count + 1, codigo, "1", nome, valor.ToString("N"), valor.ToString("N"));
                                Pdv.dataGridView1.Rows.RemoveAt(linha.Index);
                                Pdv.CalculaTotal();
                                existeitem = true;
                            }

                        }
                        if (!existeitem)
                        {
                            MessageBox.Show("ITEM NÃO LOCALIZADO");
                        }

                        Close();
                //    }
                //}
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
