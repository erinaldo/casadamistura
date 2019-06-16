using System;
using System.Runtime.InteropServices;

namespace Perifericos
{
    public class structs
    {

        public struct Cartao
        {
            public int codCartao;
            public string StatusCartao;
            public int txServico;
            public int txConsumacao;
            public int Quantidade;
        }

        public struct Produto
        {
            public int CodProduto;
            public string DescricaoProduto;
            public double Valor;
            public string Obs;
            public float Quantidade;
            public int ValorTotal;
            public string Observ;
        }
        public struct Guia
        {
            public int CodGuia;
            public string NomeGuia;
        }

        public struct PedidoType
        {
            public int CodUsuario;
            public string Usuario;
            public char Senha;
            public int FuncaoID;
            public Cartao Card;
            public string Local;
            public Guia Guia;
            public float TotalCartao;
            public int TotalProdutos;
            public Produto[] Cesta;
            public int imheID;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct Arg_Com_SetupSerial
        {
            public byte Com;
            public TSetupSerial Setup;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct TSetupSerial
        {
            public int baud; // baudrate: 300 a 115.200
            public short bits; // data bits
            public short parity; // paridade
            public short stops; // stop bits
            public byte handshaking; // 0 = sem handshaking, 1 = RTS/CTS
        }
    }
}