using Conn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace PDV
{
    public partial class GerarNotas: Form
    {
        public GerarNotas()
        {
            InitializeComponent();
        }
        Conn.Class1 conex = new Class1();
        Dictionary<string, string> xml = new Dictionary<string, string>();
        private void GerarNotas_Load(object sender, EventArgs e)
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            string Cpf, DataEmit = null;

            //FileStream fs = new FileStream("CFe35170525168664000195590002954060002714556005.xml", FileMode.Open, FileAccess.Read);
            DirectoryInfo Dir = new DirectoryInfo(Application.StartupPath + @"\");
            FileInfo[] Files = Dir.GetFiles("*.xml", SearchOption.AllDirectories);
            foreach (FileInfo File in Files)
            {
                FileStream fs = new FileStream(File.Name, FileMode.Open, FileAccess.Read);
                xmldoc.Load(fs);
                xmlnode = xmldoc.GetElementsByTagName("CPF");
                Cpf = xmlnode[0].ChildNodes.Item(0).InnerText.Trim();
                xmlnode = xmldoc.GetElementsByTagName("dEmi");
                DataEmit = xmlnode[0].ChildNodes.Item(0).InnerText.ToString().Trim();
                xml.Add(Cpf, DataEmit);
            } 
            
        }
        
        public bool VerificaExisteCupom(string cpf,string pdata)
        {
            bool aberto = false;
            string sQuery = null;
            sQuery += " select a.CPF,a.IMPRESSO,a.DATA_CADASTRO,b.VALOR ";
            sQuery += " from p_fluxo_caixa a  ";
            sQuery += " join p_pagamento_fluxo_caixa b on b.FLUXO_CAIXA =a.HANDLE ";
            sQuery += " where a.CPF='" + cpf + "' ";
            sQuery += " and  (CONVERT(varchar, a.DATA_CADASTRO, 103) = CONVERT(date, '" + pdata + "', 103) ";
            sQuery += " order by a.DATA_CADASTRO desc ";
            OleDbConnection DbConnection = conex.Cnncontrol();
            OleDbCommand cmd = new OleDbCommand(sQuery, DbConnection);
            OleDbDataReader da = cmd.ExecuteReader();
            if (da.HasRows)
            {
                while (da.Read())
                {
                    
                }
            }
            else
            {

            }
            
            da.Close();
            return aberto;
        }


    }
}
