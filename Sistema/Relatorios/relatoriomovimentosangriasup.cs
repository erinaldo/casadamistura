using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Relatorios
{
    class relatoriomovimentosangriasup
    {
        private string nomecaixa;
        private string codigocaixa;
        private string tipo;
        private double valor;
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
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public double Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        public relatoriomovimentosangriasup(
        string pnomecaixa,
        string pcodigocaixa,
        string ptipo,
        double pvalor
        )
        {
            nomecaixa = pnomecaixa;
            codigocaixa = pcodigocaixa;
            tipo = ptipo;
            valor = pvalor;
        }
    }
}
