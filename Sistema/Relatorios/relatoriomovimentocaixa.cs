using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Relatorios
{
    class relatoriomovimentocaixa
    {
        private string nomecaixa;
        private string codigocaixa;
        private string dataaberturacaixa;
        private string statuscaixa;
        private string datamovimento;
        private string produto;
        private double valor;
        private string formapagamento;
        public string NomeCaixa
        {
            get { return nomecaixa; }
            set { nomecaixa= value; }
        }
        public string CodigoCaixa
        {
            get { return codigocaixa; }
            set { codigocaixa = value; }
        }
        public string DataAberturaCaixa
        {
            get { return dataaberturacaixa; }
            set { dataaberturacaixa = value; }
        }
        public string StatusCaixa
        {
            get { return statuscaixa; }
            set { statuscaixa= value; }
        }
        public string DataMovimento
        {
            get { return datamovimento; }
            set { datamovimento = value; }
        }
        public string Produto
        {
            get { return produto; }
            set { produto = value; }
        }
        public double Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        public string FormaPagamento
        {
            get { return formapagamento; }
            set { formapagamento= value; }
        }

        public relatoriomovimentocaixa(
        string pnomecaixa,
        string pcodigocaixa,
        string pdataaberturacaixa,
        string pstatuscaixa,
        string pdatamovimento,
        string pproduto,
        double pvalor,
        string pformapagamento
        )
        {
            nomecaixa = pnomecaixa;
            codigocaixa = pcodigocaixa;
            dataaberturacaixa = pdataaberturacaixa;
            statuscaixa = pstatuscaixa;
            datamovimento = pdatamovimento;
            produto = pproduto;
            valor = pvalor;
            formapagamento = pformapagamento;
        }

    }
}
