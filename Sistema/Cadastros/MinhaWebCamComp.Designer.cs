﻿namespace Cadastros
{
    partial class MinhaWebCamComp
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrRefrashFrame = new System.Windows.Forms.Timer(this.components);
            this.ImgWebCam = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImgWebCam)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrRefrashFrame
            // 
            this.tmrRefrashFrame.Tick += new System.EventHandler(this.tmrRefrashFrame_Tick);
            // 
            // ImgWebCam
            // 
            this.ImgWebCam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImgWebCam.Location = new System.Drawing.Point(0, 0);
            this.ImgWebCam.Name = "ImgWebCam";
            this.ImgWebCam.Size = new System.Drawing.Size(386, 349);
            this.ImgWebCam.TabIndex = 0;
            this.ImgWebCam.TabStop = false;
            // 
            // MinhaWebCamComp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ImgWebCam);
            this.Name = "MinhaWebCamComp";
            this.Size = new System.Drawing.Size(386, 349);
            ((System.ComponentModel.ISupportInitialize)(this.ImgWebCam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Timer tmrRefrashFrame;
        public System.Windows.Forms.PictureBox ImgWebCam;
    }
}
