﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
using Conn;

namespace Atualizacao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
        }
        Conn.Class1 conex = new Conn.Class1();

        private void InitializeBackgroundWorker()
        {
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
            backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
        }
        private string usuario = "somasite1";
        private string senha = "marcostaba07";
        private string servidor = "ftp://somasite.com.br/mariana/";
        int i;
        List<string> liArquivos = new List<string>();
        string fileName;
        string dir = Application.StartupPath + "\\";
        AtualizaBanco banco = new AtualizaBanco();

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = "";
            label4.Text = "";
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            progressBar2.Minimum = 0;
            progressBar2.Value = 0;
            Lista();
                        
        }
        private void Lista()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(servidor);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential(usuario, senha);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = true;
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                Stream responseStream = response.GetResponseStream();
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    liArquivos = reader.ReadToEnd().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList<string>();
                }
            }
            i = 0;
            progressBar2.Maximum = liArquivos.Count-1;
            backgroundWorker1.RunWorkerAsync();

        }
        private void Download(string nome, string server)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(server + nome);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(usuario, senha);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = true;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            byte[] buffer = new byte[2048];
            FileStream newFile = new FileStream(dir + nome, FileMode.Create);
            MessageBox.Show(dir + nome);
            //FileStream newFile = new FileStream(@"c:\Program Files\lepetit\" + nome, FileMode.Create);
            int readCount = responseStream.Read(buffer, 0, buffer.Length);
            while (readCount > 0)
            {
                //Escrever o arquivo
                newFile.Write(buffer, 0, readCount);
                readCount = responseStream.Read(buffer, 0, buffer.Length);

            }
            newFile.Close();
            responseStream.Close();
            response.Close();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            i = 0;
            try
            {
                foreach (string item in liArquivos)
                {
                    if ((item.ToString() != "."))
                    {
                        if (item.ToString() != "..")
                        {
                            i++;
                            fileName = item;
                            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(servidor + fileName);
                            request.Credentials = new NetworkCredential(usuario, senha);
                            request.Method = WebRequestMethods.Ftp.GetFileSize;
                            request.Proxy = null;
                            long fileSize; // this is the key for ReportProgress
                            using (WebResponse resp = request.GetResponse())
                                fileSize = resp.ContentLength;
                            request = (FtpWebRequest)WebRequest.Create(servidor + fileName);
                            request.Credentials = new NetworkCredential(usuario, senha);
                            request.Method = WebRequestMethods.Ftp.DownloadFile;
                            FileInfo fi = new FileInfo(dir + fileName);
                            if (this.IsFileLocked(fi))
                            {
                                StreamWriter sw = new StreamWriter(dir + fileName, true);
                                File.Create(dir + fileName).Close();
                            }
                            using (FtpWebResponse responseFileDownload = (FtpWebResponse)request.GetResponse())
                            using (Stream responseStream = responseFileDownload.GetResponseStream())
                            using (FileStream writeStream = new FileStream(dir + fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                            {
                                int Length = 2048;
                                Byte[] buffer = new Byte[Length];
                                int bytesRead = responseStream.Read(buffer, 0, Length);
                                int bytes = 0;
                                while (bytesRead > 0)
                                {
                                    writeStream.Write(buffer, 0, bytesRead);
                                    bytesRead = responseStream.Read(buffer, 0, Length);
                                    bytes += bytesRead;// don't forget to increment bytesRead !
                                    int totalSize = (int)(fileSize) / 1000; // Kbytes
                                    if (bytes != 0)
                                    {
                                        backgroundWorker1.ReportProgress((bytes / 1000) * 100 / totalSize, totalSize);
                                    }

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO AO ATUALIZAR: " + ex.Message, "ATENÇÂO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            

        }
        private bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label4.Text = e.ProgressPercentage * (int)e.UserState / 100 + " bytes / " + e.UserState + " bytes" + " = " + e.ProgressPercentage + " %";
            //label4.Text = e.ProgressPercentage + " %";
            progressBar1.Value = Convert.ToInt32(e.ProgressPercentage);
            progressBar2.Value = i;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AtualizarData();
            AtualizaBanco();
            MessageBox.Show("ATUALIZADO COM SUCESSO");
            label4.Text = "0";
            System.Diagnostics.Process.Start(dir+"SISTEMA.exe");
            Application.Exit();
            
        }
        private void AtualizaBanco()
        {
            MySqlConnection conexao = conex.conectamysql();
            MySqlCommand commS = new MySqlCommand("select * from Mariana", conexao);
            MySqlDataReader da = commS.ExecuteReader();
            while (da.Read())
            {
                if (da["ATUALIZA_BANCO"].ToString() == "1")
                {
                    FileInfo file = new FileInfo(dir +"atualizar.sql");
                    if (file.Exists)
                    {
                        string script = file.OpenText().ReadToEnd();
                        banco.Atualizar(script);
                    }
                    
                }
            }
            da.Close();
            conexao.Close();
        }
        public void AtualizarData()
        {
            string SQL = null;
            SQL += "UPDATE Mariana SET DATA_ATUALIZACAO=@DATAATUALIZACAO ";
            MySqlConnection DbConnection = conex.conectamysql();
            MySqlCommand cmd = new MySqlCommand(SQL, DbConnection);
            cmd.Parameters.Add("@DATAATUALIZACAO",MySqlDbType.Datetime).Value = DateTime.Now;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                conex.GeraErro("atualizacao", err.Message.ToString(), DateTime.Now.ToString());
            }
            finally
            {
                DbConnection.Close();
            }

        }

    }
}
