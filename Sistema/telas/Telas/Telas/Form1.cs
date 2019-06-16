using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#BFBFFF");
            
            pictureBox2.BackColor = System.Drawing.Color.Transparent;
            pictureBox3.BackColor = System.Drawing.Color.Transparent;
            pictureBox4.BackColor = System.Drawing.Color.Transparent;
            pictureBox5.BackColor = System.Drawing.Color.Transparent;
            pictureBox2.Parent = pictureBox1;
            pictureBox3.Parent = pictureBox1;
            pictureBox4.Parent = pictureBox1;
            pictureBox5.Parent = pictureBox1;
            groupBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#E3E9D2");
            groupBox2.BackColor = System.Drawing.ColorTranslator.FromHtml("#E3E9D2");
            label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6CAAFF");
            label2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6CAAFF");
            label3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6CAAFF");
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
