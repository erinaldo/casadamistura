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
using System.Threading;
using System.ServiceProcess;
using System.IO;



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
            //Acessoaosistema();
            querAcessar();
            //Acessar();

            //Cadastros.Clientes cliente = new Cadastros.Clientes();
            //cliente.ShowDialog();
            //this.Close();
        }
        private bool Verificaacesso()
        {
            MySqlConnection conexi = conex.conectamysql();
            if (conexi.State == ConnectionState.Open)
            {
                MySqlCommand commS = new MySqlCommand("select * from Mariana where NOME = '" + hd.Text + "'", conexi);
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
            else
            {
                MessageBox.Show("SEM CONEXÃO COM MYSQL", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                retorno = false;
            }
              return retorno;
        }
        private void Acesso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Acessoaosistema();
                //Acessar();
                querAcessar();
            }
        }
        private void querAcessar()
        {
            if (usuariotext.Text.ToLower() == "demo" && senhatext.Text.ToLower() == "demo")
            {

                if (conex.ReadKey("marca-ti") == null)
                {
                    conex.WriteKey("marca-ti", CryptorEngine.Encrypt("1", true));
                }
                else
                {
                    int i = Convert.ToInt32(CryptorEngine.Decrypt(conex.ReadKey("marca-ti"), true));

                    if (!conex.IsNumeric(Convert.ToString(i)))
                    {
                        MessageBox.Show("TENTATIVAS DE ACESSO DEMO EXCEDIDAS", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (i > 50)
                    {
                        MessageBox.Show("TENTATIVAS DE ACESSO DEMO EXCEDIDAS", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        i = i + 1;
                        if (conex.WriteKey("marca-ti", CryptorEngine.Encrypt(i.ToString(), true)))
                        {
                            SessaoSistema.Desbloqueado = true;
                            SessaoSistema.NomeUsuario = "DEMO";
                            SessaoSistema.UsuarioId = "1";
                            SessaoSistema.perfil = "ADMINISTRADOR";
                            Hide();
                            TelaInicial tela = new TelaInicial();
                            tela.Show();
                            Perifericos.Form1 teclado = new Perifericos.Form1();
                            teclado.Show();
                        }
                        else
                        {
                            MessageBox.Show("ERRO 5000", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
            ////else 
            ////if (hd.Text == "3EF01D82" || hd.Text == "F0CB2EE6" || hd.Text == "5A5F3324")
            ////{
            //SessaoSistema.Desbloqueado = true;
            //SessaoSistema.NomeUsuario = "admin";
            //SessaoSistema.UsuarioId = "1";
            //SessaoSistema.perfil = "ADMINISTRADOR";

            //Form1 tela = new Form1();
            //tela.Show();
            //Hide();
            //}
            else
            {
                Acessoaosistema();
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
                TelaInicial tela = new TelaInicial();
                tela.Show();
                Perifericos.Form1 teclado = new Perifericos.Form1();
                teclado.Show();

            }
            else
            {
                MessageBox.Show("ACESSO INVALIDO");
            }
        }
        private void Acesso_Load(object sender, EventArgs e)
        {
            /*######### RE-CRIO O BEMAFI32.INI ##############################*/
            #region RECRIO O BEMAFI32.INI
            string[] arrLine = File.ReadAllLines(Application.StartupPath + "\\BemaFI32.ini");
            arrLine[30 - 1] = "Porta=DEFAULT";
            File.WriteAllLines(Application.StartupPath + "\\BemaFI32.ini", arrLine);
            #endregion
            /*######### FIM RE-CRIO O BEMAFI32.INI ##############################*/

            /*######### VERIFICO PROCESSO SQLSERVER ##############################*/
            #region VERIFICO PROCESSO SQLSERVER
            IniFile ini = new IniFile(Application.StartupPath + "\\settings.ini");
            string valor = ini.IniReadValue("Sistema", "Services");
            List<ServiceController> serviceControllers;
            serviceControllers = ServiceController.GetServices(".").Where(sc => sc.ServiceName.Contains(valor)).ToList();
            foreach (ServiceController serviceController in serviceControllers)
            {
                Console.WriteLine("{0}: {1}", serviceController.ServiceName, serviceController.Status);
                Console.WriteLine("\t{0}\n", serviceController.DisplayName);
                //MessageBox.Show("ATIVANDO SERVIÇO DE BANCO DE DADOS", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (serviceController.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
                {
                    //using (new Impersonation(null, "somasite-PC\\somasite", "251258"))//{ //}

                    int timeoutMilliseconds = 1000;
                    TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);
                    serviceController.Start();
                    serviceController.WaitForStatus(ServiceControllerStatus.Running, timeout);
                }
            }
            #endregion
            /*######### FIM PROCESSO SQLSERVER ##############################*/

            /*######### SUBO FISCAL MANAGER ##############################*/
            #region SUBO FISCAL MANAGER
            //System.Diagnostics.Process.Start("Atualizacao.exe");
            string installPath = GetJavaInstallationPath();
            string filePath = System.IO.Path.Combine(installPath, "bin\\javaw.exe");
            //if (System.IO.File.Exists(filePath)){}

            Carregando load = new Carregando();
            load.Show();
            Process[] fiscalmanager = Process.GetProcessesByName("javaw");

            if (fiscalmanager.Length == 0)
            {
                ProcessStartInfo ps = new ProcessStartInfo(filePath, @"-jar C:\\BematechFiscal\\SAT\\app\\FiscalManagerSat.jar");
                var process = Process.Start(ps);
                process.WaitForInputIdle();

            }
            #endregion

            /*######### SUBO VirtualECF4000 ##############################*/
            #region SUBO VirtualECF4000
            Thread.Sleep(20000);
            Process[] virtualecf = Process.GetProcessesByName("VirtualECF4000");
            //MessageBox.Show(virtualecf.Length.ToString());
            foreach (Process p in virtualecf)
            {
                p.Kill();
            }
            fiscalmanager = Process.GetProcessesByName("javaw");
            if (fiscalmanager.Length > 0)
            {
                System.Diagnostics.Process.Start(@"C:\Mariana\Virtual ECF.lnk");
            }
            Thread.Sleep(5000);
            load.Close();
            #endregion
            /*######### FIM FISCAL MANAGER ##############################*/
            /*######### FIM VirtualECF4000 ##############################*/

           
            hd.Text = GetHDDSerialNumber(numerodohd[0].Replace(':',' ').Trim());

        }
        private string GetJavaInstallationPath()
        {
            string environmentPath = Environment.GetEnvironmentVariable("JAVA_HOME");
            if (!string.IsNullOrEmpty(environmentPath))
            {
                return environmentPath;
            }

            string javaKey = "SOFTWARE\\JavaSoft\\Java Runtime Environment\\";
            using (Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(javaKey))
            {
                string currentVersion = rk.GetValue("CurrentVersion").ToString();
                using (Microsoft.Win32.RegistryKey key = rk.OpenSubKey(currentVersion))
                {
                    return key.GetValue("JavaHome").ToString();
                }
            }
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
