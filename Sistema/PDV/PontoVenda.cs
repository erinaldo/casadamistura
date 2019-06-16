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

namespace PDV
{
    public partial class PontoVenda : Form
    {
        public PontoVenda()
        {
            InitializeComponent();
        }
        System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#FFF68F");
        System.Drawing.Color back = System.Drawing.ColorTranslator.FromHtml("#CFE8F5");
        Conn.Class1 conex = new Class1();
        int IRetorno;
        double vvalorunitario;
        public double vdesconto;
        double calcsubtotal;
        double vtotal;
        double vpeso;
        private void PDV_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            panel2.Width = w-20;
            panel2.Height = h-20;
            this.BackColor = back;
            quantidade.Text = "01";
            valorunitario.Text = "0";
            subtotal.Text = "0";
            totalgeral.Text = "0";
            ldescricaoproduto.BackColor = System.Drawing.Color.Transparent;
            ldescricaoproduto.Parent =pictureBox2;
            linformacoes.BackColor = System.Drawing.Color.Transparent;
            linformacoes.Parent = pictureBox7;
            carregaimagemproduto.BackColor = System.Drawing.Color.Transparent;
            carregaimagemproduto.Parent = fotoproduto;
            comanda.Focus();
            linformacoes.Text = "CAIXA ABERTO";
            #region Carregaimagembotoes
            f1.BackColor = System.Drawing.Color.Transparent;
            f1.Image = Image.FromFile(Application.StartupPath + "\\img\\f1.png");
            f3.BackColor = System.Drawing.Color.Transparent;
            f3.Image = Image.FromFile(Application.StartupPath + "\\img\\f2.png");
            f4.BackColor = System.Drawing.Color.Transparent;
            f4.Image = Image.FromFile(Application.StartupPath + "\\img\\f4.png");
            f6.BackColor = System.Drawing.Color.Transparent;
            f6.Image = Image.FromFile(Application.StartupPath + "\\img\\f6.png");
            f7.BackColor = System.Drawing.Color.Transparent;
            f7.Image = Image.FromFile(Application.StartupPath + "\\img\\f7.png");
            f8.BackColor = System.Drawing.Color.Transparent;
            f8.Image = Image.FromFile(Application.StartupPath + "\\img\\f8.png");
            f9.BackColor = System.Drawing.Color.Transparent;
            f9.Image = Image.FromFile(Application.StartupPath + "\\img\\f9.png");
            f10.BackColor = System.Drawing.Color.Transparent;
            f10.Image = Image.FromFile(Application.StartupPath + "\\img\\f10.png");
            f11.BackColor = System.Drawing.Color.Transparent;
            f11.Image = Image.FromFile(Application.StartupPath + "\\img\\f11.png");
            f12.BackColor = System.Drawing.Color.Transparent;
            f12.Image = Image.FromFile(Application.StartupPath + "\\img\\f12.png");
            f12add.Image = Image.FromFile(Application.StartupPath + "\\img\\f12add.png");
            #endregion
            #region CarregaGrid
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridView1.Columns.Add("item", "Item");
            dataGridView1.Columns.Add("cod", "Cód");
            dataGridView1.Columns.Add("qtde", "Qtde");
            dataGridView1.Columns.Add("desc", "Descricão");
            dataGridView1.Columns.Add("unit", "Unitário");
            dataGridView1.Columns.Add("total", "Total");
            dataGridView1.Columns.Add("comanda", "Comanda");
            dataGridView1.Columns.Add("peso", "peso");
            dataGridView1.Columns.Add("TipoQuantidade", "TipoQuantidade");
            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].Width = 370;
            dataGridView1.Columns[4].Width = 70;
            dataGridView1.Columns[5].Width = 50;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            //dataGridView1.Columns[8].Visible = false;
            //  gridfilacliente.Columns[3].Visible = false;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;
            #endregion
        }
        public void FormataModeda(TextBox txt)
        {
            string n = null;
            double v = 0;
            try
            {
                n = txt.Text.Replace(",", "").Replace(".", "");
                if (n.Equals(""))
                {
                    n = "000";
                }
                n = n.PadLeft(3, '0');
                if (n.Length > 3 && n.Substring(0, 1) == "0")
                {
                    n = n.Substring(1, n.Length - 1);
                }
                v = Convert.ToDouble(n) / 100;
                txt.Text = String.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Valor");
            }
        }
        private void PDV_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    Inicia_Venda();
                    break;
                case Keys.F2:
                    Finaliza_Vista();
                    break;
                case Keys.F3:
                    Finaliza_Prazo();
                    break;
                case Keys.F4:
                    Extorna();
                    break;
                case Keys.F5:
                    Senha_gerencia();
                    break;
                case Keys.F6:
                    Qtde_item();
                    break;
                case Keys.F7:
                    Desconto();
                    break;
                case Keys.F8:
                    Cancela_Desconto();
                    break;
                case Keys.F9:
                    Localiza_Item();
                    break;
                case Keys.F10:
                    Cancela_Cupom();
                    break;
                case Keys.F12:
                    AdicionaItem();
                    break;
                case Keys.P:
                    Impressao();
                    break;
                case Keys.R:
                    Sair_sistema();
                    break;
                case Keys.Escape:
                    Limpa_tela();
                break;
            }
        }
        #region Funcoes_de_F's
        private void f12_Click(object sender, EventArgs e)
        {
            Sair_sistema();
        }
        private void f11_Click(object sender, EventArgs e)
        {
            Impressao();
        }
        private void f10_Click(object sender, EventArgs e)
        {
            Cancela_Cupom();
        }
        private void f9_Click(object sender, EventArgs e)
        {
            Localiza_Item();
        }
        private void f8_Click(object sender, EventArgs e)
        {
            Cancela_Desconto();
        }
        private void f7_Click(object sender, EventArgs e)
        {
            Desconto();
        }
        private void f6_Click(object sender, EventArgs e)
        {
            Qtde_item();
        }
        private void f5_Click(object sender, EventArgs e)
        {
            Senha_gerencia();
        }
        private void f4_Click(object sender, EventArgs e)
        {
            Extorna();
        }
        private void f3_Click(object sender, EventArgs e)
        {
            Finaliza_Vista();
        }
        private void f2_Click(object sender, EventArgs e)
        {
            Finaliza_Vista();
        }
        private void f1_Click(object sender, EventArgs e)
        {
            Inicia_Venda();
        }
        #endregion
        private void Sair_sistema()
        {
            Close();
        }
        private void Impressao()
        {
            MessageBox.Show("Impressão");
        }
        private void Cancela_Cupom()
        {
            IRetorno = BemaFI32.Bematech_FI_CancelaCupom();
            BemaFI32.Analisa_iRetorno(IRetorno);
        }
        private void Localiza_Item()
        {
            EditarProduto mostraproduto = new EditarProduto(this);
            mostraproduto.ShowDialog();
            if (mostraproduto.vbuscaproduto != null)
            {
                Carregar_Produto(mostraproduto.vbuscaproduto);
                Carregar_Imagem(mostraproduto.vbuscaproduto);
                mostraproduto.vbuscaproduto = "";
            }
        }
        private void Cancela_Desconto()
        {
            vdesconto = 0;
            int item = dataGridView1.Rows.Count + 1;
            MessageBox.Show("Desconto Cancelado para item: " + item.ToString(), "CANCELA DESCONTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Desconto()
        {
            linformacoes.Text = "APLICA DESCONTO";
            FormDesconto desc = new FormDesconto(this);
            desc.Item = dataGridView1.Rows.Count + 1;
            desc.ShowDialog();
            linformacoes.Text = "CAIXA ABERTO";

        }
        private void AdicionaItem()
        {
            linformacoes.Text = "ADICIONA ITEM MANUALMENTE";
            InserirItemManual item = new InserirItemManual(this);
            item.ShowDialog();
            linformacoes.Text = "CAIXA ABERTO";
        }
        private void Qtde_item()
        {
            quantidade.Focus();
        }
        private void Senha_gerencia()
        {
            MessageBox.Show("Senha Gerencia");
        }
        private void Extorna()
        {
            linformacoes.Text = "EXTORNAR ITEM";
            ExtornaItem extornar = new ExtornaItem(this);
            extornar.ShowDialog();
            linformacoes.Text = "CAIXA ABERTO";
        }
        private void Finaliza_Prazo()
        {
            //MessageBox.Show("Pagamento Prazo");
        }
        private void Finaliza_Vista()
        {
            linformacoes.Text = "FINALIZA Á VISTA";
            Recebimento avista = new Recebimento(this);
            avista.ValorTotal = Convert.ToDouble(totalgeral.Text);
            avista.ShowDialog();
        }
        private void Inicia_Venda()
        {
            linformacoes.Text = "SANGRIA / SUPRIMENTO";
            SangriaSuprimento sangria = new SangriaSuprimento(this);
            sangria.ShowDialog();
            linformacoes.Text = "CAIXA ABERTO";
        }
        private void Limpa_tela()
        {
            dataGridView1.Rows.Clear();
            totalgeral.Text = "0";
            valorunitario.Text = "0";
            subtotal.Text = "0";
            ldescricaoproduto.Text = "";
            linformacoes.Text = "";
            carregaimagemproduto.Image = null;
            carregaimagemproduto.InitialImage = null;
        }
        #region AMARELO_FOCUS
        private void codbarras_Enter(object sender, EventArgs e)
        {
          codbarras.BackColor = col;
        }
        private void codbarras_Leave(object sender, EventArgs e)
        {
            codbarras.BackColor = Color.White;
        }
        private void quantidade_Enter(object sender, EventArgs e)
        {
            quantidade.BackColor = col;
            quantidade.SelectionStart = 0;
            quantidade.SelectionLength = quantidade.Text.Length;
        }
        private void quantidade_Leave(object sender, EventArgs e)
        {
            quantidade.BackColor = Color.White;
        }
        private void valorunitario_Leave(object sender, EventArgs e)
        {
            valorunitario.BackColor = Color.White;
        }
        private void valorunitario_Enter(object sender, EventArgs e)
        {
            valorunitario.BackColor = col;
        }
        private void subtotal_Leave(object sender, EventArgs e)
        {
            subtotal.BackColor = Color.White;
        }
        private void subtotal_Enter(object sender, EventArgs e)
        {
            subtotal.BackColor = col;
        }
        private void totalgeral_Leave(object sender, EventArgs e)
        {
            totalgeral.BackColor = Color.White;
        }
        private void totalgeral_Enter(object sender, EventArgs e)
        {
            totalgeral.BackColor = col;
        }
        private void comanda_Leave(object sender, EventArgs e)
        {
            comanda.BackColor = conex.branco();
        }
        private void comanda_Enter(object sender, EventArgs e)
        {
            comanda.BackColor = conex.amarelo();
        }
        #endregion
        private void quantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                codbarras.Focus();
            }
            else if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);

            }
        }
        private void valorunitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void subtotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void totalgeral_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void codbarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (codbarras.Focus())
                {
                    if (codbarras.Text != "")
                    {
                        Carregar_Produto(codbarras.Text);
                        Carregar_Imagem(codbarras.Text);
                        codbarras.Text = "";
                    }
                    else
                    {
                        comanda.Focus();
                    }
                }
            }
            conex.ChecaNumero(e);
        }
        private void valorunitario_TextChanged(object sender, EventArgs e)
        {
            FormataModeda(valorunitario);
        }
        private void subtotal_TextChanged(object sender, EventArgs e)
        {
            FormataModeda(subtotal);
        }
        private void totalgeral_TextChanged(object sender, EventArgs e)
        {
            FormataModeda(totalgeral);
        }
        private void Carregar_Produto(string codproduto)
        {
            string sQuery = null;
            //SE PRODUTO FRACIONARIO
            if ((conex.Checatipoproduto(codproduto) == "1 - Fracionário"))
            {
                sQuery = sQuery + string.Format("SELECT * FROM p_produtos WHERE SUBSTRING(CODIGO_BARRAS,0,8) LIKE '" + codproduto.Substring(0, 7) + "' AND TIPO_ESTOQUE = '1 - Fracionário' AND LEN(codigo_barras)> 12 AND DATA_CANCELAMENTO IS NULL");
                OleDbConnection DbConnection = conex.Cnncontrol();
                OleDbCommand commS = new OleDbCommand(sQuery, DbConnection);
                OleDbDataReader dr = commS.ExecuteReader();
                while (dr.Read())
                {
                    string kilo = codproduto.Substring(7, 6);
                    string grama = kilo.Substring(2, 3);
                    kilo = kilo.Substring(0, 2);//.TrimEnd('0');                    
                    //vpeso = Convert.ToInt32(kilo.TrimEnd('0'));
                    vpeso = Convert.ToDouble(kilo+grama)/1000;
                    //vpeso = vpeso / 1000;
                    vvalorunitario = Math.Round(Convert.ToDouble(dr["PRECO_VENDA"].ToString()) * vpeso, 2);
                    
                    calcsubtotal += Math.Round((vvalorunitario * Convert.ToInt32(quantidade.Text)) - vdesconto,2);
                    subtotal.Text = calcsubtotal.ToString("N2");
                    valorunitario.Text = dr["PRECO_VENDA"].ToString();
                    dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, dr["HANDLE"].ToString(), quantidade.Text, dr["NOME"].ToString(), valorunitario.Text, calcsubtotal.ToString("N"), "0", kilo + "," + grama, dr["TIPO_ESTOQUE"].ToString());
                    ldescricaoproduto.Text = dr["NOME"].ToString();
                    CalculaTotal();
                    vvalorunitario = 0;
                    calcsubtotal = 0;
                    vdesconto = 0;
                }
                DbConnection.Close();
            }
            else
            {
                sQuery = sQuery + string.Format("select * from p_produtos WHERE CODIGO_BARRAS ='" + codproduto + "' and DATA_CANCELAMENTO is null");
                OleDbConnection DbConnection = conex.Cnncontrol();
                OleDbCommand commS = new OleDbCommand(sQuery, DbConnection);
                OleDbDataReader dr = commS.ExecuteReader();
                while (dr.Read())
                {
                    valorunitario.Text = dr["PRECO_VENDA"].ToString() == "" ? "0" : dr["PRECO_VENDA"].ToString();
                    vvalorunitario = Convert.ToDouble(valorunitario.Text);
                    calcsubtotal += (vvalorunitario * Convert.ToInt32(quantidade.Text)) - vdesconto;
                    subtotal.Text = calcsubtotal.ToString("N");
                    dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, dr["HANDLE"].ToString(), quantidade.Text, dr["NOME"].ToString(), valorunitario.Text, calcsubtotal.ToString("N"), "0", dr["TIPO_ESTOQUE"].ToString());
                    ldescricaoproduto.Text = dr["NOME"].ToString();
                    CalculaTotal();
                    vvalorunitario = 0;
                    calcsubtotal = 0;
                    vdesconto = 0;
                }
                DbConnection.Close();
            }
            quantidade.Text = "01";
            
        }
        private void Carregar_Imagem(string codproduto)
        {
            string sQuery = null;
            carregaimagemproduto.Image = null;
                        //SE PRODUTO FRACIONARIO
            if ((conex.Checatipoproduto(codproduto) == "1 - Fracionário"))
            {
                
                
                sQuery = sQuery + string.Format("select * from p_produtos WHERE SUBSTRING(CODIGO_BARRAS,0,8) ='" + codproduto + "' and LEN(imagem)>4 and DATA_CANCELAMENTO IS NULL");
                OleDbConnection DbConnection = conex.Cnncontrol();
                OleDbDataAdapter da = new OleDbDataAdapter(sQuery, DbConnection);
                DataSet ds = new DataSet("MyImages");
                byte[] MyData = new byte[0];
                da.Fill(ds, "MyImages");

                DataRow myRow;
                if (ds.Tables["MyImages"].Rows.Count > 0)
                {
                    myRow = ds.Tables["MyImages"].Rows[0];

                    MyData = (byte[])myRow["IMAGEM"];
                    MemoryStream stream = new MemoryStream(MyData);
                    carregaimagemproduto.Image = Image.FromStream(stream);
                    carregaimagemproduto.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                DbConnection.Close();
            }
            else
            {
                sQuery = sQuery + string.Format("select * from p_produtos WHERE CODIGO_BARRAS ='" + codproduto + "' and LEN(imagem)>4");
                OleDbConnection DbConnection = conex.Cnncontrol();
                OleDbDataAdapter da = new OleDbDataAdapter(sQuery, DbConnection);
                DataSet ds = new DataSet("MyImages");
                byte[] MyData = new byte[0];
                da.Fill(ds, "MyImages");

                DataRow myRow;
                if (ds.Tables["MyImages"].Rows.Count > 0)
                {
                    myRow = ds.Tables["MyImages"].Rows[0];

                    MyData = (byte[])myRow["IMAGEM"];
                    MemoryStream stream = new MemoryStream(MyData);
                    carregaimagemproduto.Image = Image.FromStream(stream);
                    carregaimagemproduto.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                DbConnection.Close();
            }
           
        }
        private void PontoVenda_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("DESEJA TAMBEM FECHAR O CAIXA?", "PDV", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Class2 classe = new Class2();
                classe.FechaCaixa(Convert.ToInt32(lcaixa.Text));
                e.Cancel = false;
            }
            else
            {
                e.Cancel = false;
                //e.Cancel = true;
            }
        }
        private void PreencheGrid(string pcodigobarras)
        {
            //dataGridView1.Rows.Clear();
            OleDbConnection conexao = conex.Cnncontrol();
            string sql = @"select a.CODIGO_BARRAS, a.PRODUTO,b.NOME,replace(a.QUANTIDADE,0,1),a.VALOR PRECO_VENDA,a.VALOR*replace(a.QUANTIDADE,0,1) VALOR 
                            from p_comanda a 
                            join p_produtos b on a.PRODUTO = b.HANDLE 
                            WHERE  a.CODIGO_BARRAS = '" + pcodigobarras+"' ";
            OleDbCommand commS = new OleDbCommand(sql, conexao);
            OleDbDataReader da = commS.ExecuteReader();
            if (da.HasRows)
            {
                while (da.Read())
                {
                    dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, da["PRODUTO"].ToString(), "1", da["NOME"].ToString(), da["PRECO_VENDA"].ToString(), da["VALOR"].ToString(), da["CODIGO_BARRAS"].ToString());
                }
                comanda.Text = "";
                CalculaTotal();
                codbarras.Text = "";
                quantidade.Text = "01";

            }
            else
            {
                MessageBox.Show("COMANDA VAZIA", "COMANDA",MessageBoxButtons.OK, MessageBoxIcon.Information);
                comanda.Text = "";
            }
            conexao.Close();
        }
        public void CalculaTotal()
        {
            vtotal = 0; 
            totalgeral.Text = "";
            foreach (DataGridViewRow linhas in dataGridView1.Rows)
            {
                vtotal += (Convert.ToDouble((dataGridView1[5, linhas.Index].Value==""?"0":dataGridView1[5, linhas.Index].Value)));
            }
            totalgeral.Text = vtotal.ToString("N");
            
        }
        private void comanda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                if (comanda.Focus())
                {
                    if (comanda.Text != "")
                    {
                        PreencheGrid(comanda.Text);
                    }
                    else
                    {
                        codbarras.Focus();
                    }
                }
            }
            conex.ChecaNumero(e);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void lcaixa_Click(object sender, EventArgs e)
        {

        }

        private void f12add_Click(object sender, EventArgs e)
        {
            AdicionaItem();
        }

        private void PontoVenda_MaximumSizeChanged(object sender, EventArgs e)
        {
            
        }

        private void PontoVenda_MinimumSizeChanged(object sender, EventArgs e)
        {

        }










    }
}

