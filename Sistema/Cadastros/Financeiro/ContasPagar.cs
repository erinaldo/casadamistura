using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Cadastros
{
    public partial class ContasPagar : Form
    {
        public ContasPagar()
        {
            InitializeComponent();
        }
        Conn.Class1 conex = new Conn.Class1();
        fornecedores forne = new fornecedores();
        Financeiro finac = new Financeiro();
        private void ContasPagar_Load(object sender, EventArgs e)
        {
            pictureBox2.BackColor = System.Drawing.Color.Transparent;
            pictureBox2.Parent = pictureBox1;
            pictureBox4.BackColor = System.Drawing.Color.Transparent;
            pictureBox4.Parent = pictureBox1;
            pictureBox5.BackColor = System.Drawing.Color.Transparent;
            pictureBox5.Parent = pictureBox1;
            pictureBox6.BackColor = System.Drawing.Color.Transparent;
            pictureBox6.Parent = pictureBox1;
            this.BackColor = conex.Fundo();
            groupBox1.BackColor = conex.FundoGrupo();
            groupBox2.BackColor = conex.FundoGrupo();
            groupBox3.BackColor = conex.FundoGrupo();
            groupBox4.BackColor = conex.FundoGrupo();
            Carrega_Fornecedor("");
           // finac.CarregaComboDespesa(cbodespesa);
            checatipo();
            compras.Checked = true;
            label17.Text = "";
        }
        private void Carrega_Fornecedor(string codigo)
        {
            if (codigo != "")
            {
                string sQuery = null;
                sQuery = sQuery + string.Format("select HANDLE, CONVERT(VARCHAR,HANDLE)+ ' - ' +NOME AS NOME  from p_fornecedor  where DATA_CANCELAMENTO is null and CPF = '"+codigo+"' ORDER BY Nome");
                OleDbConnection DbConnection = conex.Cnncontrol();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(sQuery, DbConnection);
                da.Fill(dt);
                if (da == null)
                {
                    MessageBox.Show("NENHUM FORNECEDOR LOCALIZADO");
                }
                cbofornecedor.DataSource = dt;
                cbofornecedor.DisplayMember = "NOME";
                cbofornecedor.ValueMember = "HANDLE";
                DbConnection.Close();
            }
            else
            {
                forne.Carrega_Combos_fornecedor(cbofornecedor);
            }
        }
        private void cbofornecedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsLower(e.KeyChar))
            //{
            //    e.KeyChar = char.ToUpper(e.KeyChar);
            //    conex.AutoComplete(this.cbofornecedor, e, true);
            //}
        }
        private void cbofornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Convert.ToString(cbofornecedor.SelectedValue)) != "System.Data.DataRowView")
            {
                forne.seleciona(cbofornecedor.SelectedValue.ToString());
                cnpj.Text = forne.vcpf;

            }
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void cnpj_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void cnpj_Leave(object sender, EventArgs e)
        {
            cnpj.Text = conex.MascaraCnpjCpf(cnpj.Text);
            Carrega_Fornecedor(cnpj.Text);
            cnpj.BackColor = conex.branco();
            
        }
        private void cnpj_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Despesas desp = new Despesas(this);
            desp.ShowDialog();
        }
        private void despesa_CheckedChanged(object sender, EventArgs e)
        {
            checatipo();
        }
        private void checatipo()
        {
            if (despesa.Checked == false)
            {
                cbodespesa.Enabled = false;
                cbocodigo.Enabled = true;
                descricao.Enabled = true;
                quantidade.Enabled = true;
                unitario.Enabled = true;
                total.Enabled = true;
            }
            else
            {
                cbodespesa.Enabled = true;
                cbocodigo.Enabled = false;
                descricao.Enabled = false;
                quantidade.Enabled = false;
                unitario.Enabled = false;
                total.Enabled = false;
            }
        }
        private void valor_TextChanged(object sender, EventArgs e)
        {
            conex.FormataModeda(valor);
        }
        private void valorpago_TextChanged(object sender, EventArgs e)
        {
            conex.FormataModeda(valorpago);
        }
        private void acrescimo_TextChanged(object sender, EventArgs e)
        {
            conex.FormataModeda(acrescimo);
        }
        private void desconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void valor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void valorpago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void acrescimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void quantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void quantidade_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void unitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void unitario_TextChanged(object sender, EventArgs e)
        {
            conex.FormataModeda(unitario);
        }
        private void total_TextChanged(object sender, EventArgs e)
        {
            conex.FormataModeda(total);
        }
        private void total_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void cnpj_Enter(object sender, EventArgs e)
        {
            cnpj.BackColor = conex.amarelo();
        }
        private void codlancamento_Leave(object sender, EventArgs e)
        {
            codlancamento.BackColor = conex.branco();
        }
        private void codlancamento_Enter(object sender, EventArgs e)
        {
            codlancamento.BackColor = conex.amarelo();
        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        




    }
}
