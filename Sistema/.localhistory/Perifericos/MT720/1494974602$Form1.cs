using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using System.Threading;
using System.Globalization;
using System.IO;
using Conn;


namespace Perifericos
{
  
    public partial class Form1 : Form
    {

        private pmtger Hpmtg;
        private structs structs;
        private Ids ids;
       // private estrutura estruturas = new estrutura();

        Conn.Class1 conex = new Class1();

        /****Variaveis globais****/
        int COMUNICATION_MSG = 0x0400 + 1 ;
        int CONNECT_MSG = 0x0400 + 2;
        int [] passo = new int [256];
        string[] palavra = new string[256];
        int [] peso = new int[256];
        double vpeso;
	    int cancela;
        public string strbanco;
        int drok, pesok;
        int LParamLo;
        int LParamHi;
        int conta = 0;
        bool deletar;
        bool totaliza;
        bool deletacomanda;
        int[] tabConect = new int[256];
        public int[] ipdll = new int[255];
        public int [] NumeroProd = new int[256];
        public structs.PedidoType[] PedidoG = new structs.PedidoType[256];
       
        /*****************************/

        public Form1()
        {                        

            // Inicializa algumas variaveis
            for (int i = 0; i <= 255; i++)
            {
                PedidoG[i].Cesta = new structs.Produto[256];
                palavra[i] = "";
            }
            peso[0] = 0;
            InitializeComponent();
           

        }
        private void btIniciar_Click(object sender, EventArgs e)
        {   
            //Efetua a abertura da DLL
            if (btIniciar.Text == "Iniciar")
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
            // Se o menu estiver como "Terminar" a DLL é finalizada
            else
            {
                pmtger.mt_finishserver();
               btIniciar.Text = "Iniciar";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            structs = new structs();
            Hpmtg = new pmtger();
            ids = new Ids(); 
            //estruturas = new estrutura();
            
            for (int i = 0; i <= 255; i++)
            {
                for (int j = 0; j <= 255; j++)
                    PedidoG[i].Cesta[j].Obs = "";
            }
            if (pmtger.mt_startserver(this.Handle, CONNECT_MSG, COMUNICATION_MSG) > 0)
            {
                lbInform.Text = "";
                btIniciar.Text = "Terminar";

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
                        Thread.Sleep(200);
                        break;
                    case 2:
                        pmtger.mt_formfeed(IP);
                        MsgStr = "Cartao:";
                        pmtger.mt_dispstr(IP, MsgStr);
                        Thread.Sleep(200);
                        break;
                    case 3:
                        pmtger.mt_formfeed(IP);
                        //Envia a 5ª tela ao terminal (Produto)
                        MsgStr = "Produto:";
                        pmtger.mt_dispstr(IP, MsgStr);
                        pmtger.mt_gotoxy(IP, 2, 1);
                        Thread.Sleep(200);
                        break;
                    case 4:
                        pmtger.mt_formfeed(IP);
                        //Envia a 5ª tela ao terminal (Produto)
                        MsgStr = "Qtde a ser retirado:";
                        pmtger.mt_dispstr(IP, MsgStr);
                        pmtger.mt_gotoxy(IP, 2, 1);
                        Thread.Sleep(200);
                        break;

                }
            }
            catch
            {
            }
        }
        protected override void WndProc(ref Message m)
        {
            
            //recebe mensagens enviadas pelo terminal
            if (m.Msg == COMUNICATION_MSG)
            {
                // terminal que enviou a informação
                LParamLo = (m.LParam.ToInt32() << 16) >> 16; // lo order word
                LParamHi =  m.LParam.ToInt32()        >> 16; // hi order word
                structs.Arg_Com_SetupSerial configserial = new structs.Arg_Com_SetupSerial();
                configserial.Setup = new structs.TSetupSerial();
               
                byte[] buf = new byte[256];
                string msg;
                string buf2;
                int ptam, k, j;
                int[] com = new int[1];
                byte [] bufbalanc = new byte[256];
                byte [] recSerial = new byte[1];
                byte[] pesoserial = new byte[256];
                recSerial[0] = 0;

                /** Recebe as teclas que foram digitadas **/
                if ((int)m.WParam == Ids.IDcGetCharTerm){
                    if ((pmtger.mt_getkey(LParamLo, buf)) > 0)
                    {
                        // buf contem o valor da tecla
                        buf2 = null;
                        buf2 = System.Text.ASCIIEncoding.ASCII.GetString(buf,0,1);
                        

                        if ((int.TryParse(buf2,out k)) || (buf2 =="0"))
                        {
                            palavra[LParamLo] = palavra[LParamLo] + buf2;
                            pmtger.mt_dispstr(LParamLo, buf2);
                        }



                        if (buf[0] == 8 || (buf[0] == 13 || buf[0] == 27 || buf[0] == 47 || buf[0] == 42 || buf[0] == 45))
                        {
                            #region APAGADIGITOS_BACKSPACE
                            if (buf[0] == 8)
                            {
                                if (peso[LParamLo] == 0)
                                {
                                    if (palavra[LParamLo].Length > 0)
                                    {
                                        ptam = (palavra[LParamLo].Length);
                                        palavra[LParamLo] = palavra[LParamLo].Substring(0, ptam - 1);
                                        pmtger.mt_backspace(LParamLo);
                                    }
                                }
                            }
                            #endregion

                            if (totaliza)
                            {
                                pmtger.mt_formfeed(LParamLo);
                                string totalcomanda = PegaTotalComanda(palavra[LParamLo], LParamLo, strbanco);
                                if(totalcomanda != ""){
                                    msg = "TOTAL COMANDA:" + totalcomanda;
                                }else{
                                    msg = "COMANDA VAZIA !!!";
                                }
                                pmtger.mt_dispstr(LParamLo, msg);
                                Thread.Sleep(100);
                                totaliza = false;
                                return;
                            }
                            if (deletacomanda)
                            {
                                if(Detelarcomanda(palavra[LParamLo]))
                                {
                                    pmtger.mt_formfeed(LParamLo);
                                    msg = "   COMANDA";
                                    pmtger.mt_dispstr(LParamLo, msg);

                                    pmtger.mt_linefeed(LParamLo);
                                    pmtger.mt_carret(LParamLo);
                                    msg = "   EXCLUIDA";
                                    pmtger.mt_dispstr(LParamLo, msg);

                                    Thread.Sleep(200);

                                    passo[LParamLo] = 1;     //volta para Cartão:
                                    TimerPasso(LParamLo);
                                    palavra[LParamLo] = "";
                                    deletacomanda = false;
                                    return;
                                }
                            }
                            else if (buf[0] == 13)
                            {
                                //Verificação de cancelamento de item
                                if (cancela == 1)
                                {
                                    passo[LParamLo]--;
                                    palavra[LParamLo] = "";
                                    NumeroProd[LParamLo] = 1;
                                    TimerPasso(LParamLo);
                                    cancela = 0;

                                }

                                if (peso[LParamLo] == 1)
                                {
                                    peso[LParamLo] = 0;
                                }
                                switch (passo[LParamLo])
                                {
                                    case 0:
                                        passo[LParamLo] = 1;
                                        TimerPasso(LParamLo);
                                        palavra[LParamLo] = "";
                                        break;
                                    //{****OPERADOR****}
                                    case 1:
                                        if (palavra[LParamLo].Length == 0)
                                        {
                                            TimerPasso(LParamLo);
                                            palavra[LParamLo] = "";

                                        }
                                        else
                                            //Consulta o codigo do operador
                                            if (LancamentoUsuario(palavra[LParamLo], LParamLo, strbanco) == 1)
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
                                    /***CARTAO***/
                                    case 2:
                                        if (palavra[LParamLo].Length == 0)
                                        {
                                            TimerPasso(LParamLo);
                                            palavra[LParamLo] = "";
                                        }
                                        else
                                        {
                                            //Consulta o codigo do cartao(comanda)
                                            if (LancamentoCartao(palavra[LParamLo], LParamLo, strbanco) == 1)
                                            {
                                                passo[LParamLo]++;
                                                palavra[LParamLo] = "";
                                                NumeroProd[LParamLo] = 1;
                                                TimerPasso(LParamLo);

                                            }
                                            else
                                            {
                                                //Caso não tenha um cartão válido envia CARTAO INVALIDO!!!
                                                pmtger.mt_formfeed(LParamLo);
                                                msg = "     CARTAO";
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
                                    /***PRODUTOS***/

                                    case 3:
                                        string[] print = new string[256];
                                        DateTime datatual = DateTime.Now;
                                        float price;
                                        string sprice;
                                        int tam, i;
                                        byte[] a = new byte[256];
                                        // int auxi;
                                        price = 0;
                                        a[0] = 10;
                                        // Primeiramente verifica se o pedido esta sendo finalizado
                                        // Caso o produto esteja em branco, este indoca que o pedido foi finalizado
                                        if (palavra[LParamLo].Length == 0)
                                        {
                                            j = 0;
                                            // Finalização dos pedidos...
                                            // Se houver pedidos estes são inclusos na lista e finalizado.
                                            if (NumeroProd[LParamLo] != 1)
                                            {

                                                //Efetua a gravação do cartão
                                                if (LancamentoGravarDados(PedidoG[LParamLo].Card.codCartao, strbanco) == 1)
                                                {
                                                    pmtger.mt_formfeed(LParamLo);
                                                    msg = "   LANCAMENTO";
                                                    pmtger.mt_dispstr(LParamLo, msg);

                                                    pmtger.mt_linefeed(LParamLo);
                                                    pmtger.mt_carret(LParamLo);
                                                    msg = "   EFETUADO!!!";
                                                    pmtger.mt_dispstr(LParamLo, msg);

                                                    Thread.Sleep(200);

                                                    passo[LParamLo] = 1;     //volta para Cartão:
                                                    TimerPasso(LParamLo);
                                                    palavra[LParamLo] = "";
                                                }
                                                else
                                                {
                                                    //Caso ocorrer falha na gravação, esta é informada no display e finaliza o pedido
                                                    pmtger.mt_formfeed(LParamLo);
                                                    msg = "   LANCAMENTO";
                                                    pmtger.mt_dispstr(LParamLo, msg);

                                                    pmtger.mt_linefeed(LParamLo);

                                                    pmtger.mt_carret(LParamLo);
                                                    msg = " SEM GRAVACAO!!!";
                                                    pmtger.mt_dispstr(LParamLo, msg);

                                                    Thread.Sleep(500);

                                                    passo[LParamLo] = 2;     //volta para Cartão:
                                                    TimerPasso(LParamLo);
                                                    palavra[LParamLo] = "";
                                                }//Finalização finalizada!!!

                                                // Se NumeroProd estiver vazio o pedido não é finalizado e a tela permanece aguardando
                                                // a inclusão de um produto
                                            }
                                            else
                                            {
                                                TimerPasso(LParamLo);
                                                palavra[LParamLo] = "";
                                            }
                                        }
                                        else
                                        {
                                            //Caso não seja finalização dos pedidos efetua a consulta do código digitado
                                            if (LancamentoProduto(palavra[LParamLo], NumeroProd[LParamLo], LParamLo,strbanco) == 1)
                                            {
                                                //passo[LParamLo]--;
                                                //TimerPasso(LParamLo);
                                                //palavra[LParamLo] = "";
                                                if (deletar)
                                                {
                                                    passo[LParamLo]++;
                                                    palavra[LParamLo] = "";
                                                    //NumeroProd[LParamLo] = 1;
                                                    TimerPasso(LParamLo);

                                                }
                                                else
                                                {
                                                    NumeroProd[LParamLo]++;
                                                    //if (deletar)
                                                    //{
                                                    //    passo[LParamLo]++;
                                                    //}
                                                    TimerPasso(LParamLo);
                                                    palavra[LParamLo] = "";
                                                }
                                            }
                                            else
                                            {
                                                //Caso não tenha um cartão válido envia CARTAO INVALIDO!!!
                                                pmtger.mt_formfeed(LParamLo);
                                                msg = "     PRODUTO";
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
                                    case 4:
                                        if (palavra[LParamLo].Length == 0)
                                        {
                                            TimerPasso(LParamLo);
                                            palavra[LParamLo] = "";
                                        }
                                        else
                                        {
                                            if ((Deleta(Convert.ToInt32(palavra[LParamLo]))) == 1)
                                            {
                                                msg = "   PRODUTO";
                                                pmtger.mt_dispstr(LParamLo, msg);
                                                pmtger.mt_linefeed(LParamLo);
                                                pmtger.mt_carret(LParamLo);
                                                msg = "   CANCELADO!!!";
                                                pmtger.mt_dispstr(LParamLo, msg);

                                                Thread.Sleep(200);
                                                deletar = false;
                                                passo[LParamLo] = 1;     //volta para Cartão:
                                                TimerPasso(LParamLo);
                                                palavra[LParamLo] = "";
                                            }
                                        }
                                        break;
                                }


                            /*********************************************************
						    *  Se a tecla for ESC segue o seguinte procedimento      *
						    **********************************************************/
						    // Caso seja pressionado a tecla ESC retorna para o menu anterior 
						    // "cancelando" o que foi escolhido.
                            }
                            else if (buf[0] == 27)
                            {
                                deletar = false;
                                palavra[LParamLo] = "";
                                cancela = 0;
                                passo[LParamLo] = 1;
                                TimerPasso(LParamLo);
                                
                            }
                            else if (buf[0] == 47)
                            {
                                deletar = true;
                                palavra[LParamLo] = "";
                                passo[LParamLo] = 2;
                                TimerPasso(LParamLo);

                            }
                            else if (buf[0] == 42)
                            {
                                deletar = false;
                                pmtger.mt_formfeed(LParamLo);
                                string MsgStr = "Cartao:";
                                pmtger.mt_dispstr(LParamLo, MsgStr);
                                totaliza = true;
                                //msg = PegaTotalComanda(palavra[LParamLo], LParamLo, strbanco);
                                //Thread.Sleep(100);
                                
                                //pmtger.mt_dispstr(LParamLo, msg);
                                //Thread.Sleep(300);
                                //TimerPasso(LParamLo);
                                //palavra[LParamLo] = "";

                            }
                            else if (buf[0] == 45)
                            {
                                deletar = false;
                                pmtger.mt_formfeed(LParamLo);
                                string MsgStr = "Cartao:";
                                pmtger.mt_dispstr(LParamLo, MsgStr);
                                deletacomanda = true;
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

               string addr = "";
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
            // forward message to ' WndProc
            base.WndProc(ref m);
        }
        public byte LancamentoUsuario(string CodUsuario, int id, string strbd)
        {
            string strselect;
            drok = 0;
            
            try
            {
                
                //Armazena a select a ser consultada
                strselect = ("SELECT HANDLE,NOME,HANDLE,LOGIN FROM p_usuarios WHERE HANDLE = " + CodUsuario);
                OleDbConnection con = conex.Cnncontrol();
                OleDbCommand cmd = new OleDbCommand(strselect, con);
                cmd.CommandType = CommandType.Text;
                OleDbDataReader dr = cmd.ExecuteReader();

                //Verifica se há informações encontradas e as armazena para utilização futura
                while (dr.Read())
                {
                    PedidoG[id].CodUsuario = dr.GetInt32(dr.GetOrdinal("HANDLE"));
                    PedidoG[id].Usuario = dr.GetString(dr.GetOrdinal("NOME"));
                    PedidoG[id].FuncaoID = dr.GetInt32(dr.GetOrdinal("HANDLE"));
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
        public byte LancamentoCartao(string CodCartao, int id, string strbd)
        {
            string strcard;
            PedidoG[id].Card.codCartao = Convert.ToInt32(CodCartao);
                        //PedidoG[id].Card.StatusCartao = dr.GetString(dr.GetOrdinal("carStatus"));
                        //PedidoG[id].Card.txConsumacao = (int)dr.GetDouble(dr.GetOrdinal("carConsumacao"));
                        //PedidoG[id].Card.txServico = (int)dr.GetDouble(dr.GetOrdinal("carTxServico"));

                    return (1);
        }
        public byte LancamentoGravarDados(int Cartao, string strbd)
        {
            string strgravad;
            drok = 0;
            try
            {
                Querys grava = new Querys();
                for (int i = 1; i <= NumeroProd[LParamLo] - 1; i++)
                {
                    if (grava.Cadastra(PedidoG[LParamLo].Card.codCartao.ToString(), PedidoG[LParamLo].CodUsuario.ToString(), PedidoG[LParamLo].Cesta[i].CodProduto.ToString(), PedidoG[LParamLo].Cesta[i].Quantidade.ToString(), "ABERTO", PedidoG[LParamLo].Cesta[i].Valor))
                    {
                        drok = 1;
                    }
                    else
                    {
                        drok = 0;
                    }

                }

              
                //Se houve leitura return = 1, senão return = 0
                if (drok == 1)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
               
            }
            catch
            {
                return 0;
            }
        }
        public byte LancamentoProduto(string Produto, int NumeroProdutos, int id, string strbd)
        {
            string strguia;
            double valor = 0;
            drok = 0;
            try
            {

                //SE PRODUTO FRACIONARIO
                if ((conex.Checatipoproduto(Produto) == "1 - Fracionário"))
                {
                    //Produto = Produto.Substring(0, 5);
                    //Armazena a select a ser consultada
                    strguia = ("SELECT HANDLE,NOME,PRECO_VENDA FROM p_produtos WHERE SUBSTRING(CODIGO_BARRAS,0,8) LIKE '" + Produto.Substring(0, 7) + "' AND DATA_CANCELAMENTO IS NULL");
                    OleDbConnection con = conex.Cnncontrol();
                    OleDbCommand cmd = new OleDbCommand(strguia, con);
                    cmd.CommandType = CommandType.Text;
                    OleDbDataReader dr = cmd.ExecuteReader();

                    //Verifica se há arquivos para ler e os armazena para uso futuro
                    while (dr.Read())
                    {
                        //2000001005309
                        string kilo = Produto.Substring(7, 6);
                        string grama = kilo.Substring(2, 3);
                        kilo = kilo.Substring(0, 2).TrimEnd('0');
                        //vpeso = Convert.ToInt32(kilo.TrimEnd('0'));
                        vpeso = Convert.ToDouble(kilo + grama) / 1000;
                        //vpeso = vpeso / 1000;
                        valor = Math.Round(Convert.ToDouble(dr["PRECO_VENDA"].ToString()) * vpeso, 2);

                        //valor = (Convert.ToDouble(dr.GetOrdinal("PRECO_VENDA")) * Convert.ToDouble(Produto.Substring(6, Produto.Length)));
                        PedidoG[id].Cesta[NumeroProdutos].CodProduto = dr.GetInt32(dr.GetOrdinal("HANDLE"));
                        PedidoG[id].Cesta[NumeroProdutos].DescricaoProduto = dr.GetString(dr.GetOrdinal("NOME"));
                        PedidoG[id].Cesta[NumeroProdutos].Valor = valor;    //Convert.ToDouble(dr.GetOrdinal("PRECO_VENDA"));
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
                else
                {
                    //Armazena a select a ser consultada
                    strguia = ("SELECT HANDLE,NOME,PRECO_VENDA FROM p_produtos WHERE CODIGO_BARRAS = '" + Produto+"' and DATA_CANCELAMENTO is null ");
                    OleDbConnection con = conex.Cnncontrol();
                    OleDbCommand cmd = new OleDbCommand(strguia, con);
                    cmd.CommandType = CommandType.Text;
                    OleDbDataReader dr = cmd.ExecuteReader();

                    //Verifica se há arquivos para ler e os armazena para uso futuro
                    while (dr.Read())
                    {
                        PedidoG[id].Cesta[NumeroProdutos].CodProduto = dr.GetInt32(dr.GetOrdinal("HANDLE"));
                        PedidoG[id].Cesta[NumeroProdutos].DescricaoProduto = dr.GetString(dr.GetOrdinal("NOME"));
                        PedidoG[id].Cesta[NumeroProdutos].Valor = Convert.ToDouble(dr["PRECO_VENDA"]);
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

            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        public byte LancamentoProdutoCesta(string Quantidade, int NumeroProduto, int id)
        {
            try
            {
                //Verifica a quantidade
                if (Convert.ToInt32(Quantidade) != 0)
                {
                    PedidoG[id].Cesta[NumeroProduto].Quantidade = Convert.ToInt32(Quantidade);
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
        public string PegaTotalComanda(string CodComanda, int id, string strbd)
        {
            string strselect;
            string total="";
            drok = 0;

            try
            {

                //Armazena a select a ser consultada
                strselect = ("SELECT sum(VALOR) total FROM p_comanda WHERE CODIGO_BARRAS = " + CodComanda);
                OleDbConnection con = conex.Cnncontrol();
                OleDbCommand cmd = new OleDbCommand(strselect, con);
                cmd.CommandType = CommandType.Text;
                OleDbDataReader dr = cmd.ExecuteReader();

                //Verifica se há informações encontradas e as armazena para utilização futura
                while (dr.Read())
                {
                    total = dr["total"].ToString();
                    drok = 1;
                }
                    dr.Close();
                    con.Close();
                    return total;
            }
            catch
            {
                return "0";
            }
        }
        private byte Deleta(int quantidade)
        {
            byte retorna = 0;
            Querys deletacomanda = new Querys();
            // for (int i = 1; i <= NumeroProd[LParamLo] - 1; i++)
            //{
                if (deletacomanda.delete(PedidoG[LParamLo].Card.codCartao.ToString(), PedidoG[LParamLo].Cesta[1].CodProduto.ToString(), quantidade))
                {
                    retorna = 1;
                }
                else
                {
                    retorna = 0;
                }

            //}
            return retorna;
        }
        private bool Detelarcomanda(string pcomanda)
        {
            Querys deletacomanda = new Querys();
            bool deucerto=false;
            if (deletacomanda.deletecomanda(pcomanda))
            {
                deucerto = true;
            }
            return deucerto;
        }
        private void btSair_Click(object sender, EventArgs e)
        {
            if (btIniciar.Text == "Terminar")
            {
                pmtger.mt_finishserver();
            }
            Close();
        }
        private void timerVConectados_Tick(object sender, EventArgs e)
        {          
            int j, k;

            k = VConectados.Items.Count ;       
            for (j = 1; j <= k ; j++)
            {
                pmtger.mt_sendlive(j);      
            }                       
        }
       
    }

}