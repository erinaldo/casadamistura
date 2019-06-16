namespace Relatorios
{
    partial class Relatorios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Relatorios));
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnComissao = new System.Windows.Forms.Button();
            this.btnGorjeta = new System.Windows.Forms.Button();
            this.btnProfserv = new System.Windows.Forms.Button();
            this.btncaixa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(174, 117);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(138, 66);
            this.button3.TabIndex = 13;
            this.button3.Text = "CLIENTES CADASTRADOS";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 206);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 66);
            this.button2.TabIndex = 12;
            this.button2.Text = "CHEQUES";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(342, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 66);
            this.button1.TabIndex = 11;
            this.button1.Text = "CLIENTE X SERVIÇOS";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnComissao
            // 
            this.btnComissao.Location = new System.Drawing.Point(13, 117);
            this.btnComissao.Name = "btnComissao";
            this.btnComissao.Size = new System.Drawing.Size(138, 66);
            this.btnComissao.TabIndex = 10;
            this.btnComissao.Text = "COMISSÃO";
            this.btnComissao.UseVisualStyleBackColor = true;
            // 
            // btnGorjeta
            // 
            this.btnGorjeta.Location = new System.Drawing.Point(342, 21);
            this.btnGorjeta.Name = "btnGorjeta";
            this.btnGorjeta.Size = new System.Drawing.Size(138, 66);
            this.btnGorjeta.TabIndex = 9;
            this.btnGorjeta.Text = "GORJETA";
            this.btnGorjeta.UseVisualStyleBackColor = true;
            // 
            // btnProfserv
            // 
            this.btnProfserv.Location = new System.Drawing.Point(174, 21);
            this.btnProfserv.Name = "btnProfserv";
            this.btnProfserv.Size = new System.Drawing.Size(138, 66);
            this.btnProfserv.TabIndex = 8;
            this.btnProfserv.Text = "PROFISSIONAIS X SERVIÇOS";
            this.btnProfserv.UseVisualStyleBackColor = true;
            // 
            // btncaixa
            // 
            this.btncaixa.Location = new System.Drawing.Point(13, 21);
            this.btncaixa.Name = "btncaixa";
            this.btncaixa.Size = new System.Drawing.Size(138, 66);
            this.btncaixa.TabIndex = 7;
            this.btncaixa.Text = "RELATÓRIO CAIXA";
            this.btncaixa.UseVisualStyleBackColor = true;
            this.btncaixa.Click += new System.EventHandler(this.btncaixa_Click);
            // 
            // Relatorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 297);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnComissao);
            this.Controls.Add(this.btnGorjeta);
            this.Controls.Add(this.btnProfserv);
            this.Controls.Add(this.btncaixa);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Relatorios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatorios";
            this.Load += new System.EventHandler(this.Relatorios_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnComissao;
        private System.Windows.Forms.Button btnGorjeta;
        private System.Windows.Forms.Button btnProfserv;
        private System.Windows.Forms.Button btncaixa;
    }
}