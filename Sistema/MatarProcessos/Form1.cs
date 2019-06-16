using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace MatarProcessos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FecharProcessos();
            Application.Exit();

        }
            private void FecharProcessos()
        {
            Process[] processos = Process.GetProcessesByName("SISTEMA");
            foreach (Process processo in processos)
            {
                processo.Kill();
            }
        }
         
    }
}
