namespace Perifericos
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btIniciar = new System.Windows.Forms.ToolStripMenuItem();
            this.btSair = new System.Windows.Forms.ToolStripMenuItem();
            this.lbInform = new System.Windows.Forms.Label();
            this.VConectados = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.timerVConectados = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btIniciar,
            this.btSair});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(400, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btIniciar
            // 
            this.btIniciar.Name = "btIniciar";
            this.btIniciar.Size = new System.Drawing.Size(51, 20);
            this.btIniciar.Text = "Iniciar";
            this.btIniciar.Click += new System.EventHandler(this.btIniciar_Click);
            // 
            // btSair
            // 
            this.btSair.Name = "btSair";
            this.btSair.Size = new System.Drawing.Size(38, 20);
            this.btSair.Text = "Sair";
            this.btSair.Click += new System.EventHandler(this.btSair_Click);
            // 
            // lbInform
            // 
            this.lbInform.AutoSize = true;
            this.lbInform.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInform.ForeColor = System.Drawing.Color.Red;
            this.lbInform.Location = new System.Drawing.Point(13, 32);
            this.lbInform.Name = "lbInform";
            this.lbInform.Size = new System.Drawing.Size(0, 13);
            this.lbInform.TabIndex = 2;
            // 
            // VConectados
            // 
            this.VConectados.FormattingEnabled = true;
            this.VConectados.Location = new System.Drawing.Point(16, 47);
            this.VConectados.Name = "VConectados";
            this.VConectados.Size = new System.Drawing.Size(344, 147);
            this.VConectados.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "IPs Conectados";
            // 
            // timerVConectados
            // 
            this.timerVConectados.Enabled = true;
            this.timerVConectados.Interval = 10000;
            this.timerVConectados.Tick += new System.EventHandler(this.timerVConectados_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 226);
            this.Controls.Add(this.VConectados);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbInform);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Servidor de Microterminais";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btIniciar;
        private System.Windows.Forms.ToolStripMenuItem btSair;
        private System.Windows.Forms.Label lbInform;
        private System.Windows.Forms.ListBox VConectados;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timerVConectados;
    }
}

