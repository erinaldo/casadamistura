using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Conn;
using System.IO;
namespace Cadastros
{
    public partial class CadastroProduto : Form
    {
        public CadastroProduto()
        {
            InitializeComponent();
        }

        Conn.Class1 conex = new Class1();
        double vprecocusto;
        double vprecovenda;
        double vlucro;
        private void CadastroProduto_Load(object sender, EventArgs e)
        {
            
           // int w = Screen.PrimaryScreen.Bounds.Width;
           // int h = Screen.PrimaryScreen.Bounds.Height;
           // panel1.Width = w - 20;
           // panel1.Height = h - 20;
            pictureBox2.BackColor = System.Drawing.Color.Transparent;
            pictureBox2.Parent = pictureBox1;
            pictureBox4.BackColor = System.Drawing.Color.Transparent;
            pictureBox4.Parent = pictureBox1;
            pictureBox6.BackColor = System.Drawing.Color.Transparent;
            pictureBox6.Parent = pictureBox1;
            groupBox1.BackColor = conex.FundoGrupo();
            groupBox2.BackColor = conex.FundoGrupo();
            groupBox3.BackColor = conex.FundoGrupo();
            groupBox4.BackColor = conex.FundoGrupo();
            groupBox5.BackColor = conex.FundoGrupo();
            groupBox6.BackColor = conex.FundoGrupo();
            this.BackColor = conex.Fundo();
            Carrega_fornecedor();
            Carrega_grupo();
            Carrega_subgrupo(0);
            Carrega_tipoestoque();
            calcula();
            codproduto.Text = "";
            datacadastro.Text = DateTime.Now.ToShortDateString();
         }
        private void Carrega_fornecedor()
        {
            fornecedores fornece = new fornecedores();
            fornece.Carrega_Combos_fornecedor(cbofornecedor);
        }
        private void Carrega_grupo()
        {
            string sQuery = null;
            sQuery = sQuery + string.Format("select HANDLE, CONVERT(VARCHAR,HANDLE)+ ' - ' +NOME AS NOME  from p_grupo WHERE DATA_CANCELAMENTO IS NULL ORDER BY Nome");
            OleDbConnection DbConnection = conex.Cnncontrol();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(sQuery, DbConnection);
            da.Fill(dt);
            cbogrupo.DataSource = dt;
            cbogrupo.DisplayMember = "NOME";
            cbogrupo.ValueMember = "HANDLE";
            DbConnection.Close();
        }
        private void Carrega_subgrupo(int grupo)
        {
            string sQuery = null;
            if (grupo != 0)
            {
                sQuery = sQuery + string.Format("select HANDLE, CONVERT(VARCHAR,HANDLE)+ ' - ' +NOME AS NOME  from p_subgrupo WHERE DATA_CANCELAMENTO IS NULL AND  grupo = " + grupo + " ORDER BY Nome");
            }
            else
            {
                sQuery = sQuery + string.Format("select HANDLE, CONVERT(VARCHAR,HANDLE)+ ' - ' +NOME AS NOME  from p_subgrupo WHERE DATA_CANCELAMENTO IS NULL  ORDER BY Nome");
            }
            OleDbConnection DbConnection = conex.Cnncontrol();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(sQuery, DbConnection);
            da.Fill(dt);
            cbosubgrupo.DataSource = dt;
            cbosubgrupo.DisplayMember = "NOME";
            cbosubgrupo.ValueMember = "HANDLE";
            DbConnection.Close();
        }
        private void Carrega_tipoestoque()
        {
            string sQuery = null;
            sQuery = sQuery + string.Format("select HANDLE, CONVERT(VARCHAR,HANDLE)+ ' - ' +TIPO AS NOME  from p_tipo_estoque ORDER BY TIPO");
            OleDbConnection DbConnection = conex.Cnncontrol();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(sQuery, DbConnection);
            da.Fill(dt);
            tipoestoque.DataSource = dt;
            tipoestoque.DisplayMember = "NOME";
            tipoestoque.ValueMember = "HANDLE";
            DbConnection.Close();
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void codinternotext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            CadastroGrupo grupo = new CadastroGrupo();
            grupo.ShowDialog();
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            CadastroSubGrupo subgrupo = new CadastroSubGrupo();
            subgrupo.ShowDialog();
        }
        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Fornecedor fornecer = new Fornecedor();
            fornecer.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (button1.Text == "Carregar IMG")
                {
                    minhaWebCamComp1.Start();
                    button1.Text = "OK";
                }
                else
                {
                    minhaWebCamComp1.Stop();
                    button1.Text = "Carregar IMG";
                }

            }
            else
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "jpg|*.jpg";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    minhaWebCamComp1.ImgWebCam.ImageLocation = file.FileName;
                    minhaWebCamComp1.ImgWebCam.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    minhaWebCamComp1.Stop();
                }
            }
        }
        private void cbogrupo_TextChanged(object sender, EventArgs e)
        {
            Carrega_subgrupo(Convert.ToInt32(cbogrupo.SelectedValue));
        }
        private void datacadastro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                conex.Formada_data(datacadastro);
            }
            else
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void precocusto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void precovenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void precocusto_TextChanged(object sender, EventArgs e)
        {
            conex.FormataModeda(precocusto);
            calcula();
        }
        private void calcula()
        {
            vprecovenda = Convert.ToDouble((precovenda.Text==""?"0":precovenda.Text));
            vprecocusto = Convert.ToDouble((precocusto.Text == "" ? "0" : precocusto.Text));
            vlucro = vprecovenda - vprecocusto;
            
            if (vlucro < 0)
            {
                lucro.Text = vlucro.ToString("N");
                lucro.ForeColor = Color.Red;
            }
            else
            {
                lucro.Text = vlucro.ToString("N");
                lucro.ForeColor = Color.Black;
            }
        }
        private void descontomax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void precovenda_TextChanged(object sender, EventArgs e)
        {
            conex.FormataModeda(precovenda);
            calcula();
        }
        private void qtdeatual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void qtdeminima_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void qtdemaxima_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        #region FOCUS AMARELO
        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.BackColor = conex.branco();
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.BackColor = conex.amarelo();
        }
        private void descricaoproduto_Leave(object sender, EventArgs e)
        {
            descricaoproduto.BackColor = conex.branco();
        }
        private void descricaoproduto_Enter(object sender, EventArgs e)
        {
            descricaoproduto.BackColor = conex.amarelo();
        }
        private void codinternotext_Leave(object sender, EventArgs e)
        {
            codinternotext.BackColor = conex.branco();
        }
        private void codinternotext_Enter(object sender, EventArgs e)
        {
            codinternotext.BackColor = conex.amarelo();
        }
        private void datacadastro_Leave(object sender, EventArgs e)
        {
            datacadastro.BackColor = conex.branco();
        }
        private void datacadastro_Enter(object sender, EventArgs e)
        {
            datacadastro.BackColor = conex.amarelo();
        }
        private void cbofornecedor_Leave(object sender, EventArgs e)
        {
            cbofornecedor.BackColor = conex.branco();
        }
        private void cbofornecedor_Enter(object sender, EventArgs e)
        {
            cbofornecedor.BackColor = conex.amarelo();
        }
        private void peso_Leave(object sender, EventArgs e)
        {
            peso.BackColor = conex.branco();
        }
        private void peso_Enter(object sender, EventArgs e)
        {
            peso.BackColor = conex.amarelo();
        }
        private void cbogrupo_Leave(object sender, EventArgs e)
        {
            cbogrupo.BackColor = conex.branco();
        }
        private void cbogrupo_Enter(object sender, EventArgs e)
        {
            cbogrupo.BackColor = conex.amarelo();
        }
        private void cbosubgrupo_Leave(object sender, EventArgs e)
        {
            cbosubgrupo.BackColor = conex.branco();
        }
        private void cbosubgrupo_Enter(object sender, EventArgs e)
        {
            cbosubgrupo.BackColor = conex.amarelo();
        }
        private void informacoes_Leave(object sender, EventArgs e)
        {
            informacoes.BackColor = conex.branco();
        }
        private void informacoes_Enter(object sender, EventArgs e)
        {
            informacoes.BackColor = conex.amarelo();
        }
        private void precocusto_Leave(object sender, EventArgs e)
        {
            precocusto.BackColor = conex.branco();
        }
        private void precocusto_Enter(object sender, EventArgs e)
        {
            precocusto.BackColor = conex.amarelo();
        }
        private void precovenda_Leave(object sender, EventArgs e)
        {
            precovenda.BackColor = conex.branco();
        }
        private void precovenda_Enter(object sender, EventArgs e)
        {
            precovenda.BackColor = conex.amarelo();
        }
        private void lucro_Leave(object sender, EventArgs e)
        {
            lucro.BackColor = conex.branco();
        }
        private void lucro_Enter(object sender, EventArgs e)
        {
            lucro.BackColor = conex.amarelo();
        }
        private void descontomax_Leave(object sender, EventArgs e)
        {
            descontomax.BackColor = conex.branco();
        }
        private void descontomax_Enter(object sender, EventArgs e)
        {
            descontomax.BackColor = conex.amarelo();
        }
        private void tipoestoque_Leave(object sender, EventArgs e)
        {
            tipoestoque.BackColor = conex.branco();
        }
        private void tipoestoque_Enter(object sender, EventArgs e)
        {
            tipoestoque.BackColor = conex.amarelo();
        }
        private void qtdeatual_Leave(object sender, EventArgs e)
        {
            qtdeatual.BackColor = conex.branco();
        }
        private void qtdeatual_Enter(object sender, EventArgs e)
        {
            qtdeatual.BackColor = conex.amarelo();
        }
        private void qtdeminima_Leave(object sender, EventArgs e)
       {
           qtdeminima.BackColor = conex.branco();
       }
        private void qtdeminima_Enter(object sender, EventArgs e)
       {
           qtdeminima.BackColor = conex.amarelo();
       }
        private void qtdemaxima_Enter(object sender, EventArgs e)
       {
           qtdemaxima.BackColor = conex.amarelo();
       }
        private void qtdemaxima_Leave(object sender, EventArgs e)
       {
           qtdemaxima.BackColor = conex.branco();
       }
        private void icms_Leave(object sender, EventArgs e)
        {
            icms.BackColor = conex.branco();
        }
        private void icms_Enter(object sender, EventArgs e)
        {
            icms.BackColor = conex.amarelo();
        }
        private void iss_Leave(object sender, EventArgs e)
        {
            iss.BackColor = conex.branco();
        }
        private void iss_Enter(object sender, EventArgs e)
        {
            iss.BackColor = conex.amarelo();
        }
        private void ipi_Leave(object sender, EventArgs e)
        {
            ipi.BackColor = conex.branco();
        }
        private void ipi_Enter(object sender, EventArgs e)
        {
            ipi.BackColor = conex.amarelo();
        }
        private void iof_Leave(object sender, EventArgs e)
        {
            iof.BackColor = conex.branco();
        }
        private void iof_Enter(object sender, EventArgs e)
        {
            iof.BackColor = conex.amarelo();
        }
        private void pis_Enter(object sender, EventArgs e)
        {
            pis.BackColor = conex.amarelo();
        }
        private void pis_Leave(object sender, EventArgs e)
        {
            pis.BackColor = conex.branco();
        }
        private void cofins_Leave(object sender, EventArgs e)
        {
            cofins.BackColor = conex.branco();
        }
        private void cofins_Enter(object sender, EventArgs e)
        {
            cofins.BackColor = conex.amarelo();
        }
        private void cide_Leave(object sender, EventArgs e)
        {
            cide.BackColor = conex.branco();
        }
        private void cide_Enter(object sender, EventArgs e)
        {
            cide.BackColor = conex.amarelo();
        }
        private void cll_Leave(object sender, EventArgs e)
        {
            cll.BackColor = conex.branco();
        }
        private void cll_Enter(object sender, EventArgs e)
        {
            cll.BackColor = conex.amarelo();
        }
        #endregion
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Grava();
        }
        private void Grava()
        {
            if (ValidaCampos())
            {
                produto produ = new produto();
                MemoryStream stream=new MemoryStream();
                if (minhaWebCamComp1.ImgWebCam.Image != null)
                {
                    minhaWebCamComp1.ImgWebCam.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                    byte[] pic = stream.ToArray();
               
                if (codproduto.Text == "")
                {
                    if (produ.Cadastra(textBox1.Text,descricaoproduto.Text,codinternotext.Text,datacadastro.Text,Convert.ToInt32(cbofornecedor.SelectedValue), Convert.ToDouble((peso.Text==""?"0":peso.Text)),Convert.ToInt32(cbogrupo.SelectedValue),Convert.ToInt32(cbosubgrupo.SelectedValue),informacoes.Text,Convert.ToDouble(precocusto.Text),Convert.ToDouble(precovenda.Text),Convert.ToDouble(lucro.Text),Convert.ToDouble(descontomax.Text),tipoestoque.Text,Convert.ToDouble(qtdeatual.Text),Convert.ToDouble(qtdeminima.Text),Convert.ToDouble(qtdemaxima.Text),pic,Convert.ToDouble(icms.Text),Convert.ToDouble(iss.Text),Convert.ToDouble(ipi.Text),Convert.ToDouble(iof.Text),Convert.ToDouble(pis.Text),Convert.ToDouble(cofins.Text),Convert.ToDouble(cide.Text),Convert.ToDouble(cll.Text)))
                    {
                        conex.LimpaTextBoxes(this.Controls);
                        minhaWebCamComp1.ImgWebCam.Image = null;
                        codproduto.Text = "";
                        qtdeatual.Text = "0";
                        qtdemaxima.Text = "0";
                        qtdeminima.Text = "0";
                        datacadastro.Text = DateTime.Now.ToShortDateString();

                    }
                }
                else
                {
                    if(produ.Altera(codproduto.Text,textBox1.Text,descricaoproduto.Text,codinternotext.Text,datacadastro.Text,Convert.ToInt32(cbofornecedor.SelectedValue), Convert.ToDouble(peso.Text),Convert.ToInt32(cbogrupo.SelectedValue),Convert.ToInt32(cbosubgrupo.SelectedValue),informacoes.Text,Convert.ToDouble(precocusto.Text),Convert.ToDouble(precovenda.Text),Convert.ToDouble(lucro.Text),Convert.ToDouble(descontomax.Text),tipoestoque.Text,Convert.ToDouble(qtdeatual.Text),Convert.ToDouble(qtdeminima.Text),Convert.ToDouble(qtdemaxima.Text),pic,Convert.ToDouble(icms.Text),Convert.ToDouble(iss.Text),Convert.ToDouble(ipi.Text),Convert.ToDouble(iof.Text),Convert.ToDouble(pis.Text),Convert.ToDouble(cofins.Text),Convert.ToDouble(cide.Text),Convert.ToDouble(cll.Text)))
                    {
                        conex.LimpaTextBoxes(this.Controls);
                        minhaWebCamComp1.ImgWebCam.Image = null;
                        codproduto.Text = "";
                        qtdeatual.Text = "0";
                        qtdemaxima.Text = "0";
                        qtdeminima.Text = "0";
                        datacadastro.Text = DateTime.Now.ToShortDateString();
                    }

                }

            }
        }
        private bool ValidaCampos()
        {
            bool grava;
            if (!conex.Checadata(datacadastro))
            {
                MessageBox.Show("Data Cadastro inválida", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                datacadastro.Focus();
                grava = false;
            }
            else if (descricaoproduto.TextLength < 3)
            {
                MessageBox.Show("Nome muito curto", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                descricaoproduto.Focus();
                grava = false;
            }
            else
            {
                grava = true;
            }
            return grava;

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            minhaWebCamComp1.ImgWebCam.Image = null;
        }
        private void icms_TextChanged(object sender, EventArgs e)
        {
            conex.FormataModeda(icms);
        }
        private void icms_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void iss_TextChanged(object sender, EventArgs e)
        {
            conex.FormataModeda(iss);
        }
        private void iss_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void ipi_TextChanged(object sender, EventArgs e)
        {
            conex.FormataModeda(ipi);
        }
        private void ipi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void iof_TextChanged(object sender, EventArgs e)
        {
            conex.FormataModeda(iof);
        }
        private void iof_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void pis_TextChanged(object sender, EventArgs e)
        {
            conex.FormataModeda(pis);
        }
        private void pis_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void cofins_TextChanged(object sender, EventArgs e)
        {
            conex.FormataModeda(cofins);
        }
        private void cofins_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void cide_TextChanged(object sender, EventArgs e)
        {
            conex.FormataModeda(cide);
        }
        private void cide_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void cll_TextChanged(object sender, EventArgs e)
        {
            conex.FormataModeda(cll);
        }
        private void cll_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            conex.LimpaTextBoxes(this.Controls);
            minhaWebCamComp1.ImgWebCam.Image = null;
            codproduto.Text = "";
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            EditarProduto editprod = new EditarProduto(this);
            editprod.ShowDialog();
        }
        private void descontomax_TextChanged(object sender, EventArgs e)
        {
            conex.FormataModeda(descontomax);
        }
        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }
        private void pictureBox19_Click(object sender, EventArgs e)
        {

        }





    }
}
