using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Conn;
using System.Data.OleDb;
using System.Runtime.InteropServices;


namespace PDV
{
    public partial class Recebimento : Form
    {
        System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#FFF68F");
        Class1 conex = new Conn.Class1();
        Class2 venda = new Class2();
        private int IRetorno;
        int iRetorno = 0;
        PontoVenda Pdv;
        int ACK, ST1, ST2, ST3;
        string chaveAcesso, numeroCupom, NumeroSAT, message, code, errorMessage, errorCode;

        [DllImport("Winspool.drv")]
        private static extern bool SetDefaultPrinter(string printerName);
        public double ValorTotal;
        private string Vtotalpagar { get; set; }
        private double recebidocheque { get; set; }
        private double recebidodinheiro { get; set; }
        private double recebidocartao { get; set; }
        private double dinheiro { get; set; }
        private double apagar { get; set; }
        private double troco { get; set; }
        
        public Recebimento(PontoVenda frm1)
        {
            InitializeComponent();
            Pdv = frm1;
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
        private void Recebimento_Load(object sender, EventArgs e)
        {

            pictureBox4.BackColor = System.Drawing.Color.Transparent;
            pictureBox4.Image = Image.FromFile(Application.StartupPath + "\\img\\fecharcupom.png");
            pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\img\\fecharcupomnfisc.png");
            lapagartext.Text = ValorTotal.ToString("N");
            dataGridView1.Columns.Add("tipo", "TIPO PAGAMENTO");
            dataGridView1.Columns.Add("valor", "VALOR");
            dataGridView1.Columns[0].Width = 250;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            CarregaFormaspgto();
        }
        private void dinheirotext_TextChanged(object sender, EventArgs e)
        {
            FormataModeda(dinheirotext);
            calcula();
        }
        private void cbodebito_Enter(object sender, EventArgs e)
        {
            cbodebito.BackColor = col;
        }
        private void cbodebito_Leave(object sender, EventArgs e)
        {
            cbodebito.BackColor = Color.White;
        }
        private void ltroco_TextChanged(object sender, EventArgs e)
        {

        }
        private void CarregaFormaspgto()
        {
            string sQuery = null;
            sQuery = sQuery + string.Format("SELECT Id,Descricao,CONVERT(varchar,Id) +' - '+ Descricao tipos FROM P_formaspgto ORDER BY Id");

            OleDbConnection DbConnection = conex.Cnncontrol();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(sQuery, DbConnection);
            da.Fill(dt);
            cbodebito.DataSource = dt;
            cbodebito.DisplayMember = "tipos";
            cbodebito.ValueMember = "Id";
            DbConnection.Close();
        }
        public void calcula()
        {
            double vsubtotal = Convert.ToDouble(lsubtotal.Text);
            apagar = Convert.ToDouble(lapagartext.Text);
            troco = (vsubtotal) - apagar;
            if (troco < 0)
            {
                label2.Text = "A PAGAR";
                ltroco.ForeColor = Color.Red;
                ltroco.Text = troco.ToString("N");
            }
            else
            {
                label2.Text = "TROCO";
                ltroco.ForeColor = Color.Blue;
                ltroco.Text = troco.ToString("N");
            }
        }
        private void calculasubtotal()
        {
            double vdinheiro = Convert.ToDouble((dinheirotext.Text==""?"0":dinheirotext.Text));
            double vcartao = Convert.ToDouble((valorcartaotext.Text==""?"0":valorcartaotext.Text));
            double vsubtotal = Convert.ToDouble(lsubtotal.Text);
            vsubtotal += (vdinheiro + vcartao);
            lsubtotal.Text = vsubtotal.ToString("N");
            valorcartaotext.Text = "0";
            dinheirotext.Text = "0";
        }
        private void dinheirotext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                jogavalor();
            }
            else if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void valorcartaotext_TextChanged(object sender, EventArgs e)
        {
            FormataModeda(valorcartaotext);
            calcula();
        }
        private void valorcartaotext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                jogavalor();
            }
            else if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        private void jogavalor()
        {
            if (Convert.ToDouble(dinheirotext.Text) > 0)
            {
                dataGridView1.Rows.Add("Dinheiro", dinheirotext.Text);
            }
            if (Convert.ToDouble(valorcartaotext.Text) > 0)
            {
                dataGridView1.Rows.Add(cbodebito.Text, valorcartaotext.Text); 
            }
            calculasubtotal();
        }
        private void dinheirotext_Leave(object sender, EventArgs e)
        {
            dinheirotext.BackColor = conex.branco();
        }
        private void dinheirotext_Enter(object sender, EventArgs e)
        {
            dinheirotext.BackColor = conex.amarelo();
        }
        private void valorcartaotext_Leave(object sender, EventArgs e)
        {
            valorcartaotext.BackColor = conex.branco();
        }
        private void valorcartaotext_Enter(object sender, EventArgs e)
        {
            valorcartaotext.BackColor = conex.amarelo();
        }
        private void Recebimento_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    Finaliza_Impressora(true);
                    break;
                case Keys.F2:
                    Finaliza_Impressora(false);
                    break;
                case Keys.Escape:
                    Close();
                    break;
                case Keys.Enter:
                   // calculasubtotal();
                    break;
                   
            }
        }
        private void Finaliza_Impressora(bool fiscal)
        {
            int vcodigofluxo = 0;
            if (dataGridView1.Rows.Count > 0)
            {
                
                if (fiscal)
                {
                    Pdv.linformacoes.Text = "CPF CONSUMIDOR?";
                    String Cpf = Sat();
                    vcodigofluxo = venda.CadastraFluxo(Pdv.lcaixa.Text, Cpf);
                }
                else
                {
                    Impressora_nao_fiscal();
                }
                //========= INICIA GRAVAÇÃO ===================

                
                foreach (DataGridViewRow linha in Pdv.dataGridView1.Rows)
                {
                    venda.CadastraProdutosFluxo(vcodigofluxo, Pdv.dataGridView1[1, linha.Index].Value.ToString(), Convert.ToDouble((Pdv.dataGridView1[5, linha.Index].Value.ToString()==""?"0":Pdv.dataGridView1[5, linha.Index].Value.ToString())), 0);
                    venda.deleteComanda((Pdv.dataGridView1[6, linha.Index].Value.ToString() == null ? "0" : Pdv.dataGridView1[6, linha.Index].Value.ToString()));
                }
                foreach (DataGridViewRow linha in dataGridView1.Rows)
                {
                    venda.CadastraPagementoFluxo(vcodigofluxo, dataGridView1[0, linha.Index].Value.ToString(), Convert.ToDouble(dataGridView1[1, linha.Index].Value.ToString()),Convert.ToInt16((parcelas.Text==""?"1":parcelas.Text)));

                }

                Pdv.linformacoes.Text = "FIM DA IMPRESSÃO";
                Pdv.dataGridView1.Rows.Clear();
                Pdv.totalgeral.Text = "0";
                Pdv.valorunitario.Text = "0";
                Pdv.subtotal.Text = "0";
                this.Close();
            }
            else
            {
                MessageBox.Show("NENHUM VALOR INSERIDO", "ATENÇÂO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
        private void Impressora_nao_fiscal()
        {

            IniFile ini = new IniFile(Application.StartupPath + "\\settings.ini");
            string valor = ini.IniReadValue("Sistema", "PortaImpressora");
            SetDefaultPrinter("MP-4200 TH Virtual COM");
            iRetorno = MP2032.ConfiguraModeloImpressora(7);
            iRetorno = MP2032.IniciaPorta(valor);
            int i_mod = 0;
            //iRetorno = MP2032.ImprimeBitmap(@"D:\PROJETOS\ERNANI\logoledelice.bmp", i_mod);
            //iRetorno = MP2032.ImprimeBmpEspecial(@"D:\PROJETOS\ERNANI\logoledelice.bmp", 50, 50, 0);
            string s_cmdTX = "\r\n";
            iRetorno = MP2032.ComandoTX(s_cmdTX, s_cmdTX.Length);
            iRetorno = MP2032.FormataTX("     PADARIA A MARIANA                  " + "\r\n", 3, 0, 0, 1, 1);
            iRetorno = MP2032.FormataTX("A MARIANA PADARIA LDTA" + "\r\n", 2, 0, 0, 0, 0);
            iRetorno = MP2032.FormataTX("Rua Humberto I,41 - Vila Mariana" + "\r\n", 2, 0, 0, 0, 0);
            iRetorno = MP2032.FormataTX("SÃO PAULO/SP" + "\r\n", 2, 0, 0, 0, 0);
            iRetorno = MP2032.FormataTX("CNPJ: 25168664/0001-95" + "\r\n", 2, 0, 0, 0, 0);
            iRetorno = MP2032.FormataTX("IE:141023752116" + "\r\n", 2, 0, 0, 0, 0);
            iRetorno = MP2032.FormataTX("-------------------------------------------------" + "\r\n", 2, 0, 0, 0, 0);
            iRetorno = MP2032.FormataTX("                 "+DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "\r\n", 2, 0, 0, 0, 0);
            iRetorno = MP2032.FormataTX("-------------------------------------------------" + "\r\n", 2, 0, 0, 0, 0);
            iRetorno = MP2032.FormataTX("   CUPOM NÃO FISCAL                  " + "\r\n", 2, 0, 0, 1, 1);
            iRetorno = MP2032.FormataTX("ITEM CÓDIGO DESCRIÇÃO QTD.UN.VL_UNIT( R$) ST VL_" + "\r\n", 2, 0, 0, 0, 0);
            iRetorno = MP2032.FormataTX("ITEM( R$)" + "\r\n", 2, 0, 0, 0, 0);
            iRetorno = MP2032.FormataTX("-------------------------------------------------" + "\r\n", 2, 0, 0, 0, 0);

            string Nomeproduto;
            string PesoProduto;
            string ValorProduto;
            
            foreach (DataGridViewRow linha in Pdv.dataGridView1.Rows)
            {
                Nomeproduto = Pdv.dataGridView1[0, linha.Index].Value.ToString().Substring(0, 1) + " " + Pdv.dataGridView1[3, linha.Index].Value.ToString();
                Nomeproduto = (Nomeproduto.Length > 25?Nomeproduto.Substring(0,25)+"\r\n":Nomeproduto.PadRight(25, ' '));

                
                if (Pdv.dataGridView1[7, linha.Index].Value != null)
                {
                    PesoProduto = Pdv.dataGridView1[7, linha.Index].Value.ToString() + " g";
                    PesoProduto = PesoProduto.PadRight(5, ' ');
                }
                else
                {
                    PesoProduto = "0";
                }
                PesoProduto =  (Nomeproduto.Length > 25?PesoProduto.PadLeft(40, ' '):PesoProduto.PadLeft(10, ' '));
                ValorProduto = "R$ " + Pdv.dataGridView1[5, linha.Index].Value.ToString();
                ValorProduto =  ValorProduto.PadLeft(10, ' ');
                iRetorno = MP2032.FormataTX(Nomeproduto +PesoProduto+ ValorProduto + "\r\n", 2, 0, 0, 0, 0);
                //BemaFI32.Analisa_iRetorno(IRetorno);
            }
            iRetorno = MP2032.FormataTX("-------------------------------------------------" + "\r\n", 2, 0, 0, 0, 0);
            string valottotal = "R$" + lapagartext.Text;
            valottotal = valottotal.PadLeft(25, ' ');
            iRetorno = MP2032.FormataTX("TOTAL                    " + valottotal + "\r\n", 3, 0, 0, 1, 1);

            //formas de pagamento
            foreach (DataGridViewRow linhas in dataGridView1.Rows)
            {
                string formatapgto = dataGridView1[0, linhas.Index].Value.ToString();
                formatapgto = formatapgto.PadRight(25, ' ');
                string valorformapgto = "R$" + dataGridView1[1, linhas.Index].Value.ToString();
                valorformapgto = valorformapgto.PadLeft(25, ' ');
                iRetorno = MP2032.FormataTX(formatapgto + valorformapgto + "\r\n", 2, 0, 0, 0, 0);
                if (cbodebito.Text == "2 - CARTÃO CREDITO")
                {
                    iRetorno = MP2032.FormataTX("PARCELAS                       " + parcelas.Text + "\r\n", 2, 0, 0, 0, 0);
                }
            }
            if (Convert.ToDouble(ltroco.Text) > 0)
            {
                string troco = "R$" + ltroco.Text;
                troco = troco.PadLeft(25, ' ');
                iRetorno = MP2032.FormataTX("TROCO                    " + troco + "\r\n", 2, 0, 0, 0, 0);
            }
            iRetorno = MP2032.FormataTX("-------------------------------------------------" + "\r\n", 2, 0, 0, 0, 0);
            iRetorno = MP2032.FormataTX("      OBRIGADO E VOLTE SEMPRE" + "\r\n", 2, 0, 0, 0, 0);
            iRetorno = MP2032.FormataTX("-------------------------------------------------" + "\r\n", 2, 0, 0, 0, 0);

            iRetorno = MP2032.AcionaGuilhotina(1);
            if (iRetorno > 0)
            {
                venda.deleteComanda(Pdv.comanda.Text);
            }
        }
        private void Impressora_fiscal()
        {
            double TotalImposto = 0;
            if (MessageBox.Show("Deseja usar CGC/CPF do Consumidor?", "PDV", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FormDialog MyDLG = new FormDialog();
                MyDLG.Text = "CPF/CGC";
                MyDLG.textBoxRetorno.Focus();
                if (MyDLG.ShowDialog(this) == DialogResult.OK)
                {
                    Pdv.linformacoes.Text = "IMPRINDO CUPOM";
                    IRetorno = BemaFI32ImpressoraFiscal.Bematech_FI_AbreCupom(MyDLG.textBoxRetorno.Text);
                    BemaFI32.Analisa_iRetorno(IRetorno);
                }
                MyDLG.Dispose();
            }
            else
            {
                Pdv.linformacoes.Text = "IMPRINDO CUPOM";
                IRetorno = BemaFI32ImpressoraFiscal.Bematech_FI_AbreCupom("");
                BemaFI32.Analisa_iRetorno(IRetorno);
            }
            if (BemaFI32ImpressoraFiscal.Analisa_iRetorno(IRetorno) > 0)
            {
                foreach (DataGridViewRow linha in Pdv.dataGridView1.Rows)
                {
                    TotalImposto += venda.CalculaImposto(Convert.ToInt32(Pdv.dataGridView1[1, linha.Index].Value.ToString()));
                    IRetorno = BemaFI32ImpressoraFiscal.Bematech_FI_VendeItem(Pdv.dataGridView1[1, linha.Index].Value.ToString(), Pdv.dataGridView1[3, linha.Index].Value.ToString(), "FF", "I", "1", 2, Pdv.dataGridView1[5, linha.Index].Value.ToString(), "%", "0");
                    BemaFI32ImpressoraFiscal.Analisa_iRetorno(IRetorno);
                }

                IRetorno = BemaFI32ImpressoraFiscal.Bematech_FI_IniciaFechamentoCupom("A", "%", "0");
                BemaFI32ImpressoraFiscal.Analisa_iRetorno(IRetorno);

                foreach (DataGridViewRow linhas in dataGridView1.Rows)
                {
                    IRetorno = BemaFI32ImpressoraFiscal.Bematech_FI_EfetuaFormaPagamento(dataGridView1[0, linhas.Index].Value.ToString(), dataGridView1[1, linhas.Index].Value.ToString());
                }

                BemaFI32ImpressoraFiscal.Analisa_iRetorno(IRetorno);
                IRetorno = BemaFI32ImpressoraFiscal.Bematech_FI_TerminaFechamentoCupom("Val Aprox dos Tributos - " + TotalImposto);
                BemaFI32ImpressoraFiscal.Analisa_iRetorno(IRetorno);
            }
            else
            {
                MessageBox.Show("NAO FOI POSSIVELA IMPRESSÃO");
            }
            if (IRetorno > 0)
            {
                venda.deleteComanda(Pdv.comanda.Text);
            }
        }
        private String Sat()
        {
            #region ABRECUPOM
            string cpf = "";
            double TotalImposto = 0;
            if (MessageBox.Show("Deseja usar CGC/CPF do Consumidor?", "PDV", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FormDialog MyDLG = new FormDialog();
                MyDLG.Text = "CPF/CGC";
                if (MyDLG.ShowDialog(this) == DialogResult.OK)
                {
                    Pdv.linformacoes.Text = "IMPRINDO CUPOM";
                    cpf = MyDLG.textBoxRetorno.Text;
                    iRetorno = BemaFI32.Bematech_FI_AbreCupomMFD(MyDLG.textBoxRetorno.Text, "", "");
                }
                else
                {
                    iRetorno = BemaFI32.Bematech_FI_AbreCupomMFD("", "", "");
                }
                MyDLG.Dispose();
            }
            else
            {
                iRetorno = BemaFI32.Bematech_FI_AbreCupomMFD("", "", "");
            }
            BemaFI32.Analisa_iRetorno(iRetorno);
            //MessageBox.Show("ABRE CUPOM"+iRetorno.ToString());
            iRetorno = BemaFI32.Bematech_FI_RetornoImpressoraMFD(ref ACK, ref ST1, ref ST2, ref ST3);
            //MessageBox.Show("ACK: " + ACK + " - " + "ST1: " + ST1 + " - " + "ST2: " + ST2 + " - " + "ST3: " + ST3);
            #endregion

            #region ITEM
            if (BemaFI32.Bematech_FI_RetornoImpressoraMFD(ref ACK, ref ST1, ref ST2, ref ST3) > 0)
            {
                foreach (DataGridViewRow linha in Pdv.dataGridView1.Rows)
                {
                    string Codigo = Pdv.dataGridView1[1, linha.Index].Value.ToString();
                    string EAN13 = "";
                    string Descricao = Pdv.dataGridView1[3, linha.Index].Value.ToString();
                    string IndiceDepartamento = "00";
                    string Aliquota = "F1";
                    string UnidadeMedida = "UN";
                    string TipoQuantidade = "I";// (Pdv.dataGridView1[8, linha.Index].Value.ToString() == "2 - Inteiro" ? "I" : "F");
                    string CasasDecimaisQtde = "3";
                    string Quantidade = Pdv.dataGridView1[2, linha.Index].Value.ToString().Replace("0", "").PadRight(4, '0'); //"1000";
                    string CasasDecimaisValor = "2";
                    string ValorUnitario = Pdv.dataGridView1[5, linha.Index].Value.ToString();//"1,00";
                    string TipoDesconto = "$";
                    string ValorAcrescimo = "0,00";
                    string ValorDesconto = "0,00";
                    string ArredondaTrunca = "A";
                    string NCM = "22011000";
                    string CFOP = "5403";
                    string InformacaoAdicional = "OBRIGADO E VOLTE SEMPRE!!!";
                    string OrigemProduto = "0";
                    string CST_ICMS = "60";
                    string CodigoIBGE = "";
                    string CodigoISS = "";
                    string NaturezaOperacaoISS = "";
                    string IndicadorIncentivoFiscal = "";
                    string ItemListaServico = "1234";
                    string CSOSN = "102"; //--> Simples Nacional
                    string ValorBaseCalculoSimples = "0";
                    string ValorICMSRetidoSimples = "0";
                    string ModalidadeBaseCalculo = "0";
                    string PercentualReducaoBase = "0";
                    string ModalidadeBC = "0";
                    string PercentualMargemICMS = "0";
                    string PercentualBCICMS = "0";
                    string ValorReducaoBCICMS = "0";
                    string ValorAliquotaICMS = "0";
                    string ValorICMS = "0";
                    string ValorICMSDesonerado = "0";
                    string MotivoDesoneracaoICMS = "0";
                    string AliquotaCalculoCredito = "0";
                    string ValorCreditoICMS = "0";
                    string ValorTotalTributos = ""; //tributos
                    string CSTPIS = "04";
                    string BaseCalculoPIS = "";
                    string AliquotaPIS = "";
                    string ValorPIS = "";
                    string QuantVendidaPIS = "";
                    string ValorAliquotaPIS = "";
                    string CSTCOFINS = "04";
                    string BaseCalculoCOFINS = "";
                    string AliquotaCOFINS = "";
                    string ValorCOFINS = "";
                    string QunatVendidaCOFINS = "";
                    string ValorAliquotaCOFINS = "";
                    string Reservado01 = "";
                    string Reservado02 = "";
                    string Reservado03 = "";
                    string Reservado04 = "";
                    string Reservado05 = "";
                    string Reservado06 = "";
                    string Reservado07 = "";
                    string Reservado08 = "";
                    string Reservado09 = "";
                    string Reservado10 = "";
                    

                    iRetorno = BemaFI32.Bematech_FI_VendeItemCompleto(Codigo, EAN13, Descricao, IndiceDepartamento, Aliquota, UnidadeMedida, TipoQuantidade, CasasDecimaisQtde, Quantidade, CasasDecimaisValor, ValorUnitario, TipoDesconto, ValorAcrescimo, ValorDesconto, ArredondaTrunca, NCM, CFOP, InformacaoAdicional, CST_ICMS, OrigemProduto, ItemListaServico, CodigoISS, NaturezaOperacaoISS, IndicadorIncentivoFiscal, CodigoIBGE, CSOSN, ValorBaseCalculoSimples, ValorICMSRetidoSimples, ModalidadeBaseCalculo, PercentualReducaoBase, ModalidadeBC, PercentualMargemICMS, PercentualBCICMS, ValorReducaoBCICMS, ValorAliquotaICMS, ValorICMS, ValorICMSDesonerado, MotivoDesoneracaoICMS, AliquotaCalculoCredito, ValorCreditoICMS, ValorTotalTributos, CSTPIS, BaseCalculoPIS, AliquotaPIS, ValorPIS, QuantVendidaPIS, ValorAliquotaPIS, CSTCOFINS, BaseCalculoCOFINS, AliquotaCOFINS, ValorCOFINS, QunatVendidaCOFINS, ValorAliquotaCOFINS, Reservado01, Reservado02, Reservado03, Reservado04, Reservado05, Reservado06, Reservado07, Reservado08, Reservado09, Reservado10);
                    BemaFI32.Analisa_iRetorno(iRetorno);
                    //MessageBox.Show("VendeItemCompleto: " + iRetorno);
                    iRetorno = BemaFI32.Bematech_FI_RetornoImpressoraMFD(ref ACK, ref ST1, ref ST2, ref ST3);
                    //MessageBox.Show("ACK: " + ACK + " - " + "ST1: " + ST1 + " - " + "ST2: " + ST2 + " - " + "ST3: " + ST3);
                }
            }



            #endregion
            
            #region INICIO FECHAMENTO
            iRetorno = BemaFI32.Bematech_FI_IniciaFechamentoCupom("A", "%", "00");
            BemaFI32.Analisa_iRetorno(iRetorno);
            //MessageBox.Show("IniciaFechamentoCupom: " + iRetorno);
            iRetorno = BemaFI32.Bematech_FI_RetornoImpressoraMFD(ref ACK, ref ST1, ref ST2, ref ST3);
            //MessageBox.Show("ACK: " + ACK + " - " + "ST1: " + ST1 + " - " + "ST2: " + ST2 + " - " + "ST3: " + ST3);
            #endregion

            #region FORMA PAGAMENTO
            foreach (DataGridViewRow linhas in dataGridView1.Rows)
            {
                IRetorno = BemaFI32ImpressoraFiscal.Bematech_FI_EfetuaFormaPagamento(dataGridView1[0, linhas.Index].Value.ToString(), dataGridView1[1, linhas.Index].Value.ToString());
            }
            BemaFI32.Analisa_iRetorno(iRetorno);
            //MessageBox.Show("EfetuaFormaPagamento: " + iRetorno);
            iRetorno = BemaFI32.Bematech_FI_RetornoImpressoraMFD(ref ACK, ref ST1, ref ST2, ref ST3);
            //MessageBox.Show("ACK: " + ACK + " - " + "ST1: " + ST1 + " - " + "ST2: " + ST2 + " - " + "ST3: " + ST3);
            #endregion

            #region DADOS Software HOUSE
            string cnpj = "19823348000107";
            string assinaturaSW = "QEd6c058zUvRZ/To5BRZcLj6a1bwu0bx1pRhYyR50k2DxYnxcrnt9dfazWDjyaWQYS8/YB1xQFnmxXOJOkY+/YbKXn0g+SODZ1ptlzL0s1vTQxn/qKZCPcSC+vaBp7J09kNsegffT5JIF93QcXfo+IoM52zALIGz+rwE/BA5vZUVA4YnF3bl8NztG+08W7Ziz1s+GHfc+UGBxAIefAsb8bNPdJFj32fcwLCmhvTdAg0VpKi9F6rdiOkcYVo9I2Ej0tZIAiGxUO84dWm8M28hF+Rmr+QlwRPnKbWGNCGT3Gy1pQzYk28wM/IuaDPEcMrkVrQWeXHEZA22zhMYvA+6ww==";
            iRetorno = BemaFI32.Bematech_FI_DadosSoftwareHouseSAT(cnpj, assinaturaSW);
            //MessageBox.Show("DADOS DA SH"+ iRetorno);
            iRetorno = BemaFI32.Bematech_FI_RetornoImpressoraMFD(ref ACK, ref ST1, ref ST2, ref ST3);
            #endregion

            #region FECHAMENTO
            iRetorno = BemaFI32.Bematech_FI_TerminaFechamentoCupom("OBRIGADO E VOLTE SEMPRE!");
            BemaFI32.Analisa_iRetorno(iRetorno);
            //MessageBox.Show("TerminaFechamentoCupom: " + iRetorno);
            iRetorno = BemaFI32.Bematech_FI_RetornoImpressoraMFD(ref ACK, ref ST1, ref ST2, ref ST3);
            #endregion
            return cpf;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void lsubtotal_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void cbodebito_TextChanged(object sender, EventArgs e)
        {
            if (cbodebito.Text == "2 - CARTÃO CREDITO")
            {
                parcelas.Enabled = true;
            }
            else
            {
                parcelas.Enabled = false;
            }
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Finaliza_Impressora(true);
        }
        private void parcelas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Finaliza_Impressora(false);
        }

    }
}
