namespace Relatorios
{
    partial class FiltroRptMovimentoCaixa
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
            this.label1 = new System.Windows.Forms.Label();
            this.datainicial = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.datafinal = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cbofuncionario = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Periodo:";
            // 
            // datainicial
            // 
            this.datainicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datainicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datainicial.Location = new System.Drawing.Point(110, 33);
            this.datainicial.Name = "datainicial";
            this.datainicial.Size = new System.Drawing.Size(125, 26);
            this.datainicial.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(241, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Á";
            // 
            // datafinal
            // 
            this.datafinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datafinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datafinal.Location = new System.Drawing.Point(273, 34);
            this.datafinal.Name = "datafinal";
            this.datafinal.Size = new System.Drawing.Size(125, 26);
            this.datafinal.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Caixa:";
            // 
            // cbofuncionario
            // 
            this.cbofuncionario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbofuncionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbofuncionario.FormattingEnabled = true;
            this.cbofuncionario.Location = new System.Drawing.Point(110, 92);
            this.cbofuncionario.Name = "cbofuncionario";
            this.cbofuncionario.Size = new System.Drawing.Size(288, 28);
            this.cbofuncionario.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Relatorios.Properties.Resources.acessar;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Location = new System.Drawing.Point(316, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 72);
            this.button1.TabIndex = 17;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FiltroRptMovimentoCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 243);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbofuncionario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.datafinal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.datainicial);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "FiltroRptMovimentoCaixa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtro Movimento Caixa";
            this.Load += new System.EventHandler(this.FiltroRptMovimentoCaixa_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FiltroRptMovimentoCaixa_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datainicial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker datafinal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbofuncionario;
        private System.Windows.Forms.Button button1;
    }
}