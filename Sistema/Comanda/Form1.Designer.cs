namespace Comanda
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNumeroComanda = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodFuncionario = new System.Windows.Forms.TextBox();
            this.lCodFuncionario = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodProduto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.carregaimagemproduto = new System.Windows.Forms.PictureBox();
            this.fotoproduto = new System.Windows.Forms.PictureBox();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lDescricaoProduto = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carregaimagemproduto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fotoproduto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNumeroComanda);
            this.groupBox1.Controls.Add(this.txtCodFuncionario);
            this.groupBox1.Controls.Add(this.lCodFuncionario);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pictureBox5);
            this.groupBox1.Location = new System.Drawing.Point(26, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1083, 273);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ITEM";
            // 
            // txtNumeroComanda
            // 
            this.txtNumeroComanda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumeroComanda.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroComanda.Location = new System.Drawing.Point(46, 86);
            this.txtNumeroComanda.Name = "txtNumeroComanda";
            this.txtNumeroComanda.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNumeroComanda.Size = new System.Drawing.Size(233, 33);
            this.txtNumeroComanda.TabIndex = 1;
            this.txtNumeroComanda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumeroComanda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroComanda_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Comanda.Properties.Resources.campotexto;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.ErrorImage = global::Comanda.Properties.Resources.campotexto;
            this.pictureBox1.Location = new System.Drawing.Point(37, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(262, 60);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nº COMANDA";
            // 
            // txtCodFuncionario
            // 
            this.txtCodFuncionario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCodFuncionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodFuncionario.Location = new System.Drawing.Point(45, 198);
            this.txtCodFuncionario.Name = "txtCodFuncionario";
            this.txtCodFuncionario.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCodFuncionario.Size = new System.Drawing.Size(233, 33);
            this.txtCodFuncionario.TabIndex = 2;
            this.txtCodFuncionario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodFuncionario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // lCodFuncionario
            // 
            this.lCodFuncionario.AutoSize = true;
            this.lCodFuncionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCodFuncionario.Location = new System.Drawing.Point(41, 151);
            this.lCodFuncionario.Name = "lCodFuncionario";
            this.lCodFuncionario.Size = new System.Drawing.Size(195, 24);
            this.lCodFuncionario.TabIndex = 21;
            this.lCodFuncionario.Text = "Cod FUNCIONÁRIO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 24);
            this.label3.TabIndex = 28;
            this.label3.Text = "Cod";
            // 
            // txtCodProduto
            // 
            this.txtCodProduto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCodProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodProduto.ForeColor = System.Drawing.Color.Black;
            this.txtCodProduto.Location = new System.Drawing.Point(47, 136);
            this.txtCodProduto.Name = "txtCodProduto";
            this.txtCodProduto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCodProduto.Size = new System.Drawing.Size(233, 33);
            this.txtCodProduto.TabIndex = 3;
            this.txtCodProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodProduto_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 36);
            this.label2.TabIndex = 25;
            this.label2.Text = "PRODUTO";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lDescricaoProduto);
            this.groupBox2.Controls.Add(this.txtQuantidade);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.carregaimagemproduto);
            this.groupBox2.Controls.Add(this.fotoproduto);
            this.groupBox2.Controls.Add(this.txtCodProduto);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.pictureBox3);
            this.groupBox2.Location = new System.Drawing.Point(26, 300);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1083, 345);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PRODUTOS";
            // 
            // carregaimagemproduto
            // 
            this.carregaimagemproduto.Location = new System.Drawing.Point(847, 19);
            this.carregaimagemproduto.Name = "carregaimagemproduto";
            this.carregaimagemproduto.Size = new System.Drawing.Size(194, 177);
            this.carregaimagemproduto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.carregaimagemproduto.TabIndex = 60;
            this.carregaimagemproduto.TabStop = false;
            // 
            // fotoproduto
            // 
            this.fotoproduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fotoproduto.Location = new System.Drawing.Point(849, 114);
            this.fotoproduto.Name = "fotoproduto";
            this.fotoproduto.Size = new System.Drawing.Size(225, 206);
            this.fotoproduto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fotoproduto.TabIndex = 59;
            this.fotoproduto.TabStop = false;
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidade.ForeColor = System.Drawing.Color.Black;
            this.txtQuantidade.Location = new System.Drawing.Point(44, 251);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtQuantidade.Size = new System.Drawing.Size(233, 33);
            this.txtQuantidade.TabIndex = 4;
            this.txtQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantidade_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 24);
            this.label4.TabIndex = 63;
            this.label4.Text = "QUANTIDADE";
            // 
            // lDescricaoProduto
            // 
            this.lDescricaoProduto.AutoSize = true;
            this.lDescricaoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDescricaoProduto.Location = new System.Drawing.Point(315, 133);
            this.lDescricaoProduto.Name = "lDescricaoProduto";
            this.lDescricaoProduto.Size = new System.Drawing.Size(363, 36);
            this.lDescricaoProduto.TabIndex = 64;
            this.lDescricaoProduto.Text = "DESCRIÇÃO PRODUTO";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::Comanda.Properties.Resources.campotexto;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.ErrorImage = global::Comanda.Properties.Resources.campotexto;
            this.pictureBox5.Location = new System.Drawing.Point(31, 183);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(262, 60);
            this.pictureBox5.TabIndex = 24;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Comanda.Properties.Resources.campotexto;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.ErrorImage = global::Comanda.Properties.Resources.campotexto;
            this.pictureBox2.Location = new System.Drawing.Point(31, 122);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(262, 60);
            this.pictureBox2.TabIndex = 65;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::Comanda.Properties.Resources.campotexto;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.ErrorImage = global::Comanda.Properties.Resources.campotexto;
            this.pictureBox3.Location = new System.Drawing.Point(31, 237);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(262, 60);
            this.pictureBox3.TabIndex = 66;
            this.pictureBox3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 657);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carregaimagemproduto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fotoproduto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNumeroComanda;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodFuncionario;
        private System.Windows.Forms.Label lCodFuncionario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodProduto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox carregaimagemproduto;
        private System.Windows.Forms.PictureBox fotoproduto;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lDescricaoProduto;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

