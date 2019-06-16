using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void GerarNotas_Load(object sender, EventArgs e)
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            string Cpf,DataEmit = null;
            
            //FileStream fs = new FileStream("CFe35170525168664000195590002954060002714556005.xml", FileMode.Open, FileAccess.Read);
            DirectoryInfo Dir = new DirectoryInfo(Application.StartupPath+@"\");
            FileInfo[] Files = Dir.GetFiles("*.xml", SearchOption.AllDirectories);
            foreach (FileInfo File in Files)
            {
                FileStream fs = new FileStream(File.Name,FileMode.Open, FileAccess.Read);
                xmldoc.Load(fs);
                xmlnode = xmldoc.GetElementsByTagName("CPF");
                Cpf = xmlnode[0].ChildNodes.Item(0).InnerText.Trim();
                xmlnode = xmldoc.GetElementsByTagName("dEmi");
                DataEmit = xmlnode[0].ChildNodes.Item(0).InnerText.Trim();


            }
            
        }


    }
}
