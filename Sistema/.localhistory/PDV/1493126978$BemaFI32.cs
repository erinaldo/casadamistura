using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV
{
    public class BemaFI32
    {

        #region Fun��es de tratamento de erro

        /// <summary>
        /// Fun��o para analizar os retorno da impressora (ST1 e ST2).
        /// </summary>
        /*public static void Analisa_RetornoImpressoraMFD()
        {
            int ACK, ST1, ST2, ST3;            
            string Erros = "";
            ACK = ST1 = ST2 = ST3 = 0;
            Bematech_FI_RetornoImpressoraMFD(ref ACK, ref ST1, ref ST2, ref ST3);

            #region Tratando o ST1
            if (ST1 >= 128)
            {
                ST1 = ST1 - 128;
                Erros += "BIT 7 - Fim de Papel" + '\x0D';
            }
            if (ST1 >= 64)
            {
                ST1 = ST1 - 64;
                Erros += "BIT 6 - Pouco Papel" + '\x0D';
            }
            if (ST1 >= 32)
            {
                ST1 = ST1 - 32;
                Erros += "BIT 5 - Erro no Rel�gio" + '\x0D';
            }
            if (ST1 >= 16)
            {
                ST1 = ST1 - 16;
                Erros += "BIT 4 - Impressora em ERRO" + '\x0D';
            }
            if (ST1 >= 8)
            {
                ST1 = ST1 - 8;
                Erros += "BIT 3 - CMD n�o iniciado com ESC" + '\x0D';
            }
            if (ST1 >= 4)
            {
                ST1 = ST1 - 4;
                Erros += "BIT 2 - Comando Inexistente" + '\x0D';
            }
            if (ST1 >= 2)
            {
                ST1 = ST1 - 2;
                Erros += "BIT 1 - Cupom Aberto" + '\x0D';
            }
            if (ST1 >= 1)
            {
                ST1 = ST1 - 1;
                Erros += "BIT 0 - N� de Par�metros Inv�lidos" + '\x0D';
            }
            #endregion

            #region Tratando o ST2
            if (ST2 >= 128)
            {
                ST2 = ST2 - 128;
                Erros += "BIT 7 - Tipo de Par�metro Inv�lido" + '\x0D';
            }
            if (ST2 >= 64)
            {
                ST2 = ST2 - 64;
                Erros += "BIT 6 - Mem�ria Fiscal Lotada" + '\x0D';
            }
            if (ST2 >= 32)
            {
                ST2 = ST2 - 32;
                Erros += "BIT 5 - CMOS n�o Vol�til" + '\x0D';
            }
            if (ST2 >= 16)
            {
                ST2 = ST2 - 16;
                Erros += "BIT 4 - Al�quota N�o Programada" + '\x0D';
            }
            if (ST2 >= 8)
            {
                ST2 = ST2 - 8;
                Erros += "BIT 3 - Al�quotas lotadas" + '\x0D';
            }
            if (ST2 >= 4)
            {
                ST2 = ST2 - 4;
                Erros += "BIT 2 - Cancelamento � Permitido" + '\x0D';
            }
            if (ST2 >= 2)
            {
                ST2 = ST2 - 2;
                Erros += "BIT 1 - CGC/IE n�o Programados" + '\x0D';
            }
            if (ST2 >= 1)
            {
                ST2 = ST2 - 1;
                Erros += "BIT 0 - Comando n�o Executado" + '\x0D';
            }

            #endregion

            if (Erros.Length != 0)
                System.Windows.Forms.MessageBox.Show(Erros, "Erro na Execu��o do Comando", MessageBoxButtons.OK, MessageBoxIcon.Error);					
        }*/


        /// <summary>
        /// Fun��o que analiza o retorno da fun��o.
        /// </summary>
        /// <param name="IRetorno">Inteiro com o valor a ser analizado.</param>
        public static void Analisa_iRetorno(int IRetorno)
        {
            string MSG = "";
            string MSGCaption = "Aten��o";
            MessageBoxIcon MSGIco = MessageBoxIcon.Information;

            switch (IRetorno)
            {
                case 0:
                    MSG = "Erro de Comunica��o!";
                    MSGCaption = "Erro";
                    MSGIco = MessageBoxIcon.Error;
                    break;
                case -1:
                    MSG = "Erro de Execu��o na Fun��o. Verifique!";
                    MSGCaption = "Erro";
                    MSGIco = MessageBoxIcon.Error;
                    break;
                case -2:
                    MSG = "Par�metro Inv�lido!";
                    MSGCaption = "Erro";
                    MSGIco = MessageBoxIcon.Error;
                    break;
                case -3:
                    MSG = "Al�quota n�o programada!";
                    break;
                case -4:
                    MSG = "Arquivo BemaFI32.INI n�o encontrado. Verifique!";
                    break;
                case -5:
                    MSG = "Erro ao Abrir a Porta de Comunica��o";
                    MSGCaption = "Erro";
                    MSGIco = MessageBoxIcon.Error;
                    break;
                case -6:
                    MSG = "Impressora Desligada ou Desconectada.";
                    break;
                case -7:
                    MSG = "Banco N�o Cadastrado no Arquivo BemaFI32.ini";
                    break;
                case -8:
                    MSG = "Erro ao Criar ou Gravar no Arquivo Retorno.txt ou Status.txt.";
                    MSGCaption = "Erro";
                    MSGIco = MessageBoxIcon.Error;
                    break;
                case -18:
                    MSG = "N�o foi poss�vel abrir arquivo INTPOS.001!";
                    break;
                case -19:
                    MSG = "Par�metros diferentes!";
                    break;
                case -20:
                    MSG = "Transa��o cancelada pelo Operador!";
                    break;
                case -21:
                    MSG = "A Transa��o n�o foi aprovada!";
                    break;
                case -22:
                    MSG = "N�o foi poss�vel terminar a Impress�o!";
                    break;
                case -23: MSG = "N�o foi poss�vel terminar a Opera��o!";
                    break;
                case -24: MSG = "N�o foi poss�vel terminal a Opera��o!";
                    break;
                case -25: MSG = "Totalizador n�o fiscal n�o programado.";
                    break;
                case -26: MSG = "Transa��o j� Efetuada!";
                    break;
                //case -27: Analisa_RetornoImpressora();
                //  break;
                case -28: MSG = "N�o h� Informa��es para serem Impressas!";
                    break;
            }
            if (MSG.Length != 0)
                System.Windows.Forms.MessageBox.Show(MSG, MSGCaption, MessageBoxButtons.OK, MSGIco);
        }


        #endregion

        #region IMPORT DAS FUN��ES DA BEMAFI32.DLL

        #region Fun��es do Cupom Fiscal
        [DllImport("BemaFI32.dll")]
        public static extern int Bematech_FI_AbreCupomMFD(string CGC_CPF, string nome, string endereco);
        [DllImport("BemaFI32.dll")]
        public static extern int Bematech_FI_VendeItemCompleto(string Codigo, string EAN13, string Descricao, string IndiceDepartamento, string Aliquota, string UnidadeMedida, string TipoQuantidade, string CasasDecimaisQtde, string Quantidade, string CasasDecimaisValor, string ValorUnitario, string TipoDesconto, string ValorAcrescimo, string ValorDesconto, string ArredondaTrunca, string NCM, string CFOP, string InformacaoAdicional, string CST_ICMS, string OrigemProduto, string ItemListaServico, string CodigoISS, string NaturezaOperacaoISS, string IndicadorIncentivoFiscal, string CodigoIBGE, string CSOSN, string ValorBaseCalculoSimples, string ValorICMSRetidoSimples, string ModalidadeBaseCalculo, string PercentualReducaoBase, string ModalidadeBC, string PercentualMargemICMS, string PercentualBCICMS, string ValorReducaoBCICMS, string ValorAliquotaICMS, string ValorICMS, string ValorICMSDesonerado, string MotivoDesoneracaoICMS, string AliquotaCalculoCredito, string ValorCreditoICMS, string Reservado01, string Reservado02, string Reservado03, string Reservado04, string Reservado05, string Reservado06, string Reservado07, string Reservado08, string Reservado09, string Reservado10, string Reservado11, string Reservado12, string Reservado13, string Reservado14, string Reservado15, string Reservado16, string Reservado17, string Reservado18, string Reservado19, string Reservado20, string Reservado21, string Reservado22, string Reservado23);
        [DllImport("BemaFI32.dll")]
        public static extern int Bematech_FI_IniciaFechamentoCupom(string AcrescimoDesconto, string TipoAcrescimoDesconto, string ValorAcrescimoDesconto);
        [DllImport("BemaFI32.dll")]
        public static extern int Bematech_FI_AcrescimoDescontoItemCV0909(string Item, string AcrescimoDesconto, string TipoAcrescimoDesconto, string ValorAcrescimoDesconto);
        [DllImport("BemaFI32.dll")]
        public static extern int Bematech_FI_EfetuaFormaPagamento(string valor, string forma);
        [DllImport("BemaFI32.dll")]
        public static extern int Bematech_FI_TerminaFechamentoCupom(string menssagem);
        [DllImport("BemaFI32.dll")]
        public static extern int Bematech_FI_NumeroCupom([MarshalAs(UnmanagedType.VBByRefStr)] ref string NumeroCupom);
        [DllImport("BemaFi32.dll")]
        public static extern int Bematech_FI_RetornoImpressoraMFD(ref int ACK, ref int ST1, ref int ST2, ref int ST3);

        [DllImport("BemaFI32.dll")]
        public static extern int Bematech_FI_CancelaCupom();
        [DllImport("BemaFI32.dll")]
        public static extern int Bematech_FI_DadosSoftwareHouseSAT(string cnpj, string assinaturaAplicativoComercial);
        [DllImport("BemaFI32.dll")]
        public static extern int Bematech_FI_UltimasInformacoesSAT([MarshalAs(UnmanagedType.VBByRefStr)] ref string chaveAcesso, ref string numeroCupom, ref string NumeroSAT);
        [DllImport("BemaFI32.dll")]
        public static extern int Bematech_FI_RetornaMensagemSeFazSAT([MarshalAs(UnmanagedType.VBByRefStr)] ref string message, ref string code, ref string errorMessage, ref string errorCode);
        [DllImport("BemaFi32.dll")]
        public static extern int Bematech_FI_AbrePortaSerial();
        [DllImport("BemaFi32.dll")]
        public static extern int Bematech_FI_Sangria(string Valor);

        [DllImport("BemaFi32.dll")]
        public static extern int Bematech_FI_Suprimento(string Valor, string FormaPagamento);

        #region Fun��es dos Relat�rios Fiscais

        [DllImport("BemaFi32.dll")]
        public static extern int Bematech_FI_LeituraX();

        [DllImport("BemaFi32.dll")]
        public static extern int Bematech_FI_LeituraXSerial();

        [DllImport("BemaFi32.dll")]
        public static extern int Bematech_FI_ReducaoZ(string Data, string Hora);

        [DllImport("BemaFi32.dll")]
        public static extern int Bematech_FI_RelatorioGerencial(string Texto);

        [DllImport("BemaFi32.dll")]
        public static extern int Bematech_FI_FechaRelatorioGerencial();

        [DllImport("BemaFi32.dll")]
        public static extern int Bematech_FI_LeituraMemoriaFiscalData(string DataInicial, string DataFinal);

        [DllImport("BemaFi32.dll")]
        public static extern int Bematech_FI_LeituraMemoriaFiscalReducao(string ReducaoInicial, string ReducaoFinal);

        [DllImport("BemaFi32.dll")]
        public static extern int Bematech_FI_LeituraMemoriaFiscalSerialData(string DataInicial, string DataFinal);

        [DllImport("BemaFi32.dll")]
        public static extern int Bematech_FI_LeituraMemoriaFiscalSerialReducao(string ReducaoInicial, string ReducaoFinal);

        #endregion









        #endregion

        // Fim da Declara��o ///////////////////////////////////////////////////////////
        #endregion
    }
}
