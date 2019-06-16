using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Relatorios
{
    class relatoriomargemlucro
    {
        private string caixa;
        private string data_venda;
        private string codigo_produto;
        private string codigo_barras;
        private string produto;
        private double valor_custo;
        private double valor_venda;
        private double lucro;

        public string Caixa
        {
            get { return caixa; }
            set { caixa = value; }
        }
        public string Data_Venda
        {
            get { return data_venda; }
            set { data_venda = value; }
        }
        public string Codigo_Produto
        {
            get { return codigo_produto; }
            set { codigo_produto = value; }
        }
        public string Codigo_Barras
        {
            get { return codigo_barras; }
            set { codigo_barras = value; }
        }
        public string Produto
        {
            get { return produto; }
            set { produto = value; }
        }
        public double Valor_Custo
        {
            get { return valor_custo; }
            set { valor_custo = value; }
        }
        public double Valor_Venda
        {
            get { return valor_venda; }
            set { valor_venda = value; }
        }
        public double Lucro
        {
            get { return lucro; }
            set { lucro = value; }
        }

        public relatoriomargemlucro(
        string pcaixa,
        string pdata_venda,
        string pcodigo_produto,
        string pcodigo_barras,
        string pproduto,
        double pvalor_custo,
        double pvalor_venda,
        double plucro
        )
        {
            caixa = pcaixa;
            data_venda = pdata_venda;
            codigo_produto= pcodigo_produto;
            codigo_barras = pcodigo_barras;
            produto = pproduto;
            valor_custo = pvalor_custo;
            valor_venda = pvalor_venda;
            lucro = plucro;
        }

    }
}
