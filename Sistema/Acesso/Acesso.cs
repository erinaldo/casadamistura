using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Conn;
using Perifericos;
using System.Management;



namespace SISTEMA
{
    public partial class Acesso : Form
    {

        string versao = null;
        string arquivo = null;
        string nomehd = null;
        private bool retorno;
        public Acesso()
        {
            InitializeComponent();
        }
        //Método da API
        [DllImport("wininet.dll")]
        private extern static Boolean InternetGetConnectedState(out int Description, int ReservedValue);
        Conn.Class1 conex = new Conn.Class1();
        string[] numerodohd = Application.StartupPath.Split('\\');
        // Um método que verifica se esta conectado
        Acess acesso = new Acess();
        public string GetHDDSerialNumber(string drive)
        {
            //check to see if the user provided a drive letter
            //if not default it to "C"
            if (drive == "" || drive == null)
            {
                drive = "C";
            }
            //create our ManagementObject, passing it the drive letter to the
            //DevideID using WQL
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + drive + ":\"");
            //bind our management object
            disk.Get();
            //return the serial number
            return disk["VolumeSerialNumber"].ToString();
        }
        public static Boolean IsConnected()
        {
            int Description;
            return InternetGetConnectedState(out Description, 0);
        }
        private void btnAcessar_Click(object sender, EventArgs e)
        {
            //formdll a = new formdll();
            //a.Show();
            Acessoaosistema();
        }
        private bool Verificaacesso()
        {
            retorno = false;
            MySqlConnection conexi = conex.conectamysql();
            if (conexi.State == ConnectionState.Open)
            {
                MySqlCommand commS = new MySqlCommand("select * from Casadamistura where NOME = '" + hd.Text + "'", conexi);
                MySqlDataReader da = commS.ExecuteReader();
                while (da.Read())
                {
                    versao = da["VERSAO"].ToString();
                    arquivo = da["ARQUIVO"].ToString();
                    nomehd = da["NOME"].ToString();

                    if (nomehd != hd.Text)
                    {
                        retorno = false;
                    }
                    else if (da["DATA_CANCELAMENTO"].ToString() == "")
                    {
                        retorno = true;
                    }
                    else
                    {
                        retorno = false;
                    }
                }
            }
               
                return retorno;
            }
        private void Acesso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Acessoaosistema();
                //Acessar();
            }
        }
        private void Acessar()
        {
                acesso.acesso(usuariotext.Text, senhatext.Text);
            
            if (acesso.codusuario != "")
            {
                SessaoSistema.NomeUsuario = acesso.usuario;
                SessaoSistema.UsuarioId = acesso.codusuario;
                SessaoSistema.perfil = acesso.perfil;
                Hide();
                //TelaInicial tela = new TelaInicial();
                Form1 tela = new Form1();
                tela.Show();
                //Perifericos.Form1 teclado = new Perifericos.Form1();
                //teclado.Show();

            }
            else
            {
                MessageBox.Show("ACESSO INVALIDO");
            }
        }
        private void Acesso_Load(object sender, EventArgs e)
        {
            hd.Text = GetHDDSerialNumber(numerodohd[0].Replace(':',' ').Trim());

             //usuariotext.Text = "beni";
            //senhatext.Text = "123";
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Acessoaosistema()
        {
            if ((IsConnected()))
            {
                if (Verificaacesso())
                {
                    if (versao != System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString())
                    {
                        if (MessageBox.Show("SEU SISTEMA PRECISA SER ATUALIZADO, DESEJA ATUALIZAR NESTE MOMENTO?", "ATUALIZAÇÃO SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start("MatarProcessos.exe");
                            System.Diagnostics.Process.Start("Atualizacao.exe");
                            Application.Exit();
                        }
                        else
                        {
                            if ((usuariotext.Text != "") || (senhatext.Text != ""))
                            {
                                Acessar();
                            }
                           SessaoSistema.Desbloqueado = true;
                       }
                        
                    }
                    else if ((usuariotext.Text != "") || (senhatext.Text != ""))
                    {
                        Acessar();
                    }
                    SessaoSistema.Desbloqueado = true;
                }
                else
                {
                    MessageBox.Show("ESTE SISTEMA ESTA BLOQUEADO, POR FAVOR ENTRE EM CONTATO COM ADMINISTRADOR");
                    SessaoSistema.Desbloqueado = false;
                }
            }
            else if (SessaoSistema.Desbloqueado == false)
            {
                MessageBox.Show("Não exite conexão ativa com a internet.");
                Desbloqueiotela desb = new Desbloqueiotela();
                desb.Show();
            }
            else
            {
                Acessar();

            }
        }
    }
}
