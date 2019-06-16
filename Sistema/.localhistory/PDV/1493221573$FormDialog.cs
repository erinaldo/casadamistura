using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PDV
{
	/// <summary>
	/// Summary description for FormDialog.
	/// </summary>
	public class FormDialog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox textBoxRetorno;
        private PictureBox pictureBox3;
        private Label label1;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormDialog()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRetorno = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxRetorno);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Location = new System.Drawing.Point(0, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 130);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "CPF / CNPJ do Consumidor:";
            // 
            // textBoxRetorno
            // 
            this.textBoxRetorno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxRetorno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRetorno.Location = new System.Drawing.Point(19, 52);
            this.textBoxRetorno.Name = "textBoxRetorno";
            this.textBoxRetorno.Size = new System.Drawing.Size(320, 19);
            this.textBoxRetorno.TabIndex = 0;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::PDV.Properties.Resources.campotexto;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(11, 40);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(341, 42);
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(95, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "&OK";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(199, 140);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 24);
            this.button2.TabIndex = 2;
            this.button2.Text = "&Cancelar";
            // 
            // FormDialog
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(432, 177);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CUPOM";
            this.Load += new System.EventHandler(this.FormDialog_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormDialog_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        System.Drawing.Color back = System.Drawing.ColorTranslator.FromHtml("#CFE8F5");
		private void FormDialog_Load(object sender, System.EventArgs e)
		{
            this.BackColor = back;
		}
        Conn.Class1 con = new Conn.Class1();
        private void FormDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var CpfCnpj = textBoxRetorno.Text.Replace(".", "").Replace("-", "").Replace("/", "");
                if (CpfCnpj.Length == 11)
                {
                    if (con.validarCPF(CpfCnpj))
                    {
                        button1.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("CPF INVALIDO", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (CpfCnpj.Length == 14)
                {
                    if (con.IsCnpj(CpfCnpj))
                    {
                        button1.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("CNPJ INVALIDO", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
	}
}
