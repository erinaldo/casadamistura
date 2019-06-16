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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comanda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#FFF68F");
        System.Drawing.Color back = System.Drawing.ColorTranslator.FromHtml("#CFE8F5");
        Conn.Class1 conex = new Class1();
        int IRetorno;
        double vvalorunitario;
        public double vdesconto;
        double calcsubtotal;
        double vtotal;
        double vpeso;

        private void txtNumeroComanda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtCodFuncionario.Focus();
            }
            else if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtCodProduto.Focus();
            }
            else if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }

        private void txtCodProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtCodProduto.Focus())
                {
                    if (txtCodProduto.Text != "")
                    {
                        Carregar_Produto(txtCodProduto.Text);
                        Carregar_Imagem(txtCodProduto.Text);
                        txtCodProduto.Text = "";
                        txtQuantidade.Focus();
                    }
                    else
                    {
                        txtCodProduto.Focus();
                    }
                }
            }
            conex.ChecaNumero(e);
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }

        private void Carregar_Produto(string codproduto)
        {
            string sQuery = null;
            //SE PRODUTO FRACIONARIO
            if ((conex.Checatipoproduto(codproduto) == "1 - Fracionário"))
            {
                sQuery = sQuery + string.Format("SELECT * FROM p_produtos WHERE SUBSTRING(CODIGO_BARRAS,0,8) LIKE '" + codproduto.Substring(0, 7) + "' AND DATA_CANCELAMENTO IS NULL");
                OleDbConnection DbConnection = conex.Cnncontrol();
                OleDbCommand commS = new OleDbCommand(sQuery, DbConnection);
                OleDbDataReader dr = commS.ExecuteReader();
                while (dr.Read())
                {
                    string kilo = codproduto.Substring(7, 6);
                    string grama = kilo.Substring(2, 3);
                    kilo = kilo.Substring(0, 2);//.TrimEnd('0');                    
                    //vpeso = Convert.ToInt32(kilo.TrimEnd('0'));
                    vpeso = Convert.ToDouble(kilo + grama) / 1000;
                    //vpeso = vpeso / 1000;
                    vvalorunitario = Math.Round(Convert.ToDouble(dr["PRECO_VENDA"].ToString()) * vpeso, 2);

                    //calcsubtotal += Math.Round((vvalorunitario * Convert.ToInt32(quantidade.Text)) - vdesconto, 2);
                    //subtotal.Text = calcsubtotal.ToString("N2");
                    //valorunitario.Text = dr["PRECO_VENDA"].ToString();
                    //dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, dr["HANDLE"].ToString(), quantidade.Text, dr["NOME"].ToString(), valorunitario.Text, calcsubtotal.ToString("N"), "0", kilo + "," + grama, dr["TIPO_ESTOQUE"].ToString());
                    lDescricaoProduto.Text = dr["NOME"].ToString();
                    //CalculaTotal();
                    vvalorunitario = 0;
                    calcsubtotal = 0;
                    vdesconto = 0;
                }
                DbConnection.Close();
            }
            else
            {
                sQuery = sQuery + string.Format("select * from p_produtos WHERE CODIGO_BARRAS ='" + codproduto + "' and DATA_CANCELAMENTO is null");
                OleDbConnection DbConnection = conex.Cnncontrol();
                OleDbCommand commS = new OleDbCommand(sQuery, DbConnection);
                OleDbDataReader dr = commS.ExecuteReader();
                while (dr.Read())
                {
                    //valorunitario.Text = dr["PRECO_VENDA"].ToString() == "" ? "0" : dr["PRECO_VENDA"].ToString();
                    //vvalorunitario = Convert.ToDouble(valorunitario.Text);
                    //calcsubtotal += (vvalorunitario * Convert.ToInt32(quantidade.Text)) - vdesconto;
                    //subtotal.Text = calcsubtotal.ToString("N");
                    //dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1, dr["HANDLE"].ToString(), quantidade.Text, dr["NOME"].ToString(), valorunitario.Text, calcsubtotal.ToString("N"), "0", dr["TIPO_ESTOQUE"].ToString());
                    lDescricaoProduto.Text = dr["NOME"].ToString();
                    //CalculaTotal();
                    vvalorunitario = 0;
                    calcsubtotal = 0;
                    vdesconto = 0;
                }
                DbConnection.Close();
            }
            //quantidade.Text = "01";

        }
        private void Carregar_Imagem(string codproduto)
        {
            string sQuery = null;
            carregaimagemproduto.Image = null;
            //SE PRODUTO FRACIONARIO
            if ((conex.Checatipoproduto(codproduto) == "1 - Fracionário"))
            {


                sQuery = sQuery + string.Format("select * from p_produtos WHERE SUBSTRING(CODIGO_BARRAS,0,8) ='" + codproduto + "' and LEN(imagem)>4 and DATA_CANCELAMENTO IS NULL");
                OleDbConnection DbConnection = conex.Cnncontrol();
                OleDbDataAdapter da = new OleDbDataAdapter(sQuery, DbConnection);
                DataSet ds = new DataSet("MyImages");
                byte[] MyData = new byte[0];
                da.Fill(ds, "MyImages");

                DataRow myRow;
                if (ds.Tables["MyImages"].Rows.Count > 0)
                {
                    myRow = ds.Tables["MyImages"].Rows[0];

                    MyData = (byte[])myRow["IMAGEM"];
                    MemoryStream stream = new MemoryStream(MyData);
                    carregaimagemproduto.Image = Image.FromStream(stream);
                    carregaimagemproduto.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                DbConnection.Close();
            }
            else
            {
                sQuery = sQuery + string.Format("select * from p_produtos WHERE CODIGO_BARRAS ='" + codproduto + "' and LEN(imagem)>4");
                OleDbConnection DbConnection = conex.Cnncontrol();
                OleDbDataAdapter da = new OleDbDataAdapter(sQuery, DbConnection);
                DataSet ds = new DataSet("MyImages");
                byte[] MyData = new byte[0];
                da.Fill(ds, "MyImages");

                DataRow myRow;
                if (ds.Tables["MyImages"].Rows.Count > 0)
                {
                    myRow = ds.Tables["MyImages"].Rows[0];

                    MyData = (byte[])myRow["IMAGEM"];
                    MemoryStream stream = new MemoryStream(MyData);
                    carregaimagemproduto.Image = Image.FromStream(stream);
                    carregaimagemproduto.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                DbConnection.Close();
            }

        }
    }
}
