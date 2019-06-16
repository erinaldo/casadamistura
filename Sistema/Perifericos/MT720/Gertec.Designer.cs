namespace Perifericos.MT720
{
    partial class Gertec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gertec));
            this.lbInform = new System.Windows.Forms.Label();
            this.btIniciar = new System.Windows.Forms.Button();
            this.VConectados = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.timerVConectados = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbInform
            // 
            this.lbInform.AutoSize = true;
            this.lbInform.Location = new System.Drawing.Point(12, 9);
            this.lbInform.Name = "lbInform";
            this.lbInform.Size = new System.Drawing.Size(35, 13);
            this.lbInform.TabIndex = 0;
            this.lbInform.Text = "label1";
            // 
            // btIniciar
            // 
            this.btIniciar.Location = new System.Drawing.Point(12, 25);
            this.btIniciar.Name = "btIniciar";
            this.btIniciar.Size = new System.Drawing.Size(75, 23);
            this.btIniciar.TabIndex = 1;
            this.btIniciar.Text = "INICIAR";
            this.btIniciar.UseVisualStyleBackColor = true;
            this.btIniciar.Click += new System.EventHandler(this.btIniciar_Click);
            // 
            // VConectados
            // 
            this.VConectados.FormattingEnabled = true;
            this.VConectados.Location = new System.Drawing.Point(12, 70);
            this.VConectados.Name = "VConectados";
            this.VConectados.Size = new System.Drawing.Size(260, 147);
            this.VConectados.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "IPs Conectados";
            // 
            // timerVConectados
            // 
            this.timerVConectados.Interval = 10000;
            this.timerVConectados.Tick += new System.EventHandler(this.timerVConectados_Tick);
            // 
            // Gertec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.VConectados);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btIniciar);
            this.Controls.Add(this.lbInform);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Gertec";
            this.Text = "Gertec";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Gertec_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbInform;
        private System.Windows.Forms.Button btIniciar;
        private System.Windows.Forms.ListBox VConectados;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timerVConectados;

    }
}