﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Conn;
using System.Data.OleDb;
using System.IO;

namespace Cadastros
{
    public partial class EditarProduto : Form
    {
        CadastroProduto prod;
        public EditarProduto(CadastroProduto form1)
        {
            InitializeComponent();
            prod = form1;
        }

        DataGridViewImageColumn img = new DataGridViewImageColumn();
        DataGridViewImageColumn img1 = new DataGridViewImageColumn();
        System.Drawing.Color back = System.Drawing.ColorTranslator.FromHtml("#CFE8F5");
        System.Drawing.Color backgroup = System.Drawing.ColorTranslator.FromHtml("#E3E9D2");
        Conn.Class1 conex = new Class1();
        private void CadastroGrupo_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            panel1.Width = w - 20;
            panel1.Height = h - 20;
            this.BackColor = back;
            #region CarregaGrid
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridView1.Columns.Add("cod", "Código");
            dataGridView1.Columns.Add("nome", "Nome");
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 440;
            //  gridfilacliente.Columns[3].Visible = false;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            img.Image = Properties.Resources.pesquisa;
            img.HeaderText = "Alterar";
            img.Name = "Alterar";
            img1.Image = Properties.Resources.minidel;
            img1.HeaderText = "Remover";
            img1.Name = "Remover";
            dataGridView1.Columns.Add(img);
            dataGridView1.Columns.Add(img1);   
            #endregion
            CarregaGrid(nome.Text);
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void CarregaGrid(string pnome)
        {
            dataGridView1.Rows.Clear();
            OleDbConnection conexao = conex.Cnncontrol();
            string sql = "select * from p_produtos where DATA_CANCELAMENTO is null ";
            if (pnome != "")
            {
                sql += " and (HANDLE like '" + pnome + "%'";
                sql += " OR NOME like '" + pnome + "%')";
            }
            sql += " order by HANDLE";
            OleDbCommand commS = new OleDbCommand(sql, conexao);
            OleDbDataReader da = commS.ExecuteReader();
            while (da.Read())
            {
                dataGridView1.Rows.Add(da["HANDLE"].ToString(), da["NOME"].ToString());
            }
        
        }
        private void nome_TextChanged(object sender, EventArgs e)
        {
            CarregaGrid(nome.Text);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            produto a = new produto();
           if ((e.ColumnIndex == 2)&&(e.RowIndex > -1))
            {

               a.Seleciona(dataGridView1[0, e.RowIndex].Value.ToString());
               prod.textBox1.Text = a.vCodigo_barras;
               prod.descricaoproduto.Text = a.vNome;
               prod.codinternotext.Text = a.vCod_interno;
               prod.datacadastro.Text = a.vData_cadastro;
               prod.cbofornecedor.SelectedValue = a.vFornecedor;
               prod.peso.Text = Convert.ToString(a.vPeso);
               prod.cbogrupo.SelectedValue = a.vGrupo;
               prod.cbosubgrupo.SelectedValue = a.vSubgrupo;
               prod.informacoes.Text = a.vInformacoes;
               prod.precocusto.Text = a.vPreco_custo.ToString("N");
               prod.precovenda.Text = a.vPreco_venda.ToString("N");
               prod.lucro.Text = a.vLucro.ToString("N");
               prod.descontomax.Text = a.vDesconto_max.ToString("N");
               prod.tipoestoque.Text = a.vTipo_estoque;
               prod.qtdeatual.Text = Convert.ToString(a.vQuantidade_atual);
               prod.qtdeminima.Text = Convert.ToString(a.vQuantidade_minima);
               prod.qtdemaxima.Text = Convert.ToString(a.vQuantidade_maxima);
               prod.icms.Text = a.vicms.ToString("N");
               prod.iss.Text = a.viss.ToString("N");
               prod.ipi.Text = a.vipi.ToString("N");
               prod.iof.Text = a.viof.ToString("N");
               prod.pis.Text = a.vpis.ToString("N");
               prod.cofins.Text = a.vcofins.ToString("N");
               prod.cide.Text = a.vcide.ToString("N");
               prod.cll.Text = a.vcll.ToString("N");
               Carregar_Imagem(dataGridView1[0, e.RowIndex].Value.ToString());
               prod.codproduto.Text = dataGridView1[0, e.RowIndex].Value.ToString();
               this.Close();
            }
             else if ((e.ColumnIndex == 3)&&(e.RowIndex > -1))
            {
                if (MessageBox.Show("CONFIRMA A EXCLUSAO DE " + dataGridView1[1, e.RowIndex].Value.ToString() + "?", "EXCLUSAO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    a.Deleta(dataGridView1[0, e.RowIndex].Value.ToString());
                    this.Close();
                    
                }
            }
            
        }
        private void Carregar_Imagem(string Pid)
        {
            string sQuery = null;
            sQuery = sQuery + string.Format("select * from p_produtos WHERE HANDLE ='" + Pid + "' and LEN(imagem)>4 ");
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
                prod.minhaWebCamComp1.ImgWebCam.Image = Image.FromStream(stream);
                prod.minhaWebCamComp1.ImgWebCam.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            DbConnection.Close();
        }
    }
}
