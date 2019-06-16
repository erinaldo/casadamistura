using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Data.OleDb;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace Conn
{
    public class Class1
    {

        //Método da API
        [DllImport("wininet.dll")]
        private extern static Boolean InternetGetConnectedState(out int Description, int ReservedValue);
        private MySqlConnection bdConn; //MySQL
        //private MySqlDataAdapter bdAdapter;
        private DataSet bdDataSet; //MySQL
        int dia = 00;
        int mes = 00;
        int ano = 00;
        string[] endereco;
        string PATH = @"SOFTWARE\QX3\ROTAS\oracle\10.1G\Hosts\que\deus\ilumine\minha\vida";

        public OleDbConnection Cnncontrol()
        {
            IniFile ini = new IniFile(Application.StartupPath+"\\settings.ini");
            string valor = ini.IniReadValue("Sistema", "Computer");
            string conexao = "Provider=SQLOLEDB;Data Source=" + valor + ";Initial Catalog=PwdDb;Trusted_Connection=yes;User Id=control;Password=control00;";
            string erro = "";
            string connectionString = conexao;
            string path = Directory.GetCurrentDirectory()+"\\logs";
            OleDbConnection DbConnection = new OleDbConnection(connectionString);
            try
            {
                DbConnection.Open();

            }
            catch (OleDbException ex)
            {

                erro = ex.Message + "Erro de conexão";
                GeraErro("conexao", erro, DateTime.Now.ToShortDateString());
                DbConnection.Close();
            }

            return DbConnection;
        }
        public MySqlConnection conectamysql()
        {
            bdDataSet = new DataSet();
            string conexao = "Server=mysql01.marca-ti.hospedagemdesites.ws;Database=marca_ti;Uid=marca_ti;Pwd=marcostaba07;";
            bdConn = new MySqlConnection(conexao);
            try
            {
                bdConn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("Impossível estabelecer conexão" + e);
                bdConn.Close();
            }

            return bdConn;
        }
        public void email(string perro, string pdata, string pfuncao,string plocal)
        {
            StreamWriter txt = new StreamWriter(plocal);
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("marcos@marcati.com.br", "marcati.com.br", System.Text.Encoding.UTF8);
            mail.To.Add("marcos@marcati.com.br");
            mail.Subject = "Erro de Sistema";
            mail.Body = perro;
            SmtpClient client = new SmtpClient("smtp.marcati.com.br", 26);
            client.Host = "smtp.controlvt.com";
            client.Credentials = new System.Net.NetworkCredential("marcos@marcati.com.br", "880315");
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.EnableSsl = false;
            //Attachment anexado = new Attachment(@"C:\inetpub\wwwroot\FTP\Control\Upload\" + FileUpload1.FileName, MediaTypeNames.Application.Octet);
            //mail.Attachments.Add(anexado);

            try
            {
                client.Send(mail);
            }
            catch (SmtpException ex)
            {
                txt.WriteLine("ERRO: " + DateTime.Now + ": - " + ex);
            }
            catch (Exception ex)
            {
                txt.WriteLine("ERRO: " + DateTime.Now + ": - " + ex);
            }

        }
        public void GeraErro(string funcao, string erro, string datahora)
        {
            string diretorio = Application.StartupPath+"\\logs";
            if (!Directory.Exists(diretorio))
                Directory.CreateDirectory(diretorio);
            StreamWriter grava = new StreamWriter(diretorio + @"\erro_" + DateTime.Now.ToShortDateString().Replace('/', '_') + "_" + DateTime.Now.ToLongTimeString().Replace(':', '_') + ".log",true);
            grava.WriteLine(datahora + " : " + erro + " - " + funcao);
            grava.Close();
        }
        public void FormataCnpj(TextBox txt)
        {
            //14.218.835/0001-27
            string data = txt.Text;
            char valor = Convert.ToChar(50);
            if (txt.TextLength == 2)
            {
                data = data + ".";
                txt.Text = data;
                txt.SelectionStart = (txt.TextLength + 1);
            }
            else if (txt.TextLength == 6)
            {
                data = data + ".";
                txt.Text = data;
                txt.SelectionStart = (txt.TextLength + 1);
            }
            else if (txt.TextLength == 10)
            {
                data = data + "/";
                txt.Text = data;
                txt.SelectionStart = (txt.TextLength + 1);
            }
            else if (txt.TextLength == 15)
            {
                data = data + "-";
                txt.Text = data;
                txt.SelectionStart = (txt.TextLength + 1);
            }
        }
        public void Formada_data(TextBox txt)
        {
            string data = txt.Text;
            char valor = Convert.ToChar(50);
            if (txt.TextLength == 2)
            {
                data = data + "/";
                txt.Text = data;
                txt.SelectionStart = (txt.TextLength + 1);
            }
            else if (txt.TextLength == 5)
            {
                data = data + "/";
                txt.Text = data;
                txt.SelectionStart = (txt.TextLength + 1);
            }
        }
        public void FormataModeda(TextBox txt)
        {
            string n = null;
            double v = 0;
            try
            {
                n = txt.Text.Replace(",", "").Replace(".", "");
                if (n.Equals(""))
                {
                    n = "000";
                }
                n = n.PadLeft(3, '0');
                if (n.Length > 3 && n.Substring(0, 1) == "0")
                {
                    n = n.Substring(1, n.Length - 1);
                }
                v = Convert.ToDouble(n) / 100;
                txt.Text = String.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Valor");
            }
        }
        public bool Checadata(TextBox txt)
        {
            dia = 00;
            mes = 00;
            ano = 00;

            if (txt.Text != "")
            {
                dia = Convert.ToInt32(txt.Text.Substring(0, 2));
                mes = Convert.ToInt32(txt.Text.Substring(3, 2));
                ano = Convert.ToInt32(txt.Text.Substring(6, 4));
            }
            if ((mes == 02) && (DateTime.IsLeapYear(ano)) && (dia > 29))
            {
                return false;
            }
            else if ((mes == 02) && !(DateTime.IsLeapYear(ano)) && (dia > 28))
            {
                return false;
            }
            else if (mes > 12)
            {
                return false;
            }
            else if (ano < 1899)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public string MascaraCnpjCpf(string pCnpjCpf)
        {
        string result = "";
        if (pCnpjCpf.Length == 14)
        {
        result = pCnpjCpf.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15,"-");
        }
        if (pCnpjCpf.Length == 11)
        {
        result = pCnpjCpf.Insert(3, ".").Insert(7,".").Insert(11, "-");
        }
        if ((pCnpjCpf.Length != 11) && (pCnpjCpf.Length != 14))
        {
        result = pCnpjCpf;
        }
        return result;
        }
        public string[] BuscaCep(string Pcep)
        {
            if (IsConnected())
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.buscacep.correios.com.br/servicos/dnec/consultaLogradouroAction.do?CEP=" + Pcep + "&Metodo=listaLogradouro&TipoConsulta=cep&StartRow=1&EndRow=10");
                int count;
                byte[] buf = new byte[1000];
                StringBuilder sb = new StringBuilder();
                string temp;
                string html = null;
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream stream = httpWebResponse.GetResponseStream();
                do
                {
                    count = stream.Read(buf, 0, buf.Length);
                    temp = Encoding.Default.GetString(buf, 0, count).Trim();
                    sb.Append(temp);

                } while (count > 0);
                html = sb.ToString();
                int existecep;
                existecep = html.IndexOf("<table border=\"0\" cellspacing=\"1\" cellpadding=\"5\" bgcolor=\"gray\">");
                if (existecep > 0)
                {
                    html = html.Substring(existecep, 500);
                    html = Regex.Replace(html, "<(.|\n)*?>", " ").Trim();
                    endereco = html.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                }
                httpWebResponse.Close();
            }
            else
            {
                //endereco[0] = "";
                //endereco[1] = "";
                //endereco[2] = "";
                //endereco[3] = "";
                MessageBox.Show("VOCÊ PRECISA ESTAR CONECTADO A INTERNET PARA ESTA CONSULTA", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return endereco;
                
            
        }
        public void LimpaTextBoxes(Control.ControlCollection cc)
        {
            foreach (Control ctrl in cc)
            {
                TextBox tb = ctrl as TextBox;
                if (tb != null)
                {
                    tb.Clear();
                }
                else
                {
                    LimpaTextBoxes(ctrl.Controls);
                }
            }
        }
        public static Boolean IsConnected()
        {
            int Description;
            return InternetGetConnectedState(out Description, 0);
        }
        public System.Drawing.Color amarelo()
        {
            return System.Drawing.ColorTranslator.FromHtml("#FFF68F");
        }
        public System.Drawing.Color branco()
        {
            return System.Drawing.Color.White;
        }
        public System.Drawing.Color Fundo()
        {
            return System.Drawing.ColorTranslator.FromHtml("#BFBFFF");
        }
        public System.Drawing.Color FundoGrupo()
        {
            return System.Drawing.ColorTranslator.FromHtml("#E3E9D2");
        }
        public void AutoComplete(ComboBox cb, System.Windows.Forms.KeyPressEventArgs e)
        {
            this.AutoComplete(cb, e, false);
        }
        public void AutoComplete(ComboBox cb, System.Windows.Forms.KeyPressEventArgs e, bool blnLimitToList)
        {
            string strFindStr = "";

            if (e.KeyChar == (char)8)
            {
                if (cb.SelectionStart <= 1)
                {
                    cb.Text = "";
                    return;
                }

                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text.Substring(0, cb.Text.Length - 1);
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1);
            }
            else
            {
                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text + e.KeyChar;
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart) + e.KeyChar;
            }

            int intIdx = -1;

            // Search the string in the ComboBox list.

            intIdx = cb.FindString(strFindStr);

            if (intIdx != -1)
            {
                cb.SelectedText = "";
                cb.SelectedIndex = intIdx;
                cb.SelectionStart = strFindStr.Length;
                cb.SelectionLength = cb.Text.Length;
                e.Handled = true;
            }
            else
            {
                e.Handled = blnLimitToList;
            }

        }
        public void ChecaNumero(KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                e.KeyChar = Convert.ToChar(08);
            }
        }
        public string Checatipoproduto(string Produto)
        {
            string strguia = "";
            string tipoproduto = null;
            if ((Produto.Substring(0, 1) == "2") && (Produto.Length > 6))
            {
                strguia = ("SELECT TIPO_ESTOQUE FROM p_produtos WHERE SUBSTRING(CODIGO_BARRAS,0,8) LIKE '" + Produto.Substring(0, 7) + "' AND DATA_CANCELAMENTO IS NULL");
            }
            else
            {
                strguia = ("SELECT TIPO_ESTOQUE FROM p_produtos WHERE CODIGO_BARRAS LIKE '" + Produto + "' AND DATA_CANCELAMENTO IS NULL");                
            }
                    OleDbConnection con = Cnncontrol();
                    OleDbCommand cmd = new OleDbCommand(strguia, con);
                    cmd.CommandType = CommandType.Text;
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        tipoproduto = dr["TIPO_ESTOQUE"].ToString();
                    }

                    return tipoproduto;
        }
        private static DateTime TimeFromUnixTimestamp(int unixTimestamp)
        {
            DateTime unixYear0 = new DateTime(1970, 1, 1);
            long unixTimeStampInTicks = unixTimestamp * TimeSpan.TicksPerSecond;
            DateTime dtUnix = new DateTime(unixYear0.Ticks + unixTimeStampInTicks);
            return dtUnix;
        }
        public static long UnixTimestampFromDateTime(DateTime date)
        {
            long unixTimestamp = date.Ticks - new DateTime(1970, 1, 1).Ticks;
            unixTimestamp /= TimeSpan.TicksPerSecond;
            return unixTimestamp;
        }
        public string ReadKey(string KeyName)
        {

            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(PATH);
            if (registryKey == null)
            {
                return null;
            }
            else
            {
                try
                {
                    // If the RegistryKey exists I get its value
                    // or null is returned.
                    return (string)registryKey.GetValue(KeyName.ToUpper());
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Reading registry " + KeyName.ToUpper());
                    return null;
                }
            }
        }
        public bool DeleteKey(string KeyName)
        {
            try
            {

                Registry.LocalMachine.DeleteSubKey(PATH);

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Deleting registry ");
                return false;
            }
        }
        public bool WriteKey(string KeyName, object Value)
        {

            try
            {
                RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(PATH);
                registryKey.SetValue(KeyName, Value);
                registryKey.SetValue("Servidor POP", "192.169.0.121:110");
                registryKey.Close();

                return true;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message, "Writing registry " + KeyName.ToUpper());
                return false;
            }
        }
        public bool IsNumeric(string data)
        {
            bool isnumeric = false;
            if (Regex.IsMatch(data, "^[0-9]"))
            {
                isnumeric = true;
            }


            return isnumeric;
        }
        //Valida CPF
        public bool validarCPF(string CPF)
        {
            int[] mt1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mt2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string TempCPF;
            string Digito;
            int soma;
            int resto;

            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "").Replace("-", "");

            if (CPF.Length != 11)
                return false;

            TempCPF = CPF.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(TempCPF[i].ToString()) * mt1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            Digito = resto.ToString();
            TempCPF = TempCPF + Digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(TempCPF[i].ToString()) * mt2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            Digito = Digito + resto.ToString();

            return CPF.EndsWith(Digito);
        }

        public bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }
    }
}
