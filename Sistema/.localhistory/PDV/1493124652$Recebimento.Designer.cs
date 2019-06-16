namespace PDV
{
    partial class Recebimento
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Recebimento));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lapagartext = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dinheirotext = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbodebito = new System.Windows.Forms.ComboBox();
            this.valorcartaotext = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.lsubtotal = new System.Windows.Forms.TextBox();
            this.ltroco = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.parcelas = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.cpf = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 542);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 37);
            this.label2.TabIndex = 5;
            this.label2.Text = "TROCO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "A RECEBER";
            // 
            // lapagartext
            // 
            this.lapagartext.AutoSize = true;
            this.lapagartext.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lapagartext.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lapagartext.Location = new System.Drawing.Point(374, 19);
            this.lapagartext.Name = "lapagartext";
            this.lapagartext.Size = new System.Drawing.Size(80, 37);
            this.lapagartext.TabIndex = 10;
            this.lapagartext.Text = "0,00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 29);
            this.label4.TabIndex = 15;
            this.label4.Text = "DINHEIRO";
            // 
            // dinheirotext
            // 
            this.dinheirotext.BackColor = System.Drawing.Color.White;
            this.dinheirotext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dinheirotext.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dinheirotext.Location = new System.Drawing.Point(260, 81);
            this.dinheirotext.Name = "dinheirotext";
            this.dinheirotext.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dinheirotext.Size = new System.Drawing.Size(300, 37);
            this.dinheirotext.TabIndex = 1;
            this.dinheirotext.Text = "0,00";
            this.dinheirotext.TextChanged += new System.EventHandler(this.dinheirotext_TextChanged);
            this.dinheirotext.Enter += new System.EventHandler(this.dinheirotext_Enter);
            this.dinheirotext.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dinheirotext_KeyPress);
            this.dinheirotext.Leave += new System.EventHandler(this.dinheirotext_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 29);
            this.label5.TabIndex = 16;
            this.label5.Text = "CARTÃO";
            // 
            // cbodebito
            // 
            this.cbodebito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbodebito.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbodebito.FormattingEnabled = true;
            this.cbodebito.Location = new System.Drawing.Point(231, 142);
            this.cbodebito.Name = "cbodebito";
            this.cbodebito.Size = new System.Drawing.Size(338, 39);
            this.cbodebito.TabIndex = 3;
            this.cbodebito.TextChanged += new System.EventHandler(this.cbodebito_TextChanged);
            this.cbodebito.Enter += new System.EventHandler(this.cbodebito_Enter);
            this.cbodebito.Leave += new System.EventHandler(this.cbodebito_Leave);
            // 
            // valorcartaotext
            // 
            this.valorcartaotext.BackColor = System.Drawing.Color.White;
            this.valorcartaotext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.valorcartaotext.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valorcartaotext.Location = new System.Drawing.Point(260, 270);
            this.valorcartaotext.Name = "valorcartaotext";
            this.valorcartaotext.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.valorcartaotext.Size = new System.Drawing.Size(300, 37);
            this.valorcartaotext.TabIndex = 17;
            this.valorcartaotext.Text = "0,00";
            this.valorcartaotext.TextChanged += new System.EventHandler(this.valorcartaotext_TextChanged);
            this.valorcartaotext.Enter += new System.EventHandler(this.valorcartaotext_Enter);
            this.valorcartaotext.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.valorcartaotext_KeyPress);
            this.valorcartaotext.Leave += new System.EventHandler(this.valorcartaotext_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(202, 29);
            this.label6.TabIndex = 18;
            this.label6.Text = "VALOR CARTÃO";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::PDV.Properties.Resources.campotexto;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(231, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(338, 60);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::PDV.Properties.Resources.campotexto;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(231, 261);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(338, 60);
            this.pictureBox3.TabIndex = 21;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Location = new System.Drawing.Point(106, 607);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(100, 50);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 22;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 342);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(557, 135);
            this.dataGridView1.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 483);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 29);
            this.label3.TabIndex = 23;
            this.label3.Text = "TOTAL PAGO";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lsubtotal
            // 
            this.lsubtotal.BackColor = System.Drawing.Color.White;
            this.lsubtotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsubtotal.Location = new System.Drawing.Point(270, 483);
            this.lsubtotal.Name = "lsubtotal";
            this.lsubtotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lsubtotal.Size = new System.Drawing.Size(300, 37);
            this.lsubtotal.TabIndex = 46;
            this.lsubtotal.Text = "0,00";
            // 
            // ltroco
            // 
            this.ltroco.BackColor = System.Drawing.Color.White;
            this.ltroco.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ltroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltroco.ForeColor = System.Drawing.Color.Blue;
            this.ltroco.Location = new System.Drawing.Point(274, 539);
            this.ltroco.Name = "ltroco";
            this.ltroco.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ltroco.Size = new System.Drawing.Size(300, 40);
            this.ltroco.TabIndex = 47;
            this.ltroco.Text = "0,00";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Location = new System.Drawing.Point(323, 607);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 48;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 29);
            this.label7.TabIndex = 49;
            this.label7.Text = "PARCELAS";
            // 
            // parcelas
            // 
            this.parcelas.BackColor = System.Drawing.Color.White;
            this.parcelas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.parcelas.Enabled = false;
            this.parcelas.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parcelas.Location = new System.Drawing.Point(260, 200);
            this.parcelas.Name = "parcelas";
            this.parcelas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.parcelas.Size = new System.Drawing.Size(300, 37);
            this.parcelas.TabIndex = 50;
            this.parcelas.Text = "1";
            this.parcelas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.parcelas_KeyPress);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::PDV.Properties.Resources.campotexto;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(231, 189);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(338, 60);
            this.pictureBox5.TabIndex = 51;
            this.pictureBox5.TabStop = false;
            // 
            // cpf
            // 
            this.cpf.AutoSize = true;
            this.cpf.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpf.Location = new System.Drawing.Point(12, 5);
            this.cpf.Name = "cpf";
            this.cpf.Size = new System.Drawing.Size(56, 18);
            this.cpf.TabIndex = 52;
            this.cpf.Text = "cliente";
            // 
            // Recebimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(588, 669);
            this.Controls.Add(this.cpf);
            this.Controls.Add(this.parcelas);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.ltroco);
            this.Controls.Add(this.lsubtotal);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.dinheirotext);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.valorcartaotext);
            this.Controls.Add(this.cbodebito);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lapagartext);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Recebimento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recebimento";
            this.Load += new System.EventHandler(this.Recebimento_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Recebimento_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lapagartext;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbodebito;
        public System.Windows.Forms.TextBox valorcartaotext;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox dinheirotext;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox lsubtotal;
        public System.Windows.Forms.TextBox ltroco;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox parcelas;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label cpf;

    }
}