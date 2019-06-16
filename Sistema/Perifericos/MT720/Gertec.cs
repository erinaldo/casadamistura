using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.OleDb;
using Conn;
namespace Perifericos.MT720
{
    public partial class Gertec : Form
    {
        public Gertec()
        {
            // Inicializa algumas variaveis
            for (int i = 0; i <= 255; i++)
            {
                PedidoG[i].Cesta = new structs.Produto[256];
                palavra[i] = "";
            }
            InitializeComponent();
        }

        Conn.Class1 conex = new Conn.Class1();

        private pmtger Hpmtg;
        private structs structs;
        private Ids ids;
        /****Variaveis globais****/
        int COMUNICATION_MSG = 0x0400 + 1;
        int CONNECT_MSG = 0x0400 + 2;

        int[] passo = new int[256];
        string[] palavra = new string[256];
        public string strbanco;
        int drok;
        int[] tabConect = new int[256];
        byte[] buf = new byte[256];
        string buf2;
        int LParamLo;
        int LParamHi;
        int conta = 0;
        public int[] ipdll = new int[255];
        public int[] NumeroProd = new int[256];
        public structs.PedidoType[] PedidoG = new structs.PedidoType[256];
        bool deleta;

        private void Gertec_Load(object sender, EventArgs e)
        {
            structs = new structs();
            Hpmtg = new pmtger();
            ids = new Ids();

            if (pmtger.mt_startserver(this.Handle, CONNECT_MSG, COMUNICATION_MSG) > 0)
            {
                lbInform.Text = "";
                btIniciar.Text = "Terminar";
            }
            else
            {
                lbInform.Text = "Falha ao iniciar servidor";
            }
        }
        private void btIniciar_Click(object sender, EventArgs e)
        {
            if (btIniciar.Text != "INICIAR")
            {
                pmtger.mt_finishserver();
                btIniciar.Text = "INICIAR";
            }
            else
            {
                if (pmtger.mt_startserver(this.Handle, CONNECT_MSG, COMUNICATION_MSG) > 0)
                {
                    lbInform.Text = "";
                    btIniciar.Text = "Terminar";
                }
                else
                {
                    lbInform.Text = "Falha ao iniciar servidor";
                }
            }
        }
        public void TimerPasso(int IP)
        {
            string MsgStr;
            try
            {
                /* switch (passo[IP])...: Verifica em qual fase o microterminal esta e mostra 
                 * a proxima tela ou a tela anterior */
                switch (passo[IP])
                {
                    case 0:
                        passo[IP]++;
                        break;
                    case 1:
                        pmtger.mt_formfeed(IP);
                        //Envia a 1ª tela ao terminal (Operador)
                        MsgStr = "Operador:";
                        pmtger.mt_dispstr(IP, MsgStr);
                        pmtger.mt_gotoxy(IP, 2, 1);
                        Thread.Sleep(200);
                        
                        break;
                    case 2:
                        pmtger.mt_formfeed(IP);
                        if (deleta)
                        {
                            MsgStr = "Comanda a Remover:";

                        }
                        else
                        {
                            MsgStr = "Comanda:";
                        }
                        

                        pmtger.mt_dispstr(IP, MsgStr);
                        Thread.Sleep(200);
                          pmtger.mt_gotoxy(IP, 2, 1);
                        break;
                    case 3:
                        pmtger.mt_formfeed(IP);
                        //Envia a 5ª tela ao terminal (Produto)
                        if (deleta)
                        {
                            MsgStr = "Produto a Remover:";
                            

                        }
                        else
                        {
                            MsgStr = "Produto:";
                        }
                        
                        pmtger.mt_dispstr(IP, MsgStr);
                        Thread.Sleep(200);
                        pmtger.mt_gotoxy(IP, 2, 1);
                        break;
                    case 4:
                        // Envia a tela de pedido
                        // Enviando a 1ª linha com a descrição do produto pedido
                        pmtger.mt_formfeed(IP);
                        MsgStr = PedidoG[IP].Cesta[NumeroProd[IP]].DescricaoProduto;
                        pmtger.mt_dispstr(IP, MsgStr);

                        // Enviando a 2ª linha com o valor do produto pedido
                        pmtger.mt_linefeed(IP);
                        pmtger.mt_carret(IP);
                        MsgStr = (PedidoG[IP].Cesta[NumeroProd[IP]].Valor).ToString("C");
                        pmtger.mt_dispstr(IP, MsgStr);

                        // Incluindo o local de digitação de Qtd posicionando o cursor
                        pmtger.mt_gotoxy(IP, 2, 10);
                        MsgStr = "Qtd:";
                        pmtger.mt_dispstr(IP, MsgStr);
                        Thread.Sleep(200);
                        break;
                }
            }
            catch
            {
            }
        }
        private void timerVConectados_Tick(object sender, EventArgs e)
        {
            int j, k;

            k = VConectados.Items.Count;
            for (j = 1; j <= k; j++)
            {
                pmtger.mt_sendlive(j);
            }
        }
        protected override void WndProc(ref Message m)
        {
            //recebe mensagens enviadas pelo terminal
            if (m.Msg == COMUNICATION_MSG)
            {
                // terminal que enviou a informação
                LParamLo = (m.LParam.ToInt32() << 16) >> 16; // lo order word
                LParamHi = m.LParam.ToInt32() >> 16; // hi order word
                structs.Arg_Com_SetupSerial configserial = new structs.Arg_Com_SetupSerial();
                configserial.Setup = new structs.TSetupSerial();

                byte[] buf = new byte[256];
                string msg;
                string buf2;
                int ptam, k, j;
                int[] com = new int[1];
                byte[] recSerial = new byte[1];
                

                /** Recebe as teclas que foram digitadas **/
                if ((int)m.WParam == Ids.IDcGetCharTerm)
                {
                    if ((pmtger.mt_getkey(LParamLo, buf)) > 0)
                    {
                        // buf contem o valor da tecla
                        buf2 = null;
                        buf2 = System.Text.ASCIIEncoding.ASCII.GetString(buf, 0, 1);


                        if ((int.TryParse(buf2, out k)) || (buf2 == "0"))
                        {
                            palavra[LParamLo] = palavra[LParamLo] + buf2;
                            pmtger.mt_dispstr(LParamLo, buf2);
                        }
                       
                        else if (buf[0] == 8 || (buf[0] == 13 || buf[0] == 27))
                        {
                            /************************************************************
                            *   Se a tecla foi Backspace segue o seguinte procedimento	*
                            *************************************************************/
                            
                            if (buf[0] == 8)
                            {

                                deleta = true;
                                
                            }

                                /***********************************************************
                                *   Se a tecla foi ENTER segue o seguinte procedimento     *
                                ************************************************************/
                            
                            else if (buf[0] == 13)
                            {
                                if (buf[0] == 8)
                                {
                                    passo[LParamLo]--;
                                }
                                switch (passo[LParamLo])
                                {
                                    case 0:
                                        passo[LParamLo] = 1;
                                        TimerPasso(LParamLo);
                                        palavra[LParamLo] = "";
                                        break;
                                    //==================================== OPERADOR =======================================================================
                                    case 1:
                                        if (palavra[LParamLo].Length == 0)
                                        {
                                            TimerPasso(LParamLo);
                                            palavra[LParamLo] = "";

                                        }
                                        else
                                            //Consulta o codigo do operador
                                            if (LancamentoUsuario(palavra[LParamLo], LParamLo) == 1)
                                            {
                                                passo[LParamLo]++;
                                                TimerPasso(LParamLo);
                                                palavra[LParamLo] = "";

                                            }
                                            else
                                            {
                                                //Caso não tenha um operador envia OPERADOR iNVALIDO!!!
                                                pmtger.mt_formfeed(LParamLo);
                                                msg = "    OPERADOR";
                                                pmtger.mt_dispstr(LParamLo, msg);

                                                pmtger.mt_linefeed(LParamLo);
                                                pmtger.mt_carret(LParamLo);
                                                msg = "    INVALIDO!!!";
                                                pmtger.mt_dispstr(LParamLo, msg);
                                                Thread.Sleep(300);
                                                TimerPasso(LParamLo);
                                                palavra[LParamLo] = "";
                                            }
                                        break;
                                    // ============================================== CARTAO ==========================================================
                                    case 2:
                                        if (palavra[LParamLo].Length == 0)
                                        {
                                            TimerPasso(LParamLo);
                                            palavra[LParamLo] = "";
                                        }
                                        else
                                        {
                                            //Consulta o codigo do cartao(comanda)
                                            if (LancamentoCartao(palavra[LParamLo], LParamLo) == 1)
                                            {
                                                NumeroProd[LParamLo] = 1;
                                                passo[LParamLo]++;
                                                TimerPasso(LParamLo);
                                                palavra[LParamLo] = "";
                                            }
                                            else
                                            {
                                                //Caso não tenha um cartão válido envia CARTAO INVALIDO!!!
                                                pmtger.mt_formfeed(LParamLo);
                                                msg = "     COMANDA";
                                                pmtger.mt_dispstr(LParamLo, msg);
                                                Thread.Sleep(100);
                                                pmtger.mt_linefeed(LParamLo);
                                                pmtger.mt_carret(LParamLo);
                                                msg = "    INVALIDO!!!";
                                                pmtger.mt_dispstr(LParamLo, msg);
                                                Thread.Sleep(300);
                                                TimerPasso(LParamLo);
                                                palavra[LParamLo] = "";
                                            }
                                        }
                                        break;
//================================PRODUTO ===============================================
                                    case 3:
                                        //Consulta o codigo do operador
                                        if (LancamentoProduto(palavra[LParamLo], NumeroProd[LParamLo], LParamLo) == 1)
                                        {
                                            passo[LParamLo]++;
                                            TimerPasso(LParamLo);
                                            palavra[LParamLo] = "";

                                        }
                                        else
                                        {
                                            //Caso não tenha um operador envia OPERADOR iNVALIDO!!!
                                            pmtger.mt_formfeed(LParamLo);
                                            msg = "    PRODUTO";
                                            pmtger.mt_dispstr(LParamLo, msg);

                                            pmtger.mt_linefeed(LParamLo);
                                            pmtger.mt_carret(LParamLo);
                                            msg = "    INVALIDO!!!";
                                            pmtger.mt_dispstr(LParamLo, msg);
                                            Thread.Sleep(300);
                                            TimerPasso(LParamLo);
                                            palavra[LParamLo] = "";
                                        }
                                        break;
                                    case 4:
                                        if (palavra[LParamLo].Length == 0)
                                        {
                                            passo[LParamLo]++;
                                            TimerPasso(LParamLo);
                                            palavra[LParamLo] = "";
                                        }
                                        else if (LancamentoProdutoCesta(float.Parse(palavra[LParamLo]), NumeroProd[LParamLo], LParamLo) == 1)
                                        {
                                            NumeroProd[LParamLo]++;
                                            if (deleta)
                                            {
                                                Deleta();
                                            }
                                            else
                                            {
                                                grava();
                                            }
                                            palavra[LParamLo] = "";
                                            passo[LParamLo] = 0;
                                        }

                                        break;
                                    
                                }

                              }
                            else if (buf[0] == 27)
                            {
                                TimerPasso(LParamLo);
                            }
                            
                        }

                    }
                    else
                    {
                        buf2 = "Falha no recebimento!!!";
                        pmtger.mt_dispstr(LParamLo, buf2);
                    }
                }

            }
            //recebe mensagens quando um terminal conectou/desconectou
            else if (m.Msg == CONNECT_MSG)
            {

                string addr;
                addr = "";
                conta++;
                addr = pmtger.mt_ipfromid(conta);
                if (addr != null)
                {
                    //Recebe o IP do terminal e adiciona na lista de terminais conectados
                    VConectados.Items.Add(addr);
                }
                else
                {
                    conta--;
                }

            }
            else if (m.Msg == CONNECT_MSG)
            {

                string addr;
                addr = "";
                conta++;
                addr = pmtger.mt_ipfromid(conta);
                if (addr != null)
                {
                    //Recebe o IP do terminal e adiciona na lista de terminais conectados
                    VConectados.Items.Add(addr);
                }
                else
                {
                    conta--;
                }

            }
            // forward message to base WndProc
            base.WndProc(ref m);
        }
        private void grava()
        {
            Querys grava = new Querys();
            for (int i = 1; i <= NumeroProd[LParamLo] - 1; i++)
            {
                grava.Cadastra(PedidoG[LParamLo].Card.codCartao.ToString(), PedidoG[LParamLo].CodUsuario.ToString(), PedidoG[LParamLo].Cesta[i].CodProduto.ToString(), PedidoG[LParamLo].Cesta[i].Quantidade.ToString(), "ABERTO");

            }
            
        }
        private void Deleta()
        {
            Querys deletacomanda = new Querys();
            for (int i = 1; i <= NumeroProd[LParamLo] - 1; i++)
            {
                deletacomanda.delete(PedidoG[LParamLo].Card.codCartao.ToString(), PedidoG[LParamLo].Cesta[i].CodProduto.ToString());
                
            }
            deleta = false;

        }
        public byte LancamentoUsuario(string CodUsuario, int id)
        {
            string strselect;
            drok = 0;

            try
            {

                //Armazena a select a ser consultada
                strselect = ("SELECT HANDLE,NOME,FUNCAO,LOGIN FROM p_usuarios WHERE HANDLE = " + CodUsuario);
                OleDbConnection con = conex.Cnncontrol();
                OleDbCommand cmd = new OleDbCommand(strselect, con);
                cmd.CommandType = CommandType.Text;
                OleDbDataReader dr = cmd.ExecuteReader();

                //Verifica se há informações encontradas e as armazena para utilização futura
                while (dr.Read())
                {
                    PedidoG[id].CodUsuario = dr.GetInt32(dr.GetOrdinal("HANDLE"));
                    PedidoG[id].Usuario = dr.GetString(dr.GetOrdinal("NOME"));
                    PedidoG[id].FuncaoID = dr.GetInt32(dr.GetOrdinal("FUNCAO"));
                    if ((PedidoG[id].FuncaoID == 1) || (PedidoG[id].FuncaoID == 2)) drok = 1;
                }
                if (drok == 1)
                {
                    dr.Close();
                    con.Close();
                    return 1;
                }
                else
                {

                    dr.Close();
                    con.Close();
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
        public byte LancamentoProduto(string Produto, int NumeroProdutos, int id)
        {
            string strguia;
            drok = 0;
            try
            {
                //Armazena a select a ser consultada
                strguia = ("SELECT HANDLE,NOME,PRECO_VENDA FROM p_produtos WHERE CODIGO_BARRAS = '" + Produto + "'");
                OleDbConnection con = conex.Cnncontrol();
                OleDbCommand cmd = new OleDbCommand(strguia, con);
                cmd.CommandType = CommandType.Text;
                OleDbDataReader dr = cmd.ExecuteReader();

                //Verifica se há arquivos para ler e os armazena para uso futuro
                while (dr.Read())
                {
                    PedidoG[id].Cesta[NumeroProdutos].CodProduto = Convert.ToInt32(dr.GetValue(0));
                    PedidoG[id].Cesta[NumeroProdutos].DescricaoProduto = Convert.ToString(dr.GetValue(1));
                    PedidoG[id].Cesta[NumeroProdutos].Valor = Convert.ToDouble(dr.GetValue(2));
                    drok = 1;
                }
                if (drok == 1)
                {
                    dr.Close();
                    con.Close();
                    return 1;
                }
                else
                {
                    dr.Close();
                    con.Close();
                    return 0;
                }
            }
            catch
            {
                return 0;
            }

        }
        public byte LancamentoCartao(string Cartao, int id)
        {
            if (Cartao != "")
            {
                PedidoG[id].Card.codCartao = Cartao;
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public byte LancamentoProdutoCesta(float Quantidade, int NumeroProduto, int id)
        {
            try
            {
                //Verifica a quantidade
                if (Quantidade != 0)
                {
                    PedidoG[id].Cesta[NumeroProduto].Quantidade = Quantidade;
                    return (1);
                }
                else
                {
                    return (0);
                }
            }
            catch
            {
                return 0;
            }
        }
        

    }
}
